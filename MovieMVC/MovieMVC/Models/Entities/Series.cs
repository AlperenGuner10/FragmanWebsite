using MovieMVC.Repostiories.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieMVC.Models.Entities
{
	public class Series : IEntity
	{
		[Key]
		public int SeriesId { get; set; }
		public string SeriesName { get; set; }
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
