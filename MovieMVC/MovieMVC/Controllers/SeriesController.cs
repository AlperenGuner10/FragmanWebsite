using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMVC.Models.Entities;
using MovieMVC.Repostiories.Concrete;

namespace MovieMVC.Controllers
{
	[Authorize]
	public class SeriesController : Controller
	{
		private readonly GenericRepository<Series> _seriesRepository;
		private readonly GenericRepository<Genre> _genreRepository;
		private readonly IWebHostEnvironment _environment;
		public SeriesController(GenericRepository<Series> seriesRepository,
			GenericRepository<Genre> genreRepository,
			IWebHostEnvironment environment)
		{
			_seriesRepository = seriesRepository;
			_genreRepository = genreRepository;
			_environment = environment;
		}
		[AllowAnonymous]
		public IActionResult Index()
		{
			var result = _seriesRepository.GetAllGenreSeries();
			return View(result);
		}
		[AllowAnonymous]
		public IActionResult Details(int id)
		{
			var result = _seriesRepository.GetAllGenreSeries().FirstOrDefault(x => x.SeriesId == id);
			return View(result);
		}
		[AllowAnonymous]
		[HttpGet]
		public IActionResult SeriesIndex()
		{
			var result = _seriesRepository.GetAllGenreSeries();
			return View(result);
		}
		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.Genres = _genreRepository.GetAll();
			return View();
		}
		[HttpPost]
		public IActionResult Create(Series series)
		{
			var errors = new List<string>();

			if (string.IsNullOrWhiteSpace(series.SeriesName))
			{
				errors.Add("Serie name is required.");
			}

			if (series.Year < 1900 || series.Year > 2100)
			{
				errors.Add("Year must be between 1900 and 2100.");
			}

			if (series.GenreId <= 0)
			{
				errors.Add("Genre must be selected.");
			}

			if (series.ImageFile == null)
			{
				errors.Add("Image file is required.");
			}
			if (series.TrailerUrl == null)
			{
				errors.Add("Trailer is required.");
			}

			if (errors.Count > 0)
			{
				ViewBag.Errors = errors;
				ViewBag.Genres = _genreRepository.GetAll();
				return View(series);
			}

			// Resim dosyasını kaydetme
			if (series.ImageFile != null)
			{
				string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
				string uniqueFileName = Guid.NewGuid().ToString() + "_" + series.ImageFile.FileName;
				string filePath = Path.Combine(uploadsFolder, uniqueFileName);

				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					series.ImageFile.CopyTo(fileStream);
				}

				series.ImagePath = "/images/" + uniqueFileName;
			}

			_seriesRepository.Add(series);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var result = _seriesRepository.GetById(id);
			if (result == null)
			{
				return NotFound();
			}
			ViewBag.Genres = _genreRepository.GetAll();
			return View(result);
		}
		[HttpPost]
		public IActionResult Edit(Series series)
		{
			var errors = new List<string>();

			// Alanların kontrolü
			if (string.IsNullOrWhiteSpace(series.SeriesName))
			{
				errors.Add("Serie name is required.");
			}

			if (series.Year < 1900 || series.Year > 2100)
			{
				errors.Add("Year must be between 1900 and 2100.");
			}

			if (series.GenreId <= 0)
			{
				errors.Add("Genre must be selected.");
			}

			// Resim dosyasının kontrolü
			if (series.ImageFile == null)
			{
				errors.Add("Image file is required.");
			}
			if (series.TrailerUrl == null)
			{
				errors.Add("Trailer is required.");
			}

			if (errors.Count > 0)
			{
				ViewBag.Errors = errors;
				ViewBag.Genres = _genreRepository.GetAll();
				return View(series);
			}
			if (series.ImageFile != null)
			{
				string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
				string uniqueFileName = Guid.NewGuid().ToString() + "_" + series.ImageFile.FileName;
				string filePath = Path.Combine(uploadsFolder, uniqueFileName);

				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					series.ImageFile.CopyTo(fileStream);
				}

				series.ImagePath = "/images/" + uniqueFileName;
			}
			_seriesRepository.Update(series);
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int id)
		{
			var series = _seriesRepository.GetById(id);
			if (series != null)
			{
				_seriesRepository.Delete(series);
			}

			return RedirectToAction("Index");
		}
	}
}
