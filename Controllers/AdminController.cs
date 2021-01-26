using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreIdentity.Models;
using AspNetCoreIdentity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentity.Controllers
{   
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        public AdminController(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
            :base(userManager, null,roleManager) { }

        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View(RoleManager.Roles.ToList());
        }

        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RoleCreate(RoleViewModel model)
        {

            AppRole role = new AppRole()
            {
                Name = model.Name
            };;
            var result = RoleManager.CreateAsync(role).Result;

            if (result.Succeeded)
            {
                return RedirectToAction("Roles");
            }
            else
            {
                AddModelError(result);
            }

            return View();
        }

        
        public IActionResult RoleDelete(string id)
        {
            var role = RoleManager.FindByIdAsync(id).Result;
            var result = RoleManager.DeleteAsync(role).Result;

            if (result.Succeeded)
            {
                return RedirectToAction("Roles");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }


        public IActionResult Users()
        {
            return View(UserManager.Users.ToList());
        }

        public IActionResult RoleEdit(string id)
        {

            var a = RoleManager.FindByIdAsync(id).Result;
            RoleViewModel role = new RoleViewModel()
            {
                Name = a.Name,
                Id = a.Id
            };

            return View(role);
        }

        [HttpPost]
        public IActionResult RoleEdit(RoleViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Roles");
            }

            var a = RoleManager.FindByIdAsync(model.Id).Result;

            a.Name = model.Name;
            var result = RoleManager.UpdateAsync(a).Result;

            if (result.Succeeded)
            {
                return RedirectToAction("Roles");
            }
            else
            {
                AddModelError(result);
            }

            return View(model);
        }

        public IActionResult RoleAssign(string id)
        {
            TempData["userId"] = id;
            AppUser user = UserManager.FindByIdAsync(id).Result;


            var roles = RoleManager.Roles;

            var userRoles = UserManager.GetRolesAsync(user).Result;

            List<RoleAssignViewModel> assignViewModels = new List<RoleAssignViewModel>();

            foreach (var role in roles)
            {
                RoleAssignViewModel r = new RoleAssignViewModel();

                r.RoleId = role.Id;
                r.RoleName = role.Name;
                r.Exist = userRoles.Contains(role.Name);
                assignViewModels.Add(r);
            }

            return View(assignViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> RoleAssign(List<RoleAssignViewModel> model)
        {
            AppUser user = await UserManager.FindByIdAsync(TempData["userId"].ToString());
            foreach (var roleAssign in model)
            {
                if (roleAssign.Exist)
                {
                    await UserManager.AddToRoleAsync(user, roleAssign.RoleName);
                }
                else
                {
                    await UserManager.RemoveFromRoleAsync(user, roleAssign.RoleName);
                }
            }

            await UserManager.UpdateSecurityStampAsync(user);
            return RedirectToAction("Users");
        }
    }
}
