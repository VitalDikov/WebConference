using IntershipProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using IntershipProject.Domain;
using Microsoft.EntityFrameworkCore;
using Webcam.Models;

namespace IntershipProject.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly Identificator ID;

        private readonly AppDbContext _dbContext;

        public AccountController(UserManager<AppUser> userMgr, SignInManager<AppUser> signinMgr, 
            AppDbContext dbContext, RoleManager<IdentityRole> roleManager,
            IPasswordHasher<AppUser> passwordHasher)
        {
            _userManager = userMgr;
            _signInManager = signinMgr;
            _dbContext = dbContext;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
            ID = new Identificator(_userManager);
        }

        [AllowAnonymous]
        public IActionResult Register(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new UserModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserModel user)
        {
            if (ModelState.IsValid) {
                AppUser appUser = new AppUser {
                    UserName = user.UserName,
                    FullName = user.FullName,
                    Email = user.EMail,
                    PictureUri = user.PictureUri
                };
                IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded) {
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors) {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(user);
        }

        [AllowAnonymous]
        public IActionResult LoginByBiometrics()
        {
            return View(new BiometricLoginView());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginByBiometrics(BiometricLoginView model)
        {
            AppUser user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null) {
                await _signInManager.SignOutAsync();
                Result result = ID.ComparePic(user.PictureUri, model.PictureUri);
                if (result == Result.BasePictureBroken) {
                    ModelState.AddModelError("", "Base Picture is Broken");
                } else if (result == Result.NoFace) {
                    ModelState.AddModelError("", "Error While Face Recognition. Take a new Picture, please");
                } else if (result == Result.Fail) {
                    ModelState.AddModelError("", "An attempt to log in as another user");
                } else if (result == Result.Success) {
                    await _signInManager.SignInAsync(user, false);
                    AddLog(user.UserName);
                    return RedirectToAction("Index", "Blockchain");
                    //return RedirectToAction("Index", "Account");
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            AppUser user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null) {
                await _signInManager.SignOutAsync();
                var result =
                    await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                if (result.Succeeded) {
                    //ADMIN
                    //IdentityResult result1 = await _userManager.AddToRoleAsync(user, "Admin");
                    //if (result1.Succeeded) {
                    //    return RedirectToAction("Index", "Home");
                    //} else {
                    //    ModelState.AddModelError("", "GG!");
                    //}
                    //ADMIN
                    AddLog(user.UserName);
                    return RedirectToAction("Index", "Blockchain");
                    //return RedirectToAction("Index", "Account");
                }
                ModelState.AddModelError("", "Wrong username or password!");
            }
            return View(model);
        }

        [Authorize]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            FormattableString q = FormattableStringFactory.Create("truncate table Logging;");
            await _dbContext.Database.ExecuteSqlInterpolatedAsync(q);
            AppUser user = await _userManager.GetUserAsync(HttpContext.User);
            return View(user);
        }

        private void AddLog(string username)
        {
            LogModel log = new LogModel { Username = username, Timestamp = DateTime.Now};
            _dbContext.Logging.Add(log);
            _dbContext.SaveChanges();
        }

        // Help methods

        private async void AddRole(string roleName)
        {
            await _roleManager.CreateAsync(new IdentityRole(roleName));
        }

        private async void AddAdmin(AppUser user)
        {
            // ADMIN
            IdentityResult result = await _userManager.AddToRoleAsync(user, "Admin");
            //if (result.Succeeded) {
            //    return RedirectToAction("Index", "Home");
            //} else {
            //    Errors(result);
            //}
            // ADMIN

            //ADMIN
            //IdentityResult result1 = await _userManager.AddToRoleAsync(user, "Admin");
            //if (result1.Succeeded) {
            //    return RedirectToAction("Index", "Home");
            //} else {
            //    ModelState.AddModelError("", "GG!");
            //}
            //ADMIN
        }
    }
}
