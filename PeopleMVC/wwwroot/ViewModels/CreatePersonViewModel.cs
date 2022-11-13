using System.ComponentModel.DataAnnotations;

namespace PeopleMVC.wwwroot.ViewModels
{
    public class CreatePersonViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(13)]
        [MinLength(9)]
        public string PhoneNumber { get; set; }

        [Required]
        public string City { get; set; }
    }
}
