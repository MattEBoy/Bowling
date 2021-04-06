using Bowling.Models;
using Bowling.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext _context;

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index(long? teamid, int pageNum = 1)
        {
            int pageSize = 5;
            return View(
                new IndexViewModel
                { 
                    Bowlers =
                        _context.Bowlers
                        .Where(t => t.TeamId == teamid || teamid == null)
                        .Skip(pageSize * (pageNum - 1))
                        .Take(pageSize)
                        .ToList(),
                    PageNumberingInfo = new PageNumberingInfo
                    {
                        NumItemsPerPage = pageSize,
                        CurrentPage = pageNum,
                        //use same filtering technique as above
                        TotalNumItems = _context.Bowlers
                                    .Where(t => t.TeamId == teamid || teamid == null)
                                    .ToList().Count()
                    },
                    Team = _context.Teams.Where(t => t.TeamId == teamid).Select(t => t.TeamName).FirstOrDefault() ?? ""
                    ,
                    TeamId = _context.Teams.Where(t => t.TeamId == teamid).Select(t => t.TeamId).FirstOrDefault()

                });
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
