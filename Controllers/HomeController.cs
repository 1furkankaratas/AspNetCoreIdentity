using AspNetCoreIdentity.Models;
using AspNetCoreIdentity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AspNetCoreIdentity.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
            : base(userManager, signInManager) { }
        public IActionResult Index()
        {
            TempData["saat"] = DateTime.Now;
            TempData["saat2"] = DateTime.UtcNow;
            return View();
        }


        public IActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Gerekli Alanları Doldurunuz!");
                return View(model);
            }

            AppUser user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await UserManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                string confirmationToken = await UserManager.GenerateEmailConfirmationTokenAsync(user);
                string link = Url.Action("ConfirmEmail", "Home", new
                {
                    userId = user.Id,
                    token = confirmationToken
                },protocol:HttpContext.Request.Scheme);

                Helpers.EmailConfirmationHelper.EmailConfirmationSendMail(link,user.Email);

                return RedirectToAction("LogIn");
            }
            else
            {
                AddModelError(result);
                return View(model);
            }

        }


        public IActionResult LogIn(string returnUrl, string prs)
        {

            TempData["ReturnUrl"] = returnUrl;
            TempData["prs"] = prs;

            return View();
        }


        // TODO increment 2 şer artıyor ve kullanıcı kendi kendine kitleniyor yorum satırındaki kodlar ile kitlenmesi gerekirken sistem tarafından kitleniyor
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Gerekli Alanları Doldurunuz!");
                return View(model);
            }

            AppUser user = await UserManager.FindByEmailAsync(model.Email);

            if (user != null)
            {

                if (await UserManager.IsLockedOutAsync(user))
                {
                    ModelState.AddModelError("", "Hesabınız bir süreliğine kitlenmiştir lütfen daha sonra tekrar deneyiniz");
                    return View();
                }

                if (!UserManager.IsEmailConfirmedAsync(user).Result)
                {
                    ModelState.AddModelError("","Lüften epostanıza gönderilen hesap doğrulama linkine tıklayınız.");
                    return View(model);
                }

                await SignInManager.SignOutAsync();
                var result = await SignInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);

                if (result.Succeeded)
                {

                    await UserManager.ResetAccessFailedCountAsync(user);

                    if (TempData["ReturnUrl"] != null)
                    {
                        return Redirect(TempData["ReturnUrl"].ToString());
                    }
                    return RedirectToAction("Index", "Member");
                }
                else
                {

                    await UserManager.AccessFailedAsync(user);
                    int failCount = await UserManager.GetAccessFailedCountAsync(user);
                    ModelState.AddModelError("", $"{failCount}");
                    //if (failCount>=6)
                    //{
                    //    await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.Now.AddDays(1));
                    //    ModelState.AddModelError("", "3 başarısız giriş işleminden dolayı hesabınız 20 dakika süreyle kitlenmiştir");
                    //    return View();


                    //}
                }

            }
            ModelState.AddModelError("", "Girilen bilgilerle uyumlu bir kullanıcı bulunamadı.");
            return View(model);
        }



        public IActionResult ResetPassword()
        {


            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser user = UserManager.FindByEmailAsync(model.Email).Result;

            if (user != null)
            {
                string passwordResetToken = UserManager.GeneratePasswordResetTokenAsync(user).Result;

                string resetPasswordLink = Url.Action("ResetPasswordConfirm", "Home", new
                {
                    userId = user.Id,
                    token = passwordResetToken


                }, HttpContext.Request.Scheme);

                Helpers.ResetPasswordHelper.ResetPasswordSendMail(resetPasswordLink,user.Email);
                ViewBag.status = "successful";
            }
            else
            {
                ModelState.AddModelError("", "Sistemde kayıtlı bir email adresi bulumamıştır");
            }

            return View(model);
        }


        public IActionResult ResetPasswordConfirm(string userId, string token)
        {

            TempData["UserId"] = userId;
            TempData["token"] = token;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPasswordConfirm(ResetPasswordConfirmViewModel model)
        {

            string token = TempData["token"].ToString();
            string userId = TempData["UserId"].ToString();

            AppUser user = await UserManager.FindByIdAsync(userId);

            if (user != null)
            {
                var result = await UserManager.ResetPasswordAsync(user, token, model.PasswordNew);

                if (result.Succeeded)
                {
                    await UserManager.UpdateSecurityStampAsync(user);

                    return Redirect("/Home/LogIn?prs=t");

                }
                else
                {
                    AddModelError(result);
                    return Redirect("/Home/LogIn?prs=f");

                }
            }

            return View();
        }

        public async Task<IActionResult> ConfirmEmail(string userid, string token)
        {

            var user = await UserManager.FindByIdAsync(userid);
            var result = await UserManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                
            }
            else
            {
                AddModelError(result);
            }

            return RedirectToAction("LogIn", "Home");

        }
    }

}

