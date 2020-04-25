using System.ComponentModel.DataAnnotations;

namespace borsvarlden.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(32)]
        public string Login { get; set; }
        
        [Required]
        [MaxLength(32)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public bool RememberMe { get; set; }
    }
}