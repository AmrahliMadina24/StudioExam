using System.ComponentModel.DataAnnotations;

namespace StudioExam.ViewModels.AccountViewModels
{
    public class LoginVM
    {
        public string UserName { get; set; } = string.Empty;
        [Required, MaxLength(256), MinLength(3), DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        [Required, MaxLength(32), MinLength(8)]
        public string Password { get; set; } = string.Empty;
       
    }
}
