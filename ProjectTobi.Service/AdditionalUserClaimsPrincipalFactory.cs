using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ProjectTobi.Model;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectTobi.Service
{
    public class AdditionalUserClaimsPrincipalFactory: UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>
    {
        public AdditionalUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IOptions<IdentityOptions> optionsAccessor)
            :base(userManager, roleManager, optionsAccessor)
        {}

        public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);
            var identity = (ClaimsIdentity)principal.Identity;

            var claims = new List<Claim>();
            if (user.IsAdmin)
            {
                claims.Add(new Claim(JwtClaimTypes.Role, "admin"));
            } 
            else
            {
                claims.Add(new Claim(JwtClaimTypes.Role, "user"));
            }

            identity.AddClaims(claims);
            return principal;
        }
    }

    internal static class JwtClaimTypes
    {
        public const string Role = "role"; 
    }
}
