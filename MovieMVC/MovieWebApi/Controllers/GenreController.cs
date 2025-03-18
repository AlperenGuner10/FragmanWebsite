using Microsoft.AspNetCore.Mvc;
using MovieMVC.Models.Entities;
using MovieMVC.Repostiories.Concrete;

namespace MovieWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenreController : Controller
	{
		private readonly GenericRepository<Genre> _genreRepository;

		public GenreController(GenericRepository<Genre> genreRepository)
		{
			_genreRepository = genreRepository;
		}

		// GET: api/Genre
		[HttpGet]
		public IActionResult GetAllGenres()
		{
			var genres = _genreRepository.GetAll();
			return Ok(genres);
		}

		// GET: api/Genre/{id}
		[HttpGet("{id}")]
		public IActionResult GetGenreById(int id)
		{
			var genre = _genreRepository.GetById(id);
			if (genre == null)
			{
				return NotFound(new { Message = "Genre not found." });
			}
			return Ok(genre);
		}

		// POST: api/Genre
		[HttpPost]
		public IActionResult CreateGenre([FromBody] Genre genre)
		{
			if (genre == null || string.IsNullOrWhiteSpace(genre.GenreName))
			{
				return BadRequest(new { Message = "GenreName is required." });
			}

			_genreRepository.Add(genre);
			return CreatedAtAction(nameof(GetGenreById), new { id = genre.GenreId }, genre);
		}

		// PUT: api/Genre/{id}
		[HttpPut("{id}")]
		public IActionResult UpdateGenre(int id, [FromBody] Genre genre)
		{
			if (id != genre.GenreId)
			{
				return BadRequest(new { Message = "Genre ID mismatch." });
			}

			var existingGenre = _genreRepository.GetById(id);
			if (existingGenre == null)
			{
				return NotFound(new { Message = "Genre not found." });
			}

			existingGenre.GenreName = genre.GenreName;
			_genreRepository.Update(existingGenre);
			return NoContent();
		}

		// DELETE: api/Genre/{id}
		[HttpDelete("{id}")]
		public IActionResult DeleteGenre(int id)
		{
			var genre = _genreRepository.GetById(id);
			if (genre == null)
			{
				return NotFound(new { Message = "Genre not found." });
			}

			_genreRepository.Delete(genre);
			return NoContent();
		}
	}
}
