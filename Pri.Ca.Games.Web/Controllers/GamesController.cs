using Microsoft.AspNetCore.Mvc;
using Pri.Ca.Games.Core.Interfaces.Services;
using Pri.Ca.Games.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pri.Ca.Games.Web.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService; 
        }

        public async Task<IActionResult> Index()
        {
            //use the service class to get the games
            var games = await _gameService.GetGamesAsync();
            var gamesIndexViewModel = new GamesIndexViewModel();
            gamesIndexViewModel.Games = new List<BaseGameViewModel>();
            gamesIndexViewModel.Errors = new List<string>();
            //test the IsSuccess bool
            if (games.IsSuccess == true)
            {

                gamesIndexViewModel.Games = games.Games.Select(
                    g => new BaseGameViewModel
                    { Id = g.Id, Name = g.Name }
                    );
                return View(gamesIndexViewModel);
            }
            //if we get here => error!  
            //add the validationerrors to the viewmodel
            gamesIndexViewModel.Errors = games.ValidationErrors
                .Select(ve => ve.ErrorMessage);
            return View(gamesIndexViewModel);
        }

        public async Task<IActionResult> GetGame(int id)
        {
            BaseGameViewModel baseGameViewModel = new BaseGameViewModel();
            baseGameViewModel.Errors = new List<string>();
            var game = await _gameService.GetGameByIdAsync(id);
            if (game.IsSuccess == true)
            {
                baseGameViewModel.Id = game.Games.First().Id;
                baseGameViewModel.Name = game.Games.First().Name;
                return View(baseGameViewModel);
            }
            //errors
            baseGameViewModel.Errors = game.ValidationErrors.Select(v => v.ErrorMessage);
            return View(baseGameViewModel);
        }
    }
}
