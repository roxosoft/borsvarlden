using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;

using System.Linq;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;

using DevExtreme.AspNet.Mvc.FileManagement;

/* Note: graphics manipulation not yet available in ASP.NET Core so no thumbnails or image sizes */

namespace borsvarlden.Controllers
{
    [Authorize] // Important: uncomment this in production to prevent huge security risk!
    [Route("api/[controller]/[action]"), Produces("application/json")]
    public class RoxyFilemanAzureController : Controller
    {
        private string _systemRootPath;
        private string _tempPath;
        private string _filesRootPath;
        private string _filesRootVirtual;
        private Dictionary<string, string> _settings;
        private Dictionary<string, string> _lang = null;

        public RoxyFilemanAzureController(IHostingEnvironment env)
        {
            // Setup CMS paths to suit your environment (we usually inject settings for these)
            _systemRootPath = env.ContentRootPath;
            _tempPath = _systemRootPath + "\\wwwroot\\assets\\temp";
            _filesRootPath = "/wwwroot/assets/uploads";
            _filesRootVirtual = "/assets/uploads";
            // Load Fileman settings
            LoadSettings();
        }

        private void LoadSettings()
        {
            _settings = JsonConvert.DeserializeObject<Dictionary<string, string>>(System.IO.File.ReadAllText(_systemRootPath + "/wwwroot/lib/fileman/conf.json"));
            string langFile = _systemRootPath + "/wwwroot/lib/fileman/lang/" + GetSetting("LANG") + ".json";
            if (!System.IO.File.Exists(langFile)) langFile = _systemRootPath + "/wwwroot/lib/fileman/lang/en.json";
            _lang = JsonConvert.DeserializeObject<Dictionary<string, string>>(System.IO.File.ReadAllText(langFile));
        }

        // GET api/RoxyFileman - test entry point//]
        [AllowAnonymous, Produces("text/plain"), ActionName("")]
        public string Get() { return "RoxyFileman - access to API requires Authorisation"; }

        CloudBlobContainer _container;
        CloudBlobContainer Container
        {
            get
            {
                if (this._container == null)
                {
                    CloudStorageAccount account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=borsvarlden;AccountKey=hhso0OgNXmxyj3L9UhXhQJwXsZraq6IFGm5n+d+6ENrpBWyX6WQgVeyLhWvBXSS0OXo9igQZ6Ydx7tCsDdAWRA==;EndpointSuffix=core.windows.net");
                    var client = account.CreateCloudBlobClient();
                    this._container = client.GetContainerReference("uploads");
                }
                return this._container;
            }
        }

        #region API Actions
        string GetFileItemName(IListBlobItem blob)
        {
            string escapedName = blob.Uri.AbsoluteUri;
            return Uri.UnescapeDataString(escapedName);
        }

        string GetFileItemPath(FileSystemItemInfo item)
        {
            return item.Path.Replace('\\', '/');
        }

        bool GetHasDirectories(CloudBlobDirectory dir)
        {
            bool result;
            BlobContinuationToken continuationToken = null;
            do
            {
                BlobResultSegment segmentResult = dir.ListBlobsSegmented(continuationToken);
                continuationToken = segmentResult.ContinuationToken;
                result = segmentResult.Results.Any(blob => blob is CloudBlobDirectory);
            } while (!result && continuationToken != null);
            return result;
        }

        public IActionResult DIRLIST(string type)
        {
            try
            {
                ArrayList dirs = ListDirs("");
                string result = "";
                foreach (CloudBlobDirectory folder in dirs)
                {
                    result += (result != "" ? "," : "") + "{\"p\":\"/" + folder.Prefix.TrimEnd('/') + "\",\"f\":\"" + GetFiles(folder.Prefix, type).Count.ToString() + "\",\"d\":\"" + /*Directory.GetDirectories(dir).Length.ToString()*/0 + "\"}";
                }
                return Content("[" + result + "]", "application/json");
            }
            catch (Exception ex) { return Content(GetErrorRes(ex.Message)); }
        }

        public IActionResult FILESLIST(string d, string type)
        {
            try
            {
                List<CloudBlockBlob> files = GetFiles(d, type);
                string result = "";
                foreach (CloudBlockBlob f in files)
                {
                    //FileInfo f = new FileInfo(files[i]);
                    int w = 0, h = 0;
                    // NO SUPPORT IN ASP.NET CORE! Per haps see https://github.com/CoreCompat/CoreCompat
                    //if (GetFileType(f.Extension) == "image")
                    //{
                    //    try
                    //    {
                    //        //FileStream fs = new FileStream(f.FullName, FileMode.Open, FileAccess.Read);
                    //        //Image img = Image.FromStream(fs);
                    //        //w = img.Width;
                    //        //h = img.Height;
                    //        //fs.Close();
                    //        //fs.Dispose();
                    //        //img.Dispose();
                    //    }
                    //    catch (Exception ex) { throw ex; }
                    //}
                    result += (result != "" ? "," : "") +
                        "{" +
                        "\"p\":\"" + GetFileItemName(f) + "\"" +
                        ",\"t\":\"" + Math.Ceiling(LinuxTimestamp(f.Properties.LastModified.GetValueOrDefault().DateTime)).ToString() + "\"" +
                        ",\"s\":\"" + f.Properties.Length.ToString() + "\"" +
                        ",\"w\":\"" + w.ToString() + "\"" +
                        ",\"h\":\"" + h.ToString() + "\"" +
                        "}";
                }
                return Content("[" + result + "]");
            }
            catch (Exception ex) { return Content(GetErrorRes(ex.Message)); }
        }

        public IActionResult COPYDIR(string d, string n, bool remove = false)
        {
            try
            {
                d = d.TrimStart('/');
                n = n.TrimStart('/');
                CloudBlobDirectory dir = Container.GetDirectoryReference(d);
                CopyDirectory(dir, $"{n}/{dir.Uri.Segments.Last()}", remove);
                return Content(GetSuccessRes());
            }
            catch (Exception ex) { return Content(GetErrorRes(ex.Message)); }
        }

        public IActionResult COPYFILE(string f, string n, bool remove = false)
        {
            try
            {
                string blobKey = $"{f.Replace(Container.Uri.AbsoluteUri, String.Empty)}".TrimStart('/');
                CloudBlockBlob blob = Container.GetBlockBlobReference(blobKey);
                Copy(blobKey, $"{n.TrimStart('/')}/{blob.Uri.Segments.Last()}", remove);

                return Content(GetSuccessRes());
            }
            catch (Exception ex) { return Content(GetErrorRes(ex.Message)); }
        }

        public IActionResult CREATEDIR(string d, string n)
        {
            try
            {
                string path = d;
                string blobKey = $"{d}/{n}/".TrimStart('/');
                CloudBlockBlob dirBlob = Container.GetBlockBlobReference(blobKey);
                dirBlob.UploadText("");
                
                return Content(GetSuccessRes());
           }
            catch (Exception ex) { return Content(GetErrorRes(ex.Message)); }
        }

        public IActionResult DELETEDIR(string d)
        {
            try
            {
                RemoveDirectory(d.TrimStart('/'));
                return Content(GetSuccessRes());
            }
            catch (Exception ex) { return Content(GetErrorRes(ex.Message)); }
        }

        public void DeleteItem(string key)
        {
            CloudBlob blob = Container.GetBlobReference(key);
            bool isFile = blob.Exists();
            if (isFile)
                RemoveFile(blob);
            else
                RemoveDirectory(key + "/");
        }

        void RemoveDirectory(string key)
        {
            CloudBlobDirectory dir = Container.GetDirectoryReference(key);
            RemoveDirectory(dir);
        }

        void RemoveDirectory(CloudBlobDirectory dir)
        {
            var children = new List<IListBlobItem>();
            BlobContinuationToken continuationToken = null;

            do
            {
                BlobResultSegment segmentResult = dir.ListBlobsSegmented(continuationToken);
                continuationToken = segmentResult.ContinuationToken;
                children.AddRange(segmentResult.Results);
            } while (continuationToken != null);

            foreach (IListBlobItem blob in dir.ListBlobs(true))
            {
                if (blob.GetType() == typeof(CloudBlob) || blob.GetType().BaseType == typeof(CloudBlob))
                {
                    ((CloudBlob)blob).DeleteIfExists();
                }
            }

            foreach (IListBlobItem blob in children)
            {
                if (blob is CloudBlob)
                {
                    RemoveFile((CloudBlob)blob);
                }
                else if (blob is CloudBlobDirectory)
                {
                    RemoveDirectory((CloudBlobDirectory)blob);
                }
                else
                {
                    throw new Exception("Unsupported blob type");
                }
            }
        }

        void RemoveFile(CloudBlob blob)
        {
            blob.Delete();
        }

        public IActionResult DELETEFILE(string f)
        {
            try
            {
                string blobKey = $"{f.Replace(Container.Uri.AbsoluteUri, String.Empty)}".TrimStart('/');
                CloudBlockBlob blob = Container.GetBlockBlobReference(blobKey);
                RemoveFile(blob);
                return Content(GetSuccessRes());
            }
            catch (Exception ex) { return Content(GetErrorRes(ex.Message)); }
        }

        public ActionResult DOWNLOAD(string f)
        {
            try
            {
                f = MakePhysicalPath(f);
                CheckPath(f);
                FileInfo file = new FileInfo(FixPath(f));
                if (file.Exists)
                {
                    string contentType;
                    new FileExtensionContentTypeProvider().TryGetContentType(file.FullName, out contentType);
                    return PhysicalFile(file.FullName, contentType ?? "application/octet-stream", file.Name);
                }
                else return NotFound();
            }
            catch (Exception ex) { return Json(GetErrorRes(ex.Message)); }
        }

        public ActionResult DOWNLOADDIR(string d)
        {
            try
            {
                d = MakePhysicalPath(d);
                d = FixPath(d);
                if (!Directory.Exists(d)) throw new Exception(LangRes("E_CreateArchive"));
                string dirName = new FileInfo(d).Name;
                string tmpZip = _tempPath + "/" + dirName + ".zip";
                if (System.IO.File.Exists(tmpZip)) System.IO.File.Delete(tmpZip);
                ZipFile.CreateFromDirectory(d, tmpZip, CompressionLevel.Fastest, true);
                return PhysicalFile(tmpZip, "application/zip", dirName + ".zip");
            }
            catch (Exception ex) { return Json(GetErrorRes(ex.Message)); }
        }

        public IActionResult MOVEDIR(string d, string n)
        {
            return COPYDIR(d, n, true);
        }

        public IActionResult MOVEFILE(string f, string n)
        {
            try
            {
                string blobKey = $"{f.Replace(Container.Uri.AbsoluteUri, String.Empty)}".TrimStart('/');
                CloudBlockBlob blob = Container.GetBlockBlobReference(blobKey);
                Copy(blobKey, $"{n.TrimStart('/')}", true);

                return Content(GetSuccessRes());
            }
            catch (Exception ex) { return Content(GetErrorRes(ex.Message)); }
        }

        public void RenameItem(FileSystemRenameItemOptions options)
        {
            string newName = options.ItemNewName;
            string key = GetFileItemPath(options.Item);
            int index = key.LastIndexOf('/');
            string newKey;
            if (index >= 0)
            {
                string parentKey = key.Substring(0, index + 1);
                newKey = parentKey + newName;
            }
            else
                newKey = newName;

            Copy(key, newKey, true);
        }

        void Copy(string sourceKey, string destinationKey, bool deleteSource)
        {
            CloudBlob blob = Container.GetBlobReference(sourceKey);
            bool isFile = blob.Exists();
            if (isFile)
                CopyFile(blob, destinationKey, deleteSource);
            else
                CopyDirectory(sourceKey, destinationKey + "/", deleteSource);
        }

        void CopyFile(CloudBlob blob, string destinationKey, bool deleteSource = false)
        {
            CloudBlob blobCopy = Container.GetBlobReference(destinationKey);
            blobCopy.StartCopy(blob.Uri);
            if (deleteSource)
                blob.Delete();
        }

        void CopyDirectory(string sourceKey, string destinationKey, bool deleteSource = false)
        {
            CloudBlobDirectory dir = Container.GetDirectoryReference(sourceKey);
            CopyDirectory(dir, $"{dir.Parent.Prefix}{destinationKey}/", deleteSource);
        }

        void CopyDirectory(CloudBlobDirectory dir, string destinationKey, bool deleteSource = false)
        {
            var children = new List<IListBlobItem>();
            BlobContinuationToken continuationToken = null;

            do
            {
                BlobResultSegment segmentResult = dir.ListBlobsSegmented(continuationToken);
                continuationToken = segmentResult.ContinuationToken;
                children.AddRange(segmentResult.Results);
            } while (continuationToken != null);

            foreach (IListBlobItem blob in children)
            {
                string childCopyName = blob.Uri.Segments.Last();
                string childCopyKey = $"{destinationKey}{childCopyName}";
                if (blob is CloudBlob)
                {
                    CopyFile((CloudBlob)blob, childCopyKey, deleteSource);
                }
                else if (blob is CloudBlobDirectory)
                {
                    CopyDirectory((CloudBlobDirectory)blob, childCopyKey, deleteSource);
                }
                else
                {
                    throw new Exception("Unsupported blob type");
                }
            }
        }

        public IActionResult RENAMEDIR(string d, string n)
        {
            try
            {
                d = d.TrimStart('/');
                CloudBlobDirectory dir = Container.GetDirectoryReference(d);
                CopyDirectory(dir, $"{dir.Parent.Prefix}{n}/", true);
                return Content(GetSuccessRes());
            }
            catch (Exception ex) { return Content(GetErrorRes(ex.Message)); }
        }

        public IActionResult RENAMEFILE(string f, string n)
        {
            try
            {
                string blobKey = $"{f.Replace(Container.Uri.AbsoluteUri, String.Empty)}".TrimStart('/');
                CloudBlockBlob blob = Container.GetBlockBlobReference(blobKey);
                Copy(blobKey, $"{blob.Parent.Prefix}{n}", true);

                return Content(GetSuccessRes());
            }
            catch (Exception ex) { return Content(GetErrorRes(ex.Message)); }
        }

        [HttpPost, Produces("text/plain")]
        public string UPLOAD(string d)
        {
            try
            {
                string res = GetSuccessRes();
                bool hasErrors = false;
                try
                {
                    foreach (var file in HttpContext.Request.Form.Files)
                    {
                        if (CanHandleFile(file.FileName))
                        {
                            string destinationKey = $"{d}/{file.FileName}".TrimStart('/');
                            CloudBlockBlob newBlob = Container.GetBlockBlobReference(destinationKey);
                            newBlob.UploadFromStream(file.OpenReadStream());

                            //FileInfo f = new FileInfo(file.FileName);
                            //string filename = MakeUniqueFilename(d, f.Name);
                            //string dest = Path.Combine(d, filename);
                            //using (var saveFile = new FileStream(dest, FileMode.Create)) file.CopyTo(saveFile);
                            //if (GetFileType(new FileInfo(filename).Extension) == "image")
                            //{
                            //    int w = 0;
                            //    int h = 0;
                            //    int.TryParse(GetSetting("MAX_IMAGE_WIDTH"), out w);
                            //    int.TryParse(GetSetting("MAX_IMAGE_HEIGHT"), out h);
                            //    ImageResize(dest, dest, w, h);
                            //}
                        }
                        else
                        {
                            hasErrors = true;
                            res = GetSuccessRes(LangRes("E_UploadNotAll"));
                        }
                    }
                }
                catch (Exception ex) { res = GetErrorRes(ex.Message); }
                if (IsAjaxUpload())
                {
                    if (hasErrors) res = GetErrorRes(LangRes("E_UploadNotAll"));
                    return res;
                }
                else return "<script>parent.fileUploaded(" + res + ");</script>";
            }
            catch (Exception ex)
            {
                if (!IsAjaxUpload()) return "<script>parent.fileUploaded(" + GetErrorRes(LangRes("E_UploadNoFiles")) + ");</script>";
                else return GetErrorRes(ex.Message);
            }
        }

        /*
        public string GENERATETHUMB(string type)
        {
            try
            {
                //int w = 140, h = 0;
                //int.TryParse(_context.Request["width"].Replace("px", ""), out w);
                //int.TryParse(_context.Request["height"].Replace("px", ""), out h);
                //ShowThumbnail(_context.Request["f"], w, h);
            }
            catch (Exception ex) { return GetErrorRes(ex.Message); }
        }
        */
        #endregion

        #region Utilities
        private string MakeVirtualPath(string path)
        {
            return !path.StartsWith(_filesRootPath) ? path : _filesRootVirtual + path.Substring(_filesRootPath.Length);
        }

        private string MakePhysicalPath(string path)
        {
            return !path.StartsWith(_filesRootVirtual) ? path : _filesRootPath + path.Substring(_filesRootVirtual.Length);
        }

        private string GetFilesRoot()
        {
            string ret = _filesRootPath;
            if (GetSetting("SESSION_PATH_KEY") != "" && HttpContext.Session.GetString(GetSetting("SESSION_PATH_KEY")) != null) ret = HttpContext.Session.GetString(GetSetting("SESSION_PATH_KEY"));
            ret = FixPath(ret);
            return ret;
        }

        private ArrayList ListDirs(string path)
        {
            ArrayList ret = new ArrayList();

            var directory = Container.GetDirectoryReference(path);
            var folders = directory.ListBlobs().Where(b => b as CloudBlobDirectory != null).ToList();
            foreach (CloudBlobDirectory folder in folders)
            {
                ret.Add(folder);
                ret.AddRange(ListDirs(folder.Prefix));
            }
            return ret;
        }

        private List<CloudBlockBlob> GetFiles(string path, string type)
        {
            List<string> ret = new List<string>();
            if (type == "#" || type == null) type = "";

            var directory = Container.GetDirectoryReference(path.TrimStart('/'));
            var files = directory.ListBlobs().OfType<CloudBlockBlob>().Where(b => !b.Uri.Segments.Last().EndsWith('/')).ToList();

            return files;
        }

        private string GetFileType(string ext)
        {
            string ret = "file";
            ext = ext.ToLower();
            if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif") ret = "image";
            else if (ext == ".swf" || ext == ".flv") ret = "flash";
            return ret;
        }

        private void CheckPath(string path)
        {
            if (FixPath(path).IndexOf(GetFilesRoot()) != 0) throw new Exception("Access to " + path + " is denied");
        }

        private string FixPath(string path)
        {
            path = path.TrimStart('~');
            if (!path.StartsWith("/") && !path.StartsWith("\\")) path = "/" + path;
            return _systemRootPath + path;
        }

        private double LinuxTimestamp(DateTime d)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime();
            TimeSpan timeSpan = (d.ToLocalTime() - epoch);
            return timeSpan.TotalSeconds;
        }

        private string GetSetting(string name)
        {
            string ret = "";
            if (_settings.ContainsKey(name)) ret = _settings[name];
            return ret;
        }

        private string GetErrorRes(string msg) { return GetResultStr("error", msg); }

        private string GetResultStr(string type, string msg)
        {
            return "{\"res\":\"" + type + "\",\"msg\":\"" + msg.Replace("\"", "\\\"") + "\"}";
        }

        private string LangRes(string name) { return _lang.ContainsKey(name) ? _lang[name] : name; }

        private string GetSuccessRes(string msg) { return GetResultStr("ok", msg); }

        private string GetSuccessRes() { return GetSuccessRes(""); }

        private void CopyDir(string path, string dest)
        {
            if (!Directory.Exists(dest)) Directory.CreateDirectory(dest);
            foreach (string f in Directory.GetFiles(path))
            {
                FileInfo file = new FileInfo(f);
                if (!System.IO.File.Exists(Path.Combine(dest, file.Name))) System.IO.File.Copy(f, Path.Combine(dest, file.Name));
            }
            foreach (string d in Directory.GetDirectories(path)) CopyDir(d, Path.Combine(dest, new DirectoryInfo(d).Name));
        }

        private string MakeUniqueFilename(string dir, string filename)
        {
            string ret = filename;
            int i = 0;
            while (System.IO.File.Exists(Path.Combine(dir, ret)))
            {
                i++;
                ret = Path.GetFileNameWithoutExtension(filename) + " - Copy " + i.ToString() + Path.GetExtension(filename);
            }
            return ret;
        }

        private bool CanHandleFile(string filename)
        {
            bool ret = false;
            FileInfo file = new FileInfo(filename);
            string ext = file.Extension.Replace(".", "").ToLower();
            string setting = GetSetting("FORBIDDEN_UPLOADS").Trim().ToLower();
            if (setting != "")
            {
                ArrayList tmp = new ArrayList();
                tmp.AddRange(Regex.Split(setting, "\\s+"));
                if (!tmp.Contains(ext)) ret = true;
            }
            setting = GetSetting("ALLOWED_UPLOADS").Trim().ToLower();
            if (setting != "")
            {
                ArrayList tmp = new ArrayList();
                tmp.AddRange(Regex.Split(setting, "\\s+"));
                if (!tmp.Contains(ext)) ret = false;
            }
            return ret;
        }

        private bool IsAjaxUpload()
        {
            return (!string.IsNullOrEmpty(HttpContext.Request.Query["method"]) && HttpContext.Request.Query["method"].ToString() == "ajax");
        }
        #endregion

        /*
	        public bool ThumbnailCallback()
	        {
		        return false;
	        }

	        protected void ShowThumbnail(string path, int width, int height)
	        {
		        CheckPath(path);
		        FileStream fs = new FileStream(FixPath(path), FileMode.Open, FileAccess.Read);
		        Bitmap img = new Bitmap(Bitmap.FromStream(fs));
		        fs.Close();
		        fs.Dispose();
		        int cropWidth = img.Width, cropHeight = img.Height;
		        int cropX = 0, cropY = 0;

		        double imgRatio = (double)img.Width / (double)img.Height;

		        if(height == 0)
			        height = Convert.ToInt32(Math.Floor((double)width / imgRatio));

		        if (width > img.Width)
			        width = img.Width;
		        if (height > img.Height)
			        height = img.Height;

		        double cropRatio = (double)width / (double)height;
		        cropWidth = Convert.ToInt32(Math.Floor((double)img.Height * cropRatio));
		        cropHeight = Convert.ToInt32(Math.Floor((double)cropWidth / cropRatio));
		        if (cropWidth > img.Width)
		        {
			        cropWidth = img.Width;
			        cropHeight = Convert.ToInt32(Math.Floor((double)cropWidth / cropRatio));
		        }
		        if (cropHeight > img.Height)
		        {
			        cropHeight = img.Height;
			        cropWidth = Convert.ToInt32(Math.Floor((double)cropHeight * cropRatio));
		        }
		        if(cropWidth < img.Width){
			        cropX = Convert.ToInt32(Math.Floor((double)(img.Width - cropWidth) / 2));
		        }
		        if(cropHeight < img.Height){
			        cropY = Convert.ToInt32(Math.Floor((double)(img.Height - cropHeight) / 2));
		        }

		        Rectangle area = new Rectangle(cropX, cropY, cropWidth, cropHeight);
		        Bitmap cropImg = img.Clone(area, System.Drawing.Imaging.PixelFormat.DontCare);
		        img.Dispose();
		        Image.GetThumbnailImageAbort imgCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);

		        _r.AddHeader("Content-Type", "image/png");
		        cropImg.GetThumbnailImage(width, height, imgCallback, IntPtr.Zero).Save(_r.OutputStream, ImageFormat.Png);
		        _r.OutputStream.Close();
		        cropImg.Dispose();
	        }

	        private ImageFormat GetImageFormat(string filename){
		        ImageFormat ret = ImageFormat.Jpeg;
		        switch(new FileInfo(filename).Extension.ToLower()){
			        case ".png": ret = ImageFormat.Png; break;
			        case ".gif": ret = ImageFormat.Gif; break;
		        }
		        return ret;
	        }

	        protected void ImageResize(string path, string dest, int width, int height)
	        {
		        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
		        Image img = Image.FromStream(fs);
		        fs.Close();
		        fs.Dispose();
		        float ratio = (float)img.Width / (float)img.Height;
		        if ((img.Width <= width && img.Height <= height) || (width == 0 && height == 0))
			        return;

		        int newWidth = width;
		        int newHeight = Convert.ToInt16(Math.Floor((float)newWidth / ratio));
		        if ((height > 0 && newHeight > height) || (width == 0))
		        {
			        newHeight = height;
			        newWidth = Convert.ToInt16(Math.Floor((float)newHeight * ratio));
		        }
		        Bitmap newImg = new Bitmap(newWidth, newHeight);
		        Graphics g = Graphics.FromImage((Image)newImg);
		        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
		        g.DrawImage(img, 0, 0, newWidth, newHeight);
		        img.Dispose();
		        g.Dispose();
		        if(dest != ""){
			        newImg.Save(dest, GetImageFormat(dest));
		        }
		        newImg.Dispose();
	        }

	        public bool IsReusable {
		        get {
			        return false;
		        }
	        }
        */
    }
}