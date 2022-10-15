using System.ComponentModel.DataAnnotations;

namespace assignment1.Models.RequestModels
{
    public class NewTaskRequestModel
    {
        public Guid UniqueId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string Title { get; set; } = null!;

        [Required]
        public bool IsCompleted { get; set; }
    }
}