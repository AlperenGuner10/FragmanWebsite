using MovieMVC.Repostiories.Abstract;
using System.ComponentModel.DataAnnotations;

namespace MovieMVC.Models.Entities
{
	public class Genre : IEntity
	{
		[Key] 
		public int GenreId { get; set; }
		public string GenreName { get; set; }
		public List<Movie> Movies { get; set; } = new List<Movie>();
	}
}
