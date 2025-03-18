using MovieMVC.Repostiories.Abstract;
using System.ComponentModel.DataAnnotations;

namespace MovieMVC.Models.Entities
{
	public class UserRegister : IEntity
	{
		[Key]
		public int UserRegisterId { get; set; }
		[Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz.")]
		[Compare("Password", ErrorMessage = "Lütfen şifrelerinizi aynı giriniz")]
		public string? ConfirmPassword { get; set; }
	}
}
