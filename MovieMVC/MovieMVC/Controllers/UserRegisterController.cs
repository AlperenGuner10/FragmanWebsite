using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieMVC.Models.Entities;
using MovieMVC.Repostiories.Concrete;

namespace MovieMVC.Controllers
{
	public class UserRegisterController : Controller
	{
		private readonly GenericRepository<UserRegister> _userRegisterRepository;
		private readonly GenericRepository<UserSignIn> _userSignInRepository;

		public UserRegisterController()
		{
			_userRegisterRepository = new GenericRepository<UserRegister>();
			_userSignInRepository = new GenericRepository<UserSignIn>();
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(UserRegister userRegister)
		{
			if (!ModelState.IsValid)
			{
				return View(userRegister);
			}

			// Kullanıcı adı kontrolü
			var existingUser = _userRegisterRepository.GetAll().FirstOrDefault(u => u.Username == userRegister.Username);
			if (existingUser != null)
			{
				ModelState.AddModelError("Username", "Bu kullanıcı adı zaten alınmış.");
				return View(userRegister);
			}

			// Şifre doğrulama
			var passwordValid = userRegister.Password.Any(char.IsLower) &&
								userRegister.Password.Any(char.IsUpper) &&
								userRegister.Password.Any(char.IsDigit) &&
								userRegister.Password.Length >= 6;

			if (!passwordValid)
			{
				ModelState.AddModelError("Password", "Şifre en az bir küçük harf, bir büyük harf, bir rakam içermeli ve 6 karakterden uzun olmalıdır.");
				return View(userRegister);
			}

			if (userRegister.Password != userRegister.ConfirmPassword)
			{
				ModelState.AddModelError("ConfirmPassword", "Şifreler eşleşmiyor.");
				return View(userRegister);
			}

			var passwordHasher = new PasswordHasher<UserRegister>();
			userRegister.Password = passwordHasher.HashPassword(userRegister, userRegister.Password);
			userRegister.ConfirmPassword = passwordHasher.HashPassword(userRegister, userRegister.ConfirmPassword);
			_userRegisterRepository.Add(userRegister);

			var userSignIn = new UserSignIn
			{
				Username = userRegister.Username,
				Password = userRegister.Password
			};

			_userSignInRepository.Add(userSignIn);
			return RedirectToAction("Index", "UserSignIn");
		}
	}
}
