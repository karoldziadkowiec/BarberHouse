using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BarberHouse.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Description { get; set; }
        public double Value { get; set; }

        public Service(int id, string name, string description, double value)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Value = value;
        }
    }
}
