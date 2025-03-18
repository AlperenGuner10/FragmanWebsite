using MovieMVC.Repostiories.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieMVC.Models.Entities
{
	[NotMapped]
	public class HomeViewModel : IEntity
	{
		public List<Movie> Movies { get; set; }
		public List<Series> Series { get; set; }
	}
}
