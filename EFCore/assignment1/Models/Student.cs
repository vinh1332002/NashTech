using System.ComponentModel.DataAnnotations;

namespace assignment1.Models
{
    public class Student : BaseEntity<int>
    {
        [Required]
        public string? FirstName { set; get; }
        [Required]
        public string? LastName { set; get; }
        [Required]
        public string? City { set; get; }
        [Required]
        public string? State { set; get; }
    }
}