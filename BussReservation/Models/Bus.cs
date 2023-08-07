using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BussReservation.Models
{
    public class Bus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Logo Ekleyiniz")]
        public string FirmaLogo { get; set; }
        [Required]
        public string Firma { get; set; }
        [Required]
        public string Marka { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        [Display(Name = "Koltuk Düzeni Seçiniz")]
        public string KoltukDuzeni { get; set; }
        [Required]
        [Range(20,80)]
        [Display(Name = "Koltuk Sayısı: ")]
        public int Koltuk { get; set; }
        public int GuzergahlarId { get; set; } 
        public int KoltukAtandi { get; set; }
        [Display(Name ="Kalkış Tarihi")]
        public DateTime KalkisTarihi { get; set; }
        public int Fiyat { get; set; }
    }
}
