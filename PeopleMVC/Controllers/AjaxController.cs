using Microsoft.AspNetCore.Mvc;
using PeopleMVC.Models;



namespace PeopleMVC.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            return View(PeopleViewModel.people);
        }

        [HttpGet]
        public IActionResult FetchPeople()
        {
            PeopleViewModel.FetchPeople();
            return PartialView("_PeoplePartial", PeopleViewModel.people);
        }

        [HttpPost]
        public IActionResult ShowDetails(string id)
        {
            foreach (Person person in PeopleViewModel.people)
            {
                if (person.Id == id.Trim())
                {
                    //var json = JsonConvert.SerializeObject(person);
                    return PartialView("_PersonPartial", person);
                }
            }
            return PartialView("_PeoplePartial", PeopleViewModel.people);
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            foreach (Person person in PeopleViewModel.people)
            {
                if (person.Id == id.Trim())
                {
                    PeopleViewModel.people.Remove(person);
                    return Json(id + " was deleted");
                }

            }

            return Json("Error could not delete");
        }

        [HttpGet]
        public IActionResult Refresh()
        {
            return PartialView("_PeoplePartial", PeopleViewModel.people);
        }

    }
}
