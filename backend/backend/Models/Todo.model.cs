using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Todo
    {
        public Guid Id { get; set; }

        [Required]
        [RegularExpression("home|work|sport", ErrorMessage = "Category must be home, work, or sport.")]
        public string Category { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }

}
