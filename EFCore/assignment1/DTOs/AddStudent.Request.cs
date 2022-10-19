using System.ComponentModel.DataAnnotations;

namespace assignment1.DTOs
{
    public class AddStudentRequest
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