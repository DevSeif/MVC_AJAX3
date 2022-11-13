using Microsoft.AspNetCore.Mvc;
using PeopleMVC.Models;
using PeopleMVC.wwwroot.ViewModels;
using System.Net;

namespace PeopleMVC.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            PeopleViewModel viewModel = new PeopleViewModel();
            viewModel.tempPeople = PeopleViewModel.people;
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult FetchPeople()
        {
            PeopleViewModel.FetchPeople();
            PeopleViewModel viewModel = new PeopleViewModel();
            viewModel.tempPeople = PeopleViewModel.people;

            return PartialView("_PersonPartial", viewModel);
        }

        [HttpPost]
        public IActionResult ShowDetails(string id)
        {
            PeopleViewModel viewModel = new PeopleViewModel();

            foreach (Person person in PeopleViewModel.people)
            {
                if (person.Id == id.Trim())
                {
                    viewModel.tempPeople.Add(person);
                    return PartialView("_PersonPartial", viewModel);
                }
            }
            viewModel.tempPeople = PeopleViewModel.people;
            return PartialView("_PersonPartial", viewModel);
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            foreach (Person person in PeopleViewModel.people)
            {
                if (person.Id == id.Trim())
                {
                    PeopleViewModel.people.Remove(person);
                    return Json(id + " was deleted, status: " + StatusCode(200).StatusCode);
                }

            }

            return Json("Error could not delete, status: " + StatusCode(400).StatusCode);
        }

        [HttpGet]
        public IActionResult Refresh()
        {
            PeopleViewModel viewModel = new PeopleViewModel();
            viewModel.tempPeople = PeopleViewModel.people;
            return PartialView("_PersonPartial", viewModel);
        }

    }
}
