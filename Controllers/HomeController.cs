using DataModel.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Interfaces.Repositories;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        //[Inject]
        private IAppleEatersRepository Repo { get; }

        public HomeController(IAppleEatersRepository repository)
        {
            Repo = repository;
        }

        public async Task<IActionResult> Index([FromQuery]long? id = null)
        {
            IEnumerable<AppleEater> appleEaterList = new List<AppleEater>();
            if (id == null)
            {
                appleEaterList = Repo.People.ToList();
            }
            else
            {
                appleEaterList = appleEaterList.Append(await Repo.GetEater(id.Value)).ToList();
            }
            return View(appleEaterList);
        }

        [HttpGet]
        public IActionResult RegForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegForm(AppleEater user)
        {
            if (ModelState.IsValid)
            {
                if (await Repo.GetEater(user.Id) == null)
                {
                    Repo.CreateEater(user);
                }
                else
                {
                    user.AppleAmount++;
                    Repo.SaveEater(user);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
