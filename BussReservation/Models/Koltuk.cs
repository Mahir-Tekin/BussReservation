using System.ComponentModel.DataAnnotations;

namespace BussReservation.Models
{
    public class Koltuk
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BusId { get; set; }
        [Required]
        public int KoltukNo { get; set; }
        public int YolcuId { get; set; }
    }
}
