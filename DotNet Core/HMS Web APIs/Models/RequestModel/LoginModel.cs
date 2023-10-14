using System.ComponentModel.DataAnnotations;

namespace HMS_Web_APIs.Models.RequestModel
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
