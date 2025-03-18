using MovieMVC.Models.Entities;

namespace MovieMVC.Repostiories.Abstract
{
	public interface IMovieService
	{
		List<Movie> GetAll();
		Movie GetById(int id);
		void Add(Movie movie);
		void Update(Movie movie);
		void Delete(Movie movie);
	}
}
