﻿using EvSef.Core.Convertors;
using EvSef.Core.Security;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
 

namespace EvSef.Core.Extensions
{

    public static class UploadImageExtension
    {
        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        [System.Runtime.Versioning.SupportedOSPlatform("windows10.0.18362")]
        [System.Runtime.Versioning.SupportedOSPlatform("ios14.0")]
        [System.Runtime.Versioning.SupportedOSPlatform("linux")]



        public static void AddImageToServer(this IFormFile image, string fileName, string orginalPath, int? width, int? height, string thumbPath = null, string deletefileName = null)
        {
            if (image != null && image.IsImage())
            {
                if (!Directory.Exists(orginalPath))
                    Directory.CreateDirectory(orginalPath);

                if (!string.IsNullOrEmpty(deletefileName))
                {
                    if (File.Exists(orginalPath + deletefileName))
                        File.Delete(orginalPath + deletefileName);

                    if (!string.IsNullOrEmpty(thumbPath))
                    {
                        if (File.Exists(thumbPath + deletefileName))
                            File.Delete(thumbPath + deletefileName);
                    }
                }

                string OriginPath = orginalPath + fileName;

                using (var stream = new FileStream(OriginPath, FileMode.Create))
                {
                    if (!Directory.Exists(OriginPath)) image.CopyTo(stream);
                }


                if (!string.IsNullOrEmpty(thumbPath))
                {
                    if (!Directory.Exists(thumbPath))
                        Directory.CreateDirectory(thumbPath);

                    ImageConvertor resizer = new ImageConvertor();

                    if (width != null && height != null)
                        resizer.Image_resize(orginalPath + fileName, thumbPath + fileName, width.Value);
                }
            }
        }

        public static void DeleteImage(this string imageName, string OriginPath, string ThumbPath)
        {
            if (!string.IsNullOrEmpty(imageName))
            {
                if (File.Exists(OriginPath + imageName))
                    File.Delete(OriginPath + imageName);

                if (!string.IsNullOrEmpty(ThumbPath))
                {
                    if (File.Exists(ThumbPath + imageName))
                        File.Delete(ThumbPath + imageName);
                }
            }
        }

        public static List<string> FetchLinksFromSource(this string htmlSource)
        {
            List<string> links = new List<string>();

            string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";

            MatchCollection matchesImgSrc = Regex.Matches(htmlSource, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            foreach (Match m in matchesImgSrc)
            {
                string href = m.Groups[1].Value;

                links.Add(href);
            }

            return links;
        }

        public static void EditEditorImages(this List<string> NewImages, List<string> PreviousImages)
        {
            foreach (var pre in PreviousImages)
            {
                var path = NewImages.Find(p => p == pre);

                if (path == null)
                    File.Delete("wwwroot/" + pre);
            }
        }
    }
}
