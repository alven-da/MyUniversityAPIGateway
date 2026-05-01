using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace MyUniversityAPIGateway.Data.Util
{
    public static class TestUtils {
        
        public static ClaimsPrincipal GetMockClaimsPrincipal(string studentId){
            var claims = new List<Claim> 
            { 
                new("sub", studentId)
            };

            var identity = new ClaimsIdentity(claims, "TestAuthType");
            return new ClaimsPrincipal(identity);
        }

        public static ControllerContext CreateDefaultControllerContextWithClaims(ClaimsPrincipal claimsPrincipal) {
            return new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = claimsPrincipal }
            };
        }
    }
}