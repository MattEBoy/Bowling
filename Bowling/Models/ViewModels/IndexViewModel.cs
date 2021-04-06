using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.Models.ViewModels
{
    public class IndexViewModel
    {
        //add team ID for pagination and team name for display
        public List<Bowler> Bowlers { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        public string Team { get; set; }
        public long TeamId { get; set; }
    }
}
