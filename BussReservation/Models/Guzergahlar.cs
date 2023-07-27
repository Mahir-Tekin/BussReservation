using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BussReservation.Models
{
    public class Guzergahlar
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Kalkış Yeri")]
        public string kalkis { get; set; }
        [Required]
        [Range(1,48)]
        [DisplayName("Seyahat Süresi")]
        public int SeyahatSuresi { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Varış Yeri")]
        public string varis { get; set; }
    }
}
