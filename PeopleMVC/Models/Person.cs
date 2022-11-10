using System.ComponentModel.DataAnnotations;

namespace PeopleMVC.Models
{
    public class Person
    {
        public string Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public Person(string id, string name, string phoneNumber, string city)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            City = city;
        }
    }
}
