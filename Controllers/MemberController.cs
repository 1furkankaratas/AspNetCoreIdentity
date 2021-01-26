using AspNetCoreIdentity.Enums;
using AspNetCoreIdentity.Models;
using AspNetCoreIdentity.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetCoreIdentity.Controllers
{
    [Authorize]
    public class MemberController : BaseController
    {

        public MemberController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager) : base(userManager, signInManager)
        {
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {

            await SignInManager.SignOutAsync();

            return RedirectToAction("LogIn", "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {

            return View();
        }


        public IActionResult Index()
        {

            AppUser user = CurrentUser;

            UserViewModel userViewModel = user.Adapt<UserViewModel>();

            userViewModel.claims = User.Claims.ToList();

            return View(userViewModel);
        }


        public IActionResult PasswordChange()
        {


            return View();
        }

        [HttpPost]
        public IActionResult PasswordChange(PasswordChangeViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            AppUser user = CurrentUser;

            if (user != null)
            {
                bool exist = UserManager.CheckPasswordAsync(user, model.OldPassword).Result;

                if (exist)
                {
                    var result = UserManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword).Result;

                    if (result.Succeeded)
                    {
                        UserManager.UpdateSecurityStampAsync(user);
                        return Redirect("/Home/LogIn?prs=t");
                    }
                    else
                    {
                        AddModelError(result);
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Girilen bilgiler yanlıştır");
                }
            }


            return View(model);
        }


        public IActionResult UserEdit()
        {

            AppUser user = CurrentUser;


            UserViewModel userViewModel = user.Adapt<UserViewModel>();

            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));

            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserViewModel model, IFormFile userPicture)
        {
            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            AppUser user = CurrentUser;


            if (userPicture != null && userPicture.Length > 0)
            {
                var filename = Guid.NewGuid().ToString() + Path.GetExtension(userPicture.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/picture/user", filename);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await userPicture.CopyToAsync(stream);

                    user.Picture = "/picture/user/" + filename;
                }
            }


            user.UserName = model.UserName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.City = model.City;
            user.Gender = (int)model.Gender;
            user.BirthDay = model.BirthDay;


            var result = await UserManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                await UserManager.UpdateSecurityStampAsync(user);
                await SignInManager.SignOutAsync();
                await SignInManager.SignInAsync(user, true);
                return RedirectToAction("Index", "Member");
            }
            else
            {
                AddModelError(result);
            }


            return View(model);
        }


        [Authorize(Policy = "AnkaraPolicy")]
        public IActionResult Ankarapage()
        {
            return View();
        }

        [Authorize(Policy = "violencePolicy")]
        public IActionResult ViolencePage()
        {
            return View();
        }

        public async Task<IActionResult> ExchanceRedirect()
        {
            bool result = User.HasClaim(x => x.Type == "expireDateExchange");

            if (!result)
            {
                Claim expireDateExchange = new Claim("expireDateExchange", DateTime.Now.AddDays(30).ToShortDateString(),ClaimValueTypes.String,"Internal");

                await UserManager.AddClaimAsync(CurrentUser, expireDateExchange);

                await SignInManager.SignOutAsync();
                await SignInManager.SignInAsync(CurrentUser, true);
            }

            return RedirectToAction("Exchance");
        }

        [Authorize(Policy = "expireDateExchange")]
        public IActionResult Exchance()
        {

            return View();
        }

    }
}
