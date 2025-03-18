using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMVC.Models.Entities;
using MovieMVC.Repostiories.Concrete;

namespace MovieMVC.Controllers
{
	[Authorize]
	public class MovieController : Controller
	{
		private readonly GenericRepository<Movie> _movieRepository;
		private readonly GenericRepository<Genre> _genreRepository;
		private readonly IWebHostEnvironment _environment;
		public MovieController(GenericRepository<Movie> movieRepository,
			GenericRepository<Genre> genreRepository,
			IWebHostEnvironment environment)
		{
			_movieRepository = movieRepository;
			_genreRepository = genreRepository;
			_environment = environment;
		}
		[AllowAnonymous]
		[HttpGet]
		public IActionResult Index()
		{
			var result = _movieRepository.GetAllGenre();
			return View(result);
		}
		[AllowAnonymous]
		public IActionResult Details(int id)
		{
			var result = _movieRepository.GetAllGenre().FirstOrDefault(x=>x.MovieId == id);
			return View(result);
		}
		[AllowAnonymous]
		[HttpGet]
		public IActionResult MovieIndex()
		{
			var result = _movieRepository.GetAllGenre();
			return View(result);
		}
		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.Genres = _genreRepository.GetAll();
			return View();
		}
		[HttpPost]
		public IActionResult Create(Movie movie)
		{
			var errors = new List<string>();

			if (string.IsNullOrWhiteSpace(movie.MovieName))
			{
				errors.Add("Movie name is required.");
			}

			if (movie.Year < 1900 || movie.Year > 2100)
			{
				errors.Add("Year must be between 1900 and 2100.");
			}

			if (movie.GenreId <= 0)
			{
				errors.Add("Genre must be selected.");
			}

			if (movie.ImageFile == null)
			{
				errors.Add("Image file is required.");
			}
			if (movie.TrailerUrl == null)
			{
				errors.Add("Trailer is required.");
			}

			if (errors.Count > 0)
			{
				ViewBag.Errors = errors;
				ViewBag.Genres = _genreRepository.GetAll();
				return View(movie);
			}

			// Resim dosyasını kaydetme
			if (movie.ImageFile != null)
			{
				string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
				string uniqueFileName = Guid.NewGuid().ToString() + "_" + movie.ImageFile.FileName;
				string filePath = Path.Combine(uploadsFolder, uniqueFileName);

				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					movie.ImageFile.CopyTo(fileStream);
				}

				movie.ImagePath = "/images/" + uniqueFileName;
			}

			_movieRepository.Add(movie);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var result = _movieRepository.GetById(id);
			if (result == null)
			{
				return NotFound();
			}
			ViewBag.Genres = _genreRepository.GetAll();
			return View(result);
		}
		[HttpPost]
		public IActionResult Edit(Movie movie)
		{
			var errors = new List<string>();

			// Alanların kontrolü
			if (string.IsNullOrWhiteSpace(movie.MovieName))
			{
				errors.Add("Movie name is required.");
			}

			if (movie.Year < 1900 || movie.Year > 2100)
			{
				errors.Add("Year must be between 1900 and 2100.");
			}

			if (movie.GenreId <= 0)
			{
				errors.Add("Genre must be selected.");
			}

			// Resim dosyasının kontrolü
			if (movie.ImageFile == null)
			{
				errors.Add("Image file is required.");
			}
			if (movie.TrailerUrl == null)
			{
				errors.Add("Trailer is required.");
			}

			if (errors.Count > 0)
			{
				ViewBag.Errors = errors;
				ViewBag.Genres = _genreRepository.GetAll();
				return View(movie);
			}
			if (movie.ImageFile != null)
			{
				string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
				string uniqueFileName = Guid.NewGuid().ToString() + "_" + movie.ImageFile.FileName;
				string filePath = Path.Combine(uploadsFolder, uniqueFileName);

				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					movie.ImageFile.CopyTo(fileStream);
				}

				movie.ImagePath = "/images/" + uniqueFileName;
			}
			_movieRepository.Update(movie);
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int id)
		{
			var movie = _movieRepository.GetById(id);
			if (movie != null)
			{
				_movieRepository.Delete(movie);
			}

			return RedirectToAction("Index");
		}
	}
}
