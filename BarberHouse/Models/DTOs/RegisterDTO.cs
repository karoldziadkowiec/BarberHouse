using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BarberHouse.Models.DTOs
{
    public class RegisterDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public int GroupId { get; set; }
        public bool IsChecked { get; set; }

        public RegisterDTO(string name, string surname, string email, string password, string confirmedPassword, string phone, DateTime birthday, string address, int groupId, bool isChecked)
        {
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Password = password;
            this.ConfirmedPassword = confirmedPassword;
            this.Phone = phone;
            this.Birthday = birthday;
            this.Address = address;
            this.GroupId = groupId;
            this.IsChecked = isChecked;
        }
    }
}
