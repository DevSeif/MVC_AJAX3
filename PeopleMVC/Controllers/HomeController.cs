using Microsoft.AspNetCore.Mvc;
using PeopleMVC.Models;
using PeopleMVC.wwwroot.ViewModels;
using System.Diagnostics;

namespace PeopleMVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            if (PeopleViewModel.people.Count == 0)
                PeopleViewModel.FetchPeople();

            PeopleViewModel viewModel = new PeopleViewModel();
            viewModel.tempPeople = PeopleViewModel.people;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(string filterWord)
        {
            PeopleViewModel viewModel = new PeopleViewModel();

            if (filterWord == null || filterWord.Trim() == "") { return RedirectToAction("Index"); }
            
            foreach (Person person in PeopleViewModel.people)
            {
                if (person.City.Contains(filterWord) || person.Name.Contains(filterWord))
                {
                    viewModel.tempPeople.Add(person);
                }
            }
            

            return View(viewModel);
        }

        public IActionResult Delete(string id)
        {
            Person person = PeopleViewModel.people.FirstOrDefault(x => x.Id == id);
            PeopleViewModel.people.Remove(person);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                Person person = new Person(Guid.NewGuid().ToString(), model.Name, model.PhoneNumber, model.City);
                PeopleViewModel.people.Add(person);
            }
            
            return RedirectToAction("Index");
        }

    }
}