using Microsoft.EntityFrameworkCore;
using MovieMVC.Models.Entities;

namespace MovieMVC.Models
{
	public class Context : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-TVGOALM\\SQLEXPRESS;Database=MovieMVC;TrustServerCertificate=true;Integrated Security=True;");
		}
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Series> Series { get; set; }
		public DbSet<HomeViewModel> HomeViewModels { get; set; }
		public DbSet<UserRegister> UserRegisters { get; set; }
		public DbSet<UserSignIn> UserSignIns { get; set; }
	}
}
