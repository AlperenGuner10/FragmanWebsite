using MovieMVC.Repostiories.Abstract;
using System.ComponentModel.DataAnnotations;

namespace MovieMVC.Models.Entities
{
	public class UserSignIn : IEntity
	{
		[Key]
		public int UserSignInId { get; set; }
		[Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz..")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Lütfen şifrenizi giriniz..")]
		public string Password { get; set; }
	}
}
