using System.ComponentModel.DataAnnotations;

namespace BarberHouse.Models.DTOs
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginDTO(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}
