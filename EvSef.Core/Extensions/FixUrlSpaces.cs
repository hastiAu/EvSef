namespace EvSef.Core.Extensions
{
    public static class FixUrlSpaces
    {
        public static string FixUrlSpacesWithDash(this string url)
        {
            return url.ToLower().Replace(" ", "-");
        }
    }
}
