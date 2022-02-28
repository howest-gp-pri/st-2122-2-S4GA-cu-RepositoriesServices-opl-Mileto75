using Microsoft.AspNetCore.Mvc;
using Pri.Ca.Games.Core.Interfaces.Services;
using Pri.Ca.Games.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pri.Ca.Games.Web.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        public async Task<IActionResult> Index()
        {
            var genres = await _genreService.GetGenresAsync();
            var genresIndexViewModel = new GenresIndexViewModel();
            if(genres.IsSuccess)
            {
                genresIndexViewModel.Errors = new List<string>();
                genresIndexViewModel.Genres = genres.Genres.Select(g =>
                    new BaseGenreViewModel { Id = g.Id,Name=g.Name}
                    );
                return View(genresIndexViewModel);
            }
            //we have errors
            genresIndexViewModel.Errors = genres.ValidationErrors.Select(v => v.ErrorMessage);
            return View(genresIndexViewModel);
        }
        public async Task<IActionResult> GetGenre(int id)
        {
            var genreBaseViewModel = new BaseGenreViewModel();
            var genre = await _genreService.GetGenreByIdAsync(id);
            if(genre.IsSuccess)
            {
                genreBaseViewModel.Errors = new List<string>();
                genreBaseViewModel.Name = genre.Genres.First().Name;
                genreBaseViewModel.Id = genre.Genres.First().Id;
                return View(genreBaseViewModel);
            }
            //we have errors
            genreBaseViewModel.Errors = genre.ValidationErrors.Select(v => v.ErrorMessage);
            return View(genreBaseViewModel);
        }
    }
}
