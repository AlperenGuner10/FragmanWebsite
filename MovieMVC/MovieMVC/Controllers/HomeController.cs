using Microsoft.AspNetCore.Mvc;
using MovieMVC.Models.Entities;
using MovieMVC.Repostiories.Concrete;

namespace MovieMVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly GenericRepository<Movie> _movieRepository;
		private readonly GenericRepository<Series> _seriesRepository;
		public HomeController(GenericRepository<Movie> movieRepository, GenericRepository<Series> seriesRepository)
		{
			_movieRepository = movieRepository;
			_seriesRepository=seriesRepository;
		}
		public IActionResult Index()
		{
			var movies = _movieRepository.GetAll();
			var series = _seriesRepository.GetAll();

			var viewModel = new HomeViewModel
			{
				Movies = movies,
				Series = series
			};

			return View(viewModel);
		}
	}
}
