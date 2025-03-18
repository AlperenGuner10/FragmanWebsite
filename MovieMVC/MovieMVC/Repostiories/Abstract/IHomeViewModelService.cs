using MovieMVC.Models.Entities;

namespace MovieMVC.Repostiories.Abstract
{
	public interface IHomeViewModelService
	{
		List<HomeViewModel> GetAll();
		HomeViewModel GetById(int id);
		void Add(HomeViewModel homeViewModel);
		void Update(HomeViewModel homeViewModel);
		void Delete(HomeViewModel homeViewModel);
	}
}
