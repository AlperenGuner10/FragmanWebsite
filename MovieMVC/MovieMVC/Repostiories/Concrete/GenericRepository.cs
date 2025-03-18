using Microsoft.EntityFrameworkCore;
using MovieMVC.Models;
using MovieMVC.Models.Entities;
using MovieMVC.Repostiories.Abstract;

namespace MovieMVC.Repostiories.Concrete
{
	public class GenericRepository<T> : IGenericService<T> where T : class, IEntity
	{
		Context _context = new();
		public void Add(T item)
		{
			_context.Add(item);
			_context.SaveChanges();
		}

		public void Delete(T item)
		{
			_context.Remove(item);
			_context.SaveChanges();
		}

		public List<T> GetAll()
		{
			return _context.Set<T>().ToList();
		}
		public IQueryable<Movie> GetAllGenre()
		{
			return _context.Movies.Include(x => x.Genre); 
		}
		public IQueryable<Series> GetAllGenreSeries()
		{
			return _context.Series.Include(x => x.Genre);
		}

		public T GetById(int id)
		{
			return _context.Set<T>().Find(id);
		}

		public void Update(T item)
		{
			_context.Update(item);
			_context.SaveChanges();
		}
	}
}
