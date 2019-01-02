using System.ComponentModel.DataAnnotations;

namespace CW3Blog.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
