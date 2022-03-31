using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13MySql.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13MySql.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository _repo { get; set; }

        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
        }

        //home page
        public IActionResult Index()
        {
            var blah = _repo.Bowlers
                .ToList();

            return View(blah);
        }

        //filter
        public IActionResult Team(int teamid)
        {
            var team = _repo.Bowlers
                 .ToList();
            ViewBag.Team = teamid;

            return View(team);
        }


        //the form
        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form(Bowler b)
        {
            if (ModelState.IsValid)
            {
                if (b.BowlerID == 0)
                {
                    _repo.CreateBowler(b);
                    return RedirectToAction("Confirmation");
                }
                else
                {
                    _repo.SaveBowler(b);
                    return View("Confirmation");
                }
            }
            else
            {
                return View();
            }
        }

        //edit
        public IActionResult Edit(int bowlerid)
        {
            var bowler = _repo.Bowlers
                 .Single(x => x.BowlerID == bowlerid);


            return View("Form", bowler);
        }


        //delete
        public IActionResult Delete(int bowlerid)
        {
            var bowler = _repo.Bowlers
                 .Single(x => x.BowlerID == bowlerid);
            _repo.DeleteBowler(bowler);

            return RedirectToAction("Index");
        }
        public IActionResult Confirmation() => View();

    }
}
