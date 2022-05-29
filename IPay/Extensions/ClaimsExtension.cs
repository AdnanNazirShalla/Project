using System.Security.Claims;

namespace IPay
{
    public static class ClaimsExtension
    {
        public static Guid GetUserId(this ClaimsPrincipal principal)
        {
            if (Guid.TryParse(principal?.Claims?.FirstOrDefault(x => x.Type == AppCLaimTypes.id)?.Value, out Guid userId))
                return userId;
            return Guid.Empty;
        }

        public static string? GetUserName(this ClaimsPrincipal principal)
        {
            return principal?.Claims?.FirstOrDefault(x => x.Type == AppCLaimTypes.name)?.Value;
        }

        public static string? GetUserEmail(this ClaimsPrincipal principal)
        {
            return principal?.Claims?.FirstOrDefault(x => x.Type == AppCLaimTypes.email)?.Value;
        }

        public static string? GetUserBalance(this ClaimsPrincipal principal)
        {
            return principal?.Claims?.FirstOrDefault(x => x.Type == AppCLaimTypes.balance)?.Value;
        }
    }
}
