using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentity.CustomValidation
{
    public class CustomPasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();

            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                errors.Add(new IdentityError() { Code = "PasswordContainsUsername", Description = "Şifre alanı kullanıcı adını içeremez" });
            }

            string[] a = new[]
            {
                "1234",
                "2345",
                "3456",
                "4567"
            };

            foreach (var dizi in a)
            {
                if (password.ToLower().Contains(dizi))
                {
                    errors.Add(new IdentityError() { Code = "PasswordContains1234", Description = "Şifre ardışık sayı içeremez" });
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
