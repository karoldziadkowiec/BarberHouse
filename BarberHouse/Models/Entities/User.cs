using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BarberHouse.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Surname { get; set; }
        [MaxLength(30)]
        public string Email { get; set; }
        [MaxLength(30)]
        public string Password { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        [MaxLength(40)]
        public string Address { get; set; }
        [ForeignKey("Group")]
        public int GroupId { get; set; }

        public User(int id, string name, string surname, string email, string password, string phone, DateTime birthday, string address, int groupId)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Password = password;
            this.Phone = phone;
            this.Birthday = birthday;
            this.Address = address;
            this.GroupId = groupId;
        }

        public User(string name, string surname, string email, string password, string phone, DateTime birthday, string address, int groupId)
        {
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Password = password;
            this.Phone = phone;
            this.Birthday = birthday;
            this.Address = address;
            this.GroupId = groupId;
        }
    }
}
