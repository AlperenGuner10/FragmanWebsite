using Microsoft.AspNetCore.Mvc;
using MovieMVC.Models.Entities;
using MovieMVC.Repostiories.Concrete;

namespace MovieApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SeriesController : Controller
	{
		private readonly GenericRepository<Series> _repository;

		public SeriesController(GenericRepository<Series> repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var movies = _repository.GetAllGenreSeries().ToList();
			return Ok(movies);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var series = _repository.GetById(id);
			if (series == null)
				return NotFound();
			return Ok(series);
		}

		[HttpPost]
		public IActionResult Add(Series series)
		{
			_repository.Add(series);
			return CreatedAtAction(nameof(GetById), new { id = series.SeriesId }, series);
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, Series series)
		{
			if (id != series.SeriesId)
				return BadRequest();

			_repository.Update(series);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var series = _repository.GetById(id);
			if (series == null)
				return NotFound();

			_repository.Delete(series);
			return NoContent();
		}
	}
}
