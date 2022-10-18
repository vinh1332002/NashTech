using System.ComponentModel.DataAnnotations;

namespace assignment2.Models
{
    public class NewTaskRequestModel
    {
        private Guid uniqueid;
        public Guid UniqueId
        {
            get
            {
                if (uniqueid == Guid.Empty) uniqueid = Guid.NewGuid();
                return uniqueid;
            }
            set
            {
                uniqueid = value;
            }
        }

        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string Gender { get; set; } = null!;

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string BirthPlace { get; set; } = null!;
    }
}