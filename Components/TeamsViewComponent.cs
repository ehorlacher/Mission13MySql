using Mission13MySql.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13MySql.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private IBowlersRepository _repo { get; set; }

        public TeamsViewComponent(IBowlersRepository temp)
        {
            _repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            //List<Team> teams = _repo.Teams.ToList();

            var teams = _repo.Bowlers
                .Select(x => x.TeamID)
                .Distinct()
                .OrderBy(x => x);

            return View(teams);
        }
    }
}
