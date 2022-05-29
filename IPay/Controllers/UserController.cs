using BusinessManager;
using DataAccess.DataRepository;
using IPay.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Security.Claims;

namespace IPay.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly UserManager userManager = null;

        public UserController(IRepository repository)
        {
            userManager=new UserManager(repository);
        }

        [HttpGet("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost("signup")]
        public IActionResult SignUp(UserRequest userRequest)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = userManager.CreateUser(userRequest);
            }
           
            return View();
        }

        [HttpGet("login")]
        public IActionResult LogIn()
        
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn(LoginRequest loginRequest)
        {
            LoginResponse loginResponse= userManager.Login(loginRequest);
            if (loginResponse.HasError)
            {
                ViewBag.Error = "Invalid Credentials";
                return View();
            }

            else
            {
                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                identity.AddClaim(new Claim(AppCLaimTypes.id, loginResponse.Id.ToString()));
                identity.AddClaim(new Claim(AppCLaimTypes.name, loginResponse.Name));
                identity.AddClaim(new Claim(AppCLaimTypes.email, loginResponse.Email));

                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                {
                    IsPersistent = loginRequest.RememberMe,
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.AddSeconds(30)
                });
                
                return RedirectToAction("privacy","home");
            }
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
