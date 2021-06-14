var selectedNewCompany;

$(function () {

    $("#articles-grid").dxDataGrid({
        dataSource: DevExpress.data.AspNet.createStore({
            key: "id",
            
            loadUrl: "../api/Files/List",
            insertUrl: "../api/Files/Insert",
            updateUrl: "../api/Files/Update",
            deleteUrl: "../api/Files/Delete"
        }),
        columns: [
            {
                dataField: "id",
                caption: "Id",
                width: 60,
                sortOrder: "desc",
                orderIndex: 0
            },
            {
                dataField: "linkForAdmin",
                caption: "Link for admin",
                cellTemplate: function (container, options) {
                    container.append("<a href=\"" + options.text + "\">Link</a>");
                },
                width: 400
            },
            {
                dataField: "fileHeader",
                caption: "FileHeader"
            },
            {
                dataField: "countOfDownloads",
                caption: "Downloads",
                width: 100,
            },
            {
                dataField: "fileLink",
                caption: "File Link",
                visible: true,
                editCellTemplate: (itemElement, cellInfo) => {

                    let tb = $("<div />").dxTextBox({
                        value: cellInfo.value,
                        onValueChanged: (e) => {
                            cellInfo.setValue(e.value);
                        }
                    })
                    tb.appendTo(itemElement);

                    $("<div />").dxFileUploader({
                        uploadUrl: "../api/Image/UploadImage",
                        onUploaded: (e) => {
                            cellInfo.setValue(e.request.response);
                            tb.dxTextBox('option', 'value', e.request.response);
                        }
                    }).appendTo(itemElement);
                }
            },
            {
                dataField: "fileDescription",
                visible: false,
                editCellTemplate: (itemElement, cellInfo) => {

                    ($("<textarea>", { "id": "ckpeditor", "val": cellInfo.value })).appendTo(itemElement);

                    $("<script>").append(CKEDITOR.replace("ckpeditor", {
                        extraPlugins: 'embed',
                        embed_provider: '//ckeditor.iframe.ly/api/oembed?url={url}&callback={callback}&api_key=90d4029ed5529f8b49bbdc',
                        filebrowserBrowseUrl: '/lib/fileman/index.html',
                        filebrowserImageBrowseUrl: '/lib/fileman/index.html' + '?type=image',
                        removeDialogTabs: 'link:upload;image:upload'
                    })).appendTo(itemElement);

                    $("<script>").append(CKEDITOR.instances.ckpeditor.on("change", function () { cellInfo.setValue(CKEDITOR.instances.ckpeditor.getData()) })).appendTo(itemElement);

                }
            },
            {
                dataField: "filePassword",
                caption: "File Password",
                visible: false
            }
            
        ],
        editing: {
            mode: "popup",
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true,
            popup: {
                title: "Files",
                showTitle: true,
                my: "top",
                at: "top",
                of: window
            },
            form: {
                colCount: 2,
                items: [
                    {
                        colSpan: 2,
                        dataField: "fileLink",
                        caption: "File link",
                        visible: true
                    },
                    {
                        colSpan: 1,
                        dataField: "fileHeader",
                        caption: "FileHeader",
                        visible: true
                    },
                    {
                        colSpan: 1,
                        dataField: "filePassword",
                        caption: "FileHeader",
                        visible: true
                    },
                    {
                        colSpan: 2,
                        dataField: "fileDescription",
                        caption: "FileDescription",
                        visible: true
                    }
                ]
            }
        },
        remoteOperations: true,
        searchPanel: {
            visible: true
        },
        grouping: {
            autoExpandAll: false
        },
        filterRow: {
            visible: true,
            applyFilter: "onClick"
        }
    });
});