﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pri.Ca.Games.Core.Interfaces.Repositories;
using Pri.Ca.Games.Core.Interfaces.Services;
using Pri.Ca.Games.Web.Models;
using Pri.Ca.Games.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pri.Ca.Games.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IGameRepository _gameRepository;
        private readonly IGameService _gameService;

        public HomeController(ILogger<HomeController> logger,
            IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
