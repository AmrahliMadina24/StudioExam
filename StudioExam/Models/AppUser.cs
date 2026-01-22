using Microsoft.AspNetCore.Identity;

namespace StudioExam.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
