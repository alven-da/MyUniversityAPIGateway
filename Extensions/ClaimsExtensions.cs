using System.Security.Claims;

namespace MyUniversityAPIGateway.Extensions {
    public static class ClaimsExtensions {
        
        public static string? GetUserId(this ClaimsPrincipal user) {
            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}