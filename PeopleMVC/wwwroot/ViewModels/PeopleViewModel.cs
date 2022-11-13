using PeopleMVC.Models;

namespace PeopleMVC.wwwroot.ViewModels
{
    public class PeopleViewModel
    {
        static public List<Person> people = new List<Person>();

        public List<Person> tempPeople = new List<Person>();

        public static void FetchPeople()
        {
            people.Add(new Person(Guid.NewGuid().ToString(), "Olof Olofsson", "0733456028", "Göteborg"));
            people.Add(new Person(Guid.NewGuid().ToString(), "Per Persson", "0722456128", "Stockholm"));
            people.Add(new Person(Guid.NewGuid().ToString(), "Anders Andersson", "0736426028", "Malmö"));
            people.Add(new Person(Guid.NewGuid().ToString(), "Rolf Rolfsson", "0733456843", "Borås"));
            people.Add(new Person(Guid.NewGuid().ToString(), "Björn Björnsson", "0733444028", "Göteborg"));
        }

    }
}
