using System.Security.Claims;

namespace MVC_DOAN
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            try
            {
                return user.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
