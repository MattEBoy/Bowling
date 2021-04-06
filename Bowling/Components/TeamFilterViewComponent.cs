using Bowling.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.Components
{
    public class TeamFilterViewComponent :ViewComponent
    {
        private BowlingLeagueContext _context;

        public TeamFilterViewComponent(BowlingLeagueContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.Teams
                .Distinct()
                .OrderBy(t => t).ToList());
        }
        

    }
}
