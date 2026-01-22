using System.ComponentModel.DataAnnotations;

namespace StudioExam.ViewModels.EmployeeViewModels
{
    public class EmployeeUpdateVM
    {
        [Required, MaxLength(256), MinLength(3)]

        public string FullName { get; set; } = string.Empty;
        [Required]
        public IFormFile? Image { get; set; } 
        [Required]

        public int PositionId { get; set; }
    }
}
