using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BarberHouse.Models
{
    public class Date
    {
        [Key]
        public int Id { get; set; }
        public DateTime VisitDate { get; set; }

        public Date(int id, DateTime visitDate)
        {
            this.Id = id;
            this.VisitDate = visitDate;
        }
    }
}
