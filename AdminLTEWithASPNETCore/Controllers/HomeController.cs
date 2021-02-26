﻿using AdminLTEWithASPNETCore.Attributes;
using AdminLTEWithASPNETCore.Models;
using AdminLTEWithASPNETCore.Models.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AdminLTEWithASPNETCore.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HomeModel model = new HomeModel();
            model.Card = new Models.Components.Cards.CardModel()
            {
                Body = "This is an example of card",
                Links = new System.Collections.Generic.List<Models.Components.LinkModel>()
                {
                    new Models.Components.LinkModel() {
                        Target = "_blank",
                        Text = "PureSourceCode",
                        Url = "https://www.puresourcecode.com"
                    },
                    new Models.Components.LinkModel() {
                        Target = "",
                        Text = "Click here",
                        Url = "#"
                    }
                },
                Title = "Card test"
            };
            model.VisitorChart = new Models.Components.Charts.ChartModel()
            {
                ChartId = "visitor-chart",
                Height = 250,
                Labels = { "18th", "20th", "22nd", "24th", "26th", "28th", "30th" },
                Datasets = new System.Collections.Generic.List<Models.Components.Charts.Dataset>()
                {
                    new Models.Components.Charts.Dataset()
                    {
                        BackgroundColor = "transparent",
                        BorderColor = "#007bff",
                        PointBackgroundColor = "#007bff",
                        PointBorderColor = "#007bff",
                        Fill = false,
                        Data = new System.Collections.Generic.List<decimal>() {
                            100, 120, 170, 167, 180, 177, 160
                        }
                    },
                    new Models.Components.Charts.Dataset()
                    {
                        BackgroundColor = "transparent",
                        BorderColor = "#ced4da",
                        PointBackgroundColor = "#ced4da",
                        PointBorderColor = "#ced4da",
                        Fill = false,
                        Data = new System.Collections.Generic.List<decimal>() {
                            60, 80, 70, 67, 80, 77, 100
                        }
                    }
                }
            };
            model.SalesChart = new Models.Components.Charts.ChartModel()
            {
                ChartId = "salesChart",
                Height = 250,
                Labels = { "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" },
                Datasets = new System.Collections.Generic.List<Models.Components.Charts.Dataset>()
                {
                    new Models.Components.Charts.Dataset()
                    {
                        BackgroundColor = "#007bff",
                        BorderColor = "#007bff",
                        Data = new System.Collections.Generic.List<decimal>()
                        {
                            1000, 2000, 3000, 2500, 2700, 2500, 3000
                        }
                    },
                    new Models.Components.Charts.Dataset()
                    {
                        BackgroundColor = "#ced4da",
                        BorderColor = "#ced4da",
                        Data = new System.Collections.Generic.List<decimal>()
                        {
                            700, 1700, 2700, 2000, 1800, 1500, 2000
                        }
                    }
                }
            };

            return View("Index", model);
        }

        [Breadcrumb("Privacy")]
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