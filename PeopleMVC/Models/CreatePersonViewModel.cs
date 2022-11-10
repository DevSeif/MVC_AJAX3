using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PeopleMVC.Models
{
    public class CreatePersonViewModel
    {
        //public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(13)]
        [MinLength(8)]
        public string PhoneNumber { get; set; }

        [Required]
        public string City { get; set; }
    }
}
