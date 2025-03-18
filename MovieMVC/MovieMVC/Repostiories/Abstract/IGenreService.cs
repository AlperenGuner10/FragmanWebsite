using MovieMVC.Models.Entities;

namespace MovieMVC.Repostiories.Abstract
{
	public interface IGenreService
	{
		List<Genre> GetAll();
		Genre GetById(int id);
		void Add(Genre genre);
		void Update(Genre genre);
		void Delete(Genre genre);
	}
}
