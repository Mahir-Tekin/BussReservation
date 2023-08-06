using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BussReservation.Models
{
    public class Bus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirmaLogo { get; set; }
        [Required]
        public string Firma { get; set; }
        [Required]
        public string Marka { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string KoltukDuzeni { get; set; }
        [Required]
        [Range(20,80)]
        public int Koltuk { get; set; }
        public int GuzergahlarId { get; set; }
        public int KoltukAtandi { get; set; }
        public string KalkisTarihi { get; set; }
        public int Fiyat { get; set; }
    }
}
