﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using borsvarlden.Extensions;

namespace borsvarlden.Helpers
{
    public static class ImageHelper
    {
        private static string _imagePath;

        private static string CompaniesPath => $@"{_imagePath}\company";

        private static string SocialTagPath => $@"{_imagePath}\socialtag";

        private static List<string> AvailableCompanies;

        private static readonly Dictionary<string, string> DictSocialTag = new Dictionary<string, string>
        {
                { "agriculture"      , "Jordbruk"},
                { "aktier"           , "Aktier" },
                { "analytics"        , "Analytiker"},
                { "automotive"       , "Fordon"},
                { "aviation"         , "Flyg"},
                { "basemetals"       , "Basmetaller"},
                { "betting"          , "Betting"},
                { "biometrics"       , "Biometri"},
                { "bonds"            , "Räntor"},
                { "commodities"      , "Råvaror"},
                { "copper"           , "Koppar"},
                { "crowdfunding"     , "Crowdfunding"},
                { "cryptocurrency"   , "Kryptovalutor"},
                { "currencies"       , "Valutor"},
                { "defence"          , "Försvar"},
                { "dividend"         , "Utdelning"},
                { "ecommerce"        , "E-handel"},
                { "energy"           , "Energi"},
                { "equities"         , "Kapital"},
                { "etp"              , "ETP"},
                { "financials"       , "Finans"},
                { "fintech"          , "Fintech"},
                { "finwiretv"        , "Finwire TV"},
                { "foods"            , "Livsmedel"},
                { "funding"          , "Finansiering"},
                { "gaming"           , "Gaming"},
                { "gold"             , "Guld"},
                { "healthcare"       , "Sjukvård"},
                { "hedgefonder"      , "Hedgefonder"},
                { "hedgefunds"       , "Hedgefonder"},
                { "industrials"      , "Verkstad"},
                { "insider"          , "Insider"},
                { "ipo"              , "IPO"},
                { "leisure"          , "Fritid"},
                { "lifescience"      , "Lifescience"},
                { "macro"            , "Makro"},
                { "materials"        , "Material"},
                { "media"            , "Media"},
                { "mutualfunds"      , "Fonder"},
                { "oil"              , "Olja"},
                { "pharmaceuticals"  , "Läkemedel"},
                { "podd"             , "Podcast"},
                { "realestate"       , "Fastighet"},
                { "renewable"        , "Förnybart"},
                { "retail"           , "Handel"},
                { "services"         , "Tjänster"},
                { "share"            , "Börsen"},
                { "space"            , "Rymden"},
                { "stockholmbullets" , "Börsen"},
                { "stocks"           , "Börsen"},
                { "tech"             , "Teknik"},
                { "telecom"          , "Telekom"},
                { "transports"       , "Transport"},
                { "vr"               , "VR"},
                { "wind"             , "Vindkraft"}
        };

        public static void Init(string imagePath)
        {
            _imagePath = imagePath;
            InitAvailableData();
        }

        public static ImageData GetImageData(List<string> socialTagsInNews, List<string> companiesInNews)
        {
            return GetImageDataImplementation(socialTagsInNews?.Select(x => x.ToLower()).ToList()
                    ,companiesInNews?.Select(x => x.ToLower()).ToList());
        }

        private static string PostProcessImageLabel(string rawImageLabel, List<string> socialTagsInNews)
        {
            string labelOutput = null;

            if (rawImageLabel != null)
                if (DictSocialTag.TryGetValue(rawImageLabel,  out labelOutput))
                    return labelOutput;

            var needles = new List<object>()
            {
                // Specific cases socialtags
                "stockholmbullets", // filter
                "ipo", // filter
                "cryptocurrency", // filter

                // Company-describing socialtags based on importance
                "space", // often grouped with telecom, space is more important
                "healthcare", // more important than tech, vr
                "betting", // more important than gaming/leisure

                // Company-describing socialtags of equal value
                new List<string>
                {
                    "aviation",
                    "agriculture",
                    "automotive", // filter
                    "biometrics", // filter
                    "gaming", // filter
                    "ecommerce",
                    "telecom",
                    "vr",
                    "realestate",
                    "retail"
                },

                "tech", // filter

                // Rest of the original filter socialtags
                "analytics", // filter
                "commodities", // filter
                "crowdfunding", // filter
                "dividend", // filter
                "funding", // filter
                "macro", // filter
                "share" // filter
            };

            string thisNeedle = null;

            foreach (var needle in needles)
            {
                if (needle is List<string>)
                {
                    var needleList = ((List<string>)needle);
                    var intersect = needleList.Intersect(socialTagsInNews).ToList();
                    if (intersect.Any())
                        thisNeedle = intersect.GetRandomElement();
                    else
                        continue;
                }
                else if (needle is string)
                {
                    thisNeedle = (string)needle;
                }
                else
                    throw new ApplicationException("GetImagePath wrong item type");

                if (socialTagsInNews?.Contains(thisNeedle) ?? true)
                {
                    labelOutput = thisNeedle;
                    break;
                }
            }

            if (labelOutput != null)
            {
                if (DictSocialTag.TryGetValue(labelOutput, out var translatedLabelOutput))
                    return translatedLabelOutput;

                return labelOutput;
            }

            return "Nyhet";
        }

        private static ImageData GetImageDataImplementation(List<string> socialTagsInNews, List<string> companiesInNews)
        {
            string matchedDir = "";
            string label = "";

            if (companiesInNews?.Count == 1 && AvailableCompanies.Intersect(companiesInNews).Any())
            {
                var dirPath = $@"{CompaniesPath}\{companiesInNews?.First()}";
                var imageData = FileHelper.GetRandomImageFromDir(dirPath);
                imageData.Label = PostProcessImageLabel(imageData.Label, socialTagsInNews);
                return imageData;
            }

            var needles =
                new List<object>()
                {
                    // Specific cases socialtags
                    "stockholmbullets", // filter
                    "ipo", // filter
                    "cryptocurrency", // filter

                    // Company-describing socialtags based on importance
                    "space", // often grouped with telecom, space is more important
                    "healthcare", // more important than tech, vr
                    "betting", // more important than gaming/leisure

                    // Company-describing socialtags of equal value
                    new List<string>
                    {
                        "aviation",
                        "agriculture",
                        "automotive", // filter
                        "biometrics", // filter
                        "gaming", // filter
                        "ecommerce",
                        "telecom",
                        "vr",
                        "realestate",
                        "retail",
                    },

                    "tech", // filter

                    // Rest of the original filter socialtags
                    "analytics", // filter
                    "commodities", // filter
                    "crowdfunding", // filter
                    "dividend", // filter
                    "funding", // filter
                    "macro", // filter
                    "share", // filter
            };
            string thisNeedle = null;

            foreach (var needle in needles)
            {
                if (needle is List<string>)
                {
                    var needleList = ((List<string>) needle);
                    var intersect = needleList.Intersect(socialTagsInNews).ToList();
                    if (intersect.Any())
                        thisNeedle = intersect.GetRandomElement();
                    else
                        continue;
                }
                else if (needle is string)
                {
                    thisNeedle = (string) needle;
                }
                else
                    throw new ApplicationException("GetImagePath wrong item type");
                
                //Current needle exists in news's  socialtags
                if (socialTagsInNews?.Contains(thisNeedle)??true)
                {
                    var pathSocialTags = $@"{SocialTagPath}\{thisNeedle}";
                    //If we'll not find any subdirs - use this one as resulst
                    matchedDir = pathSocialTags;
                    label = thisNeedle;
                    //Check if we have "subs". If yes - ovewrite with the dir of sub
                    //Note that socialtags "subs" - have more priority then company "subs" -
                    //they override the companies subtags. It was in original code
                    CheckMatchedSubs("company", companiesInNews);
                    CheckMatchedSubs("socialtag", socialTagsInNews); 

                    void CheckMatchedSubs(string sub, List<string> listFromNews)
                    {
                        if (listFromNews == null)
                            return;

                        var pathOfSub = $@"{pathSocialTags}\{sub}";
                        //Check if we have "sub" available for submatch
                        if (Directory.Exists(pathOfSub))
                        {
                            //Get all subdirectory of "sub"
                            var availableSubDirs = FileHelper.GetSubdirectories(pathOfSub);
                            var intersectCompanies = availableSubDirs.Intersect(listFromNews).ToList();
                            //If we have subdirs get random one
                            if (intersectCompanies.Any())
                            {
                                var randomSub = intersectCompanies.GetRandomElement();
                                var directorySubCompany = $@"{pathOfSub}\{randomSub}";
                                matchedDir = directorySubCompany;
                                label = randomSub;
                            }
                        }
                    }

                    var imageDataMatched = FileHelper.GetRandomImageFromDir(matchedDir);
                    imageDataMatched.Label = PostProcessImageLabel(label, socialTagsInNews);
                    return imageDataMatched;
                }
            }

            //If not found use blackfill
            var imageDataBlackFill = FileHelper.GetRandomImageFromDir($@"{_imagePath}\backfill");

            imageDataBlackFill.Label = PostProcessImageLabel(label,socialTagsInNews);
            return imageDataBlackFill;

        }

        public static string AbsoluteUrlToRelativeUrl(string absoluteUrl)
        {
            return absoluteUrl.Substring(absoluteUrl.IndexOf("assets")).Replace('\\', '/');
        }

        private static void InitAvailableData()
        {
            //todo lazy
            AvailableCompanies = FileHelper.GetSubdirectories(CompaniesPath);
        }
    }

    public class ImageData
    {
        public string ImageAbsoluteUrl { get; set; }
        public string ImageSource { get; set; }
        public string Label { get; set; }
    }
}
