using MovieMVC.Models.Entities;

namespace MovieMVC.Repostiories.Abstract
{
	public interface ISerieMovie
	{
		List<Series> GetAll();
		Series GetById(int id);
		void Add(Series series);
		void Update(Series series);
		void Delete(Series series);
	}
}
