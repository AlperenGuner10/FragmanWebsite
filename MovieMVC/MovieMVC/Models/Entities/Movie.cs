using MovieMVC.Repostiories.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieMVC.Models.Entities
{
	public class Movie : IEntity
	{
		[Key]
		public int MovieId { get; set; }
		public string MovieName { get; set; }
		public int Year { get; set; }
		public string AciklamaFirst { get; set; }
		public string TrailerUrl { get; set; } // Fragman linki
		public string ImagePath { get; set; }
		[NotMapped]
		public IFormFile ImageFile { get; set; }
		public int GenreId { get; set; }
		public Genre Genre { get; set; }
	}
}
