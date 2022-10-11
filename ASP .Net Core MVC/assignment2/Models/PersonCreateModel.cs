using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace assignment2.Models
{
    public class PersonCreateModel
    {
        [DisplayName("First Name")]
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(10)]
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? PhoneNumber { get; set; }

        public string? BirthPlace { get; set; }
    }
}