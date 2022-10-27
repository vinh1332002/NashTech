using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace assignment3.Models
{
    public class PersonEditModel
    {
        [Required, DisplayName("First Name")]
        public string? FirstName { get; set; }

        [Required, DisplayName("Last Name")]
        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? BirthPlace { get; set; }

        //public int Index {get; set;}
    }
}