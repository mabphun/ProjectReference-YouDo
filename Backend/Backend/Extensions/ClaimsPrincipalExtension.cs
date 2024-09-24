using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Backend.Extensions
{
    public static class ClaimsPrincipalExtension
    {

        public static T GetLoggedInUserId<T>(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            var loggedInUserId = principal.FindFirstValue(ClaimTypes.NameIdentifier);

            if (typeof(T) == typeof(string))
            {
                return (T)Convert.ChangeType(loggedInUserId, typeof(T));
            }
            else if (typeof(T) == typeof(int) || typeof(T) == typeof(long))
            {
                return loggedInUserId != null ? (T)Convert.ChangeType(loggedInUserId, typeof(T)) : (T)Convert.ChangeType(0, typeof(T));
            }
            else
            {
                throw new Exception("Invalid type provided");
            }
        }

        public static string GetLoggedInUserName(this ClaimsPrincipal principal)
        {
            var a = principal;
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));
            
            return principal.FindFirstValue(ClaimTypes.Name);
        }

        public static string GetLoggedInUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirstValue(ClaimTypes.Email);
        }
        public static string GetUsername(this ClaimsPrincipal user)
        {
            var username = user.Claims.FirstOrDefault(c=> c.Type == "name")?.Value;
            return username;
        }

        public static string GetUserId(this ClaimsPrincipal user)
        {
            var id = user.Claims.FirstOrDefault(c=> c.Type == "nameid")?.Value;
            return id;
        }
    }
}
