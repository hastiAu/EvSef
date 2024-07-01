using Microsoft.AspNetCore.Http;
 

namespace EvSef.Core.Security
{
    public static class ImageValidator
    {
        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        public static bool IsImage(this IFormFile file)
        {

            try
            {
                var img = System.Drawing.Image.FromStream(file.OpenReadStream());

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
