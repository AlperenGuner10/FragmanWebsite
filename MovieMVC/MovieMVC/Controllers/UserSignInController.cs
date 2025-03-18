using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MovieMVC.Models.Entities;
using MovieMVC.Repostiories.Concrete;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace MovieMVC.Controllers
{
	public class UserSignInController : Controller
	{
		private readonly GenericRepository<UserRegister> _userRegisterRepository;
		public UserSignInController()
		{
			_userRegisterRepository = new GenericRepository<UserRegister>();
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(UserRegister userSignIn)
		{
			var passwordHasher = new PasswordHasher<UserRegister>();

			var user = _userRegisterRepository.GetAll()
				.FirstOrDefault(u => u.Username == userSignIn.Username);

			if (user != null)
			{
				var result = passwordHasher.VerifyHashedPassword(user, user.Password, userSignIn.Password);

				if (result == PasswordVerificationResult.Success)
				{
					var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Username),
				new Claim(ClaimTypes.Role, "User") // Varsayılan role
            };

					var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
					var principal = new ClaimsPrincipal(identity);

					HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();

					return RedirectToAction("Index", "Genre");
				}
			}

			ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı.";
			return View();
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync();
			return RedirectToAction("Index", "UserSignIn");
		}
	}
}
