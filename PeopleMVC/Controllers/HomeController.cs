using Microsoft.AspNetCore.Mvc;
using PeopleMVC.Models;
using System.Diagnostics;

namespace PeopleMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(PeopleViewModel.people);
        }

        [HttpGet]
        public IActionResult Index(string filterWord)
        {

            List<Person> filterList = new List<Person>();

            if (filterWord == null || filterWord.Trim() == "") { return View(PeopleViewModel.people); }

            foreach (Person person in PeopleViewModel.people)
            {
                if (person.City.Contains(filterWord) || person.Name.Contains(filterWord))
                {
                    filterList.Add(person);
                }
            }


            return View(filterList);
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                PeopleViewModel.people.Add(new Person(Guid.NewGuid().ToString(), model.Name, model.PhoneNumber, model.City));   
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult PeoplePartial()
        {
            return PartialView("_People", PeopleViewModel.people);
        }

    }
}