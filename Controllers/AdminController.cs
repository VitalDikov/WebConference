using System.Dynamic;
using IntershipProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IntershipProject.Domain;
using Microsoft.AspNetCore.Authorization;

namespace IntershipProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly AppDbContext _dbContext;

        public AdminController(UserManager<AppUser> userManager,
                                IPasswordHasher<AppUser> passwordHasher,
                                AppDbContext dbContext)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _dbContext = dbContext;
        }

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(UserModel user)
        {
            if (ModelState.IsValid) {
                AppUser appUser = new AppUser {
                    UserName = user.UserName,
                    FullName = user.FullName,
                    Email = user.EMail
                };
                IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded) {
                    return RedirectToAction("Index");
                } else {
                    foreach (var error in result.Errors) {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(user);
        }

        public async Task<IActionResult> Update(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null) {
                return View(user);
            } else {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, string email, string password, string phoneNumber,
                                                        string userName, string fullName)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null) {
                if (!string.IsNullOrEmpty(email)) {
                    user.Email = email;
                } else {
                    ModelState.AddModelError("", "Email cannot be empty!");
                }

                if (!string.IsNullOrEmpty(password)) {
                    user.PasswordHash = _passwordHasher.HashPassword(user, password);
                } else {
                    ModelState.AddModelError("", "Password cannot be empty!");
                }

                user.UserName = userName;
                user.FullName = fullName;
                user.PhoneNumber = phoneNumber;

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password)) {
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded) {
                        return RedirectToAction("Index");
                    } else {
                        Errors(result);
                    }
                }
            } else {
                ModelState.AddModelError("", "User is not found!");
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null) {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded) {
                    return RedirectToAction("Index");
                } else {
                    Errors(result);
                }
            } else {
                ModelState.AddModelError("", "User is not found!");
            }
            return View("Index", _userManager.Users);
        }

        [HttpPost]
        public async Task<IActionResult> AddLog()
        {
            return View("Index", _userManager.Users);
        }

        private void Errors(IdentityResult result)
        {
            foreach (var error in result.Errors) {
                ModelState.AddModelError("", error.Description);
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.Users = _userManager.Users;
            model.Logs = _dbContext.Logging;
            return View(model);
        }
    }
}
