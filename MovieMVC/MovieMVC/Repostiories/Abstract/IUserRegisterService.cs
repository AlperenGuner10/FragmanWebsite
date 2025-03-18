using MovieMVC.Models.Entities;

namespace MovieMVC.Repostiories.Abstract
{
	public interface IUserRegisterService
	{
		List<UserRegister> GetAll();
		UserRegister GetById(int id);
		void Add(UserRegister userRegister);
		void Update(UserRegister userRegister);
		void Delete(UserRegister userRegister);
	}
}
