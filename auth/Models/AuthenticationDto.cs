using System.ComponentModel.DataAnnotations;

namespace auth.Models {
    public class AuthenticationDto {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
    }   
}