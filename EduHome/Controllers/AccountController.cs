using EduHome.Extensions;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EduHome.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;


        public AccountController(UserManager<AppUser> userManager,
                                 RoleManager<IdentityRole> roleManager,
                                 SignInManager<AppUser> signInManager
            )
        {
            _userManager = userManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #region Login
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser = await _userManager.FindByNameAsync(loginVM.UserName);
            if (appUser == null)
            {
                ModelState.AddModelError("", "Username of Password is wrong !");
                return View();
            }
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, true, true);
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "Your account was blocked, Please 1 minute wait...");
            }
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Username of Password is wrong !");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }


        #endregion

        #region Register
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser newMember = new AppUser
            {
                UserName = register.UserName,
                Email = register.Email
            };
            IdentityResult identityResult = await _userManager.CreateAsync(newMember, register.Password);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError identityError in identityResult.Errors)
                {
                    ModelState.AddModelError("", identityError.Description);
                }
                return View();
            }
            else
            {
                await _userManager.AddToRoleAsync(newMember, Helper.Roles.Member.ToString());
                await _signInManager.SignInAsync(newMember, true);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

       /* public async Task CreateRole()
        {
            if (!(await _roleManager.RoleExistsAsync(Helper.Roles.Supervisor.ToString())))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = Helper.Roles.Supervisor.ToString() });
            }
            if (!(await _roleManager.RoleExistsAsync(Helper.Roles.Admin.ToString())))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = Helper.Roles.Admin.ToString() });

            }
            if (!(await _roleManager.RoleExistsAsync(Helper.Roles.Member.ToString())))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = Helper.Roles.Member.ToString() });
*/


                #endregion

            }
        }
    