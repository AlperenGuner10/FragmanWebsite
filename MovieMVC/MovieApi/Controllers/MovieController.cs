using Microsoft.AspNetCore.Mvc;
using MovieMVC.Models.Entities;
using MovieMVC.Repostiories.Concrete;

namespace MovieApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MovieController : ControllerBase
	{
		private readonly GenericRepository<Movie> _repository;

		public MovieController(GenericRepository<Movie> repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var movies = _repository.GetAllGenre().ToList();
			return Ok(movies);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var movie = _repository.GetById(id);
			if (movie == null)
				return NotFound();
			return Ok(movie);
		}

		[HttpPost]
		public IActionResult Add(Movie movie)
		{
			_repository.Add(movie);
			return CreatedAtAction(nameof(GetById), new { id = movie.MovieId }, movie);
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, Movie movie)
		{
			if (id != movie.MovieId)
				return BadRequest();

			_repository.Update(movie);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var movie = _repository.GetById(id);
			if (movie == null)
				return NotFound();

			_repository.Delete(movie);
			return NoContent();
		}
	}
}
