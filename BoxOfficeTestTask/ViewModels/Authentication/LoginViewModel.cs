using System.ComponentModel.DataAnnotations;

namespace BoxOfficeTestTask.ViewModels.Authentication
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
