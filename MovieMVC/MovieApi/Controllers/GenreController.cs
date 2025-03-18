using Microsoft.AspNetCore.Mvc;
using MovieMVC.Models.Entities;
using MovieMVC.Repostiories.Concrete;

namespace MovieApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenreController : Controller
	{		
		private readonly GenericRepository<Genre> _repository;

		public GenreController(GenericRepository<Genre> repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var genres = _repository.GetAll();
			return Ok(genres);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var genre = _repository.GetById(id);
			if (genre == null)
				return NotFound();
			return Ok(genre);
		}

		[HttpPost]
		public IActionResult Add(Genre genre)
		{
			_repository.Add(genre);
			return CreatedAtAction(nameof(GetById), new { id = genre.GenreId }, genre);
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, Genre genre)
		{
			if (id != genre.GenreId)
				return BadRequest();

			_repository.Update(genre);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var genre = _repository.GetById(id);
			if (genre == null)
				return NotFound();

			_repository.Delete(genre);
			return NoContent();
		}
	}
}
