using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentity.ClaimProvider
{
    public class ClaimProvider:IClaimsTransformation
    {
        private readonly UserManager<AppUser> _userManager;

        public ClaimProvider(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (principal!=null&&principal.Identity.IsAuthenticated)
            {
                var identity = principal.Identity as ClaimsIdentity;

                AppUser user = await _userManager.FindByNameAsync(identity.Name);

                if (user!=null)

                    if (user.BirthDay!=null)
                    {
                        var today = DateTime.Today;
                        var age = today.Year - user.BirthDay?.Year;

                        if (age>15)
                        {
                            Claim violenceClaim = new Claim("violence", true.ToString(), ClaimValueTypes.String, "Internal");

                            identity.AddClaim(violenceClaim);
                        }


                    }
                {
                    if (user.City!=null)
                    {
                        if (!principal.HasClaim(c=>c.Type=="city"))
                        {
                            Claim CityClaim = new Claim("city",user.City,ClaimValueTypes.String,"Internal");

                            identity.AddClaim(CityClaim);
                        }
                    }
                }

            }

            return principal;
        }
    }
}
