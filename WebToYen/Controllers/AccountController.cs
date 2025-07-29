using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebToYen.Models;
using WebToYen.Models.ViewModels;

namespace WebToYen.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl});
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVm)
        {

            if (ModelState.IsValid)
            {
                // Tìm user theo Email
                var user = await _userManager.FindByEmailAsync(loginVm.Email);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(
                        user.UserName, // lấy username từ user
                        loginVm.Password,
                        false,
                        false
                    );

                    if (result.Succeeded)
                    {
                        return Redirect(loginVm.ReturnUrl ?? "/");
                    }
                }
                ModelState.AddModelError("", "Email hoặc Mật Khẩu không đúng.");
            }

            return View(loginVm);
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Register(User user)
        {

            if (ModelState.IsValid)
            {
                AppUser newUser = new AppUser { UserName = user.UserName, Email = user.Email };
                IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);

                if (result.Succeeded)
                {
                    TempData["success"] = "Tạo Tài Khoản Thành Công.";
                    return Redirect("/Account/login"); // tra ve dau . Hien thi
                }
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }
            }

            return View(user);
        }

        public async Task<IActionResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

    }
}
