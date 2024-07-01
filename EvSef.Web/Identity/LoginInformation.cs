using System.Security.Claims;
using System.Security.Principal;

namespace EvSef.Web.Identity
{
    
        public static class LoginInformation
        {
            public static string GetCurrentUserMobile(this ClaimsPrincipal claimsPrincipal)
            {
                return claimsPrincipal.FindFirst(ClaimTypes.MobilePhone)?.Value;
            }

            public static int GetCurrentUserId(this ClaimsPrincipal claimsPrincipal)
            {
                if (claimsPrincipal != null)
                {
                    var data = claimsPrincipal.Claims.SingleOrDefault(s => s.Type == ClaimTypes.NameIdentifier);
                    if (data != null) return Convert.ToInt32(data?.Value);
                    return default(int);
                }

                return default(int);
            }

            public static int GetCurrentUserId(this IPrincipal principal)
            {
                var user = (ClaimsPrincipal)principal;

                return user.GetCurrentUserId();
            }

            public static string? GetUserIpAddress(this HttpContext context)
            {
                return context.Connection.RemoteIpAddress?.ToString();
            }
        }
} 