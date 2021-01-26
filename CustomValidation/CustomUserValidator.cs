using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentity.CustomValidation
{
    public class CustomUserValidator:IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            List<IdentityError> errors = new List<IdentityError>();


            string[] a = new[]
            {
                "0","1","2","3","4","5","6","7","8","9","-","_",
            };

            foreach (var dizi in a)
            {
                if (user.UserName[0].ToString()==dizi)
                {
                    errors.Add(new IdentityError() { Code = "usernameNotStartNumber", Description = "Kullanıcı adı '"+dizi+"' ile başlayamaz" });
                    break;
                }
            }

            if (errors.Count == 0)
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }
        }
    }
}
