using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

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
        [AllowNull]
        public string YolcuId { get; set; }
    }
}
