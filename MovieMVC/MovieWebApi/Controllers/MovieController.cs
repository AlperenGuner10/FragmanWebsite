using Microsoft.AspNetCore.Mvc;
using MovieMVC.Models.Entities;
using MovieMVC.Repostiories.Concrete;

namespace MovieWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MovieController : Controller
	{
		private readonly GenericRepository<Movie> _movieRepository;
		private readonly GenericRepository<Genre> _genreRepository;
		private readonly IWebHostEnvironment _environment;

		public MovieController(
			GenericRepository<Movie> movieRepository,
			GenericRepository<Genre> genreRepository,
			IWebHostEnvironment environment)
		{
			_movieRepository = movieRepository;
			_genreRepository = genreRepository;
			_environment = environment;
		}

		// GET: api/Movie
		[HttpGet]
		public IActionResult GetMovies()
		{
			var result = _movieRepository.GetAllGenre();
			return Ok(result);
		}

		// GET: api/Movie/5
		[HttpGet("{id}")]
		public IActionResult GetMovieById(int id)
		{
			var result = _movieRepository.GetAllGenre().FirstOrDefault(x => x.MovieId == id);
			if (result == null)
				return NotFound("Movie not found.");

			return Ok(result);
		}

		// POST: api/Movie
		[HttpPost]
		public IActionResult CreateMovie([FromForm] Movie movie)
		{
			if (string.IsNullOrWhiteSpace(movie.MovieName) ||
				movie.Year < 1900 ||
				movie.Year > 2100 ||
				movie.GenreId <= 0 ||
				movie.ImageFile == null ||
				string.IsNullOrWhiteSpace(movie.TrailerUrl))
			{
				return BadRequest("Invalid movie data.");
			}

			// Save image file
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
			return Ok("Movie created successfully.");
		}

		// PUT: api/Movie/5
		[HttpPut("{id}")]
		public IActionResult UpdateMovie(int id, [FromForm] Movie movie)
		{
			var existingMovie = _movieRepository.GetById(id);
			if (existingMovie == null)
				return NotFound("Movie not found.");

			if (movie.ImageFile != null)
			{
				string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
				string uniqueFileName = Guid.NewGuid().ToString() + "_" + movie.ImageFile.FileName;
				string filePath = Path.Combine(uploadsFolder, uniqueFileName);

				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					movie.ImageFile.CopyTo(fileStream);
				}

				existingMovie.ImagePath = "/images/" + uniqueFileName;
			}

			existingMovie.MovieName = movie.MovieName;
			existingMovie.Year = movie.Year;
			existingMovie.GenreId = movie.GenreId;
			existingMovie.TrailerUrl = movie.TrailerUrl;

			_movieRepository.Update(existingMovie);
			return Ok("Movie updated successfully.");
		}

		// DELETE: api/Movie/5
		[HttpDelete("{id}")]
		public IActionResult DeleteMovie(int id)
		{
			var movie = _movieRepository.GetById(id);
			if (movie == null)
				return NotFound("Movie not found.");

			_movieRepository.Delete(movie);
			return Ok("Movie deleted successfully.");
		}
	}
}
