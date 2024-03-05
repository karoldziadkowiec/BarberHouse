using System.ComponentModel.DataAnnotations;

namespace BarberHouse.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }

        public Group(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
