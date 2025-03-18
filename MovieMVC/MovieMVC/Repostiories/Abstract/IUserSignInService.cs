using MovieMVC.Models.Entities;

namespace MovieMVC.Repostiories.Abstract
{
	public interface IUserSignInService
	{
		List<UserSignIn> GetAll();
		UserSignIn GetById(int id);
		void Add(UserSignIn userSignIn);
		void Update(UserSignIn userSignIn);
		void Delete(UserSignIn userSignIn);
	}
}
