using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BarberHouse.Models
{
    public class Visit
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("User")]
        public int BarberId { get; set; }
        [ForeignKey("Date")]
        public int DateId { get; set; }
        [ForeignKey("Service")]
        public int ServiceId { get; set; }

        public Visit(int id, int userId, int barberId, int dateId, int serviceId)
        {
            this.Id = id;
            this.UserId = userId;
            this.BarberId = barberId;
            this.DateId = dateId;
            this.ServiceId = serviceId;
        }
    }
}
