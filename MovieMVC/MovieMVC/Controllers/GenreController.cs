using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMVC.Models.Entities;
using MovieMVC.Repostiories.Concrete;

namespace MovieMVC.Controllers
{
	[Authorize]
	public class GenreController : Controller
	{
		private readonly GenericRepository<Genre> _genreRepository;
		public GenreController(GenericRepository<Genre> genreRepository)
		{
			_genreRepository = genreRepository;
		}
		[HttpGet]
		public IActionResult Index()
		{
			var result = _genreRepository.GetAll();
			return View(result);
		}
		public IActionResult Create()
		{
			ViewBag.Genres = _genreRepository.GetAll();
			return View();
		}
		[HttpPost]
		public IActionResult Create(Genre genre)
		{
			var errors = new List<string>();

			if (genre.GenreName == null)
			{
				errors.Add("GenreName is required.");
			}
			if (errors.Count > 0)
			{
				ViewBag.Errors = errors;
				ViewBag.Genres = _genreRepository.GetAll();
				return View(genre);
			}
			_genreRepository.Add(genre);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var result = _genreRepository.GetById(id);
			if (result == null)
			{
				return NotFound();
			}
			ViewBag.Genres = _genreRepository.GetAll();
			return View(result);
		}
		[HttpPost]
		public IActionResult Edit(Genre genre)
		{
			var errors = new List<string>();

			
			if (genre.GenreName == null)
			{
				errors.Add("GenreName is required.");
			}

			if (errors.Count > 0)
			{
				ViewBag.Errors = errors;
				ViewBag.Genres = _genreRepository.GetAll();
				return View(genre);
			}
			_genreRepository.Update(genre);
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int id)
		{
			var genre = _genreRepository.GetById(id);
			if (genre != null)
			{
				_genreRepository.Delete(genre);
			}

			return RedirectToAction("Index");
		}
	}
}
