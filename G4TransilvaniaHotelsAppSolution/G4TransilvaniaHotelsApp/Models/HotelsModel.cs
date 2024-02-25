using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace G4TransilvaniaHotelsApp.Models
{
    public class HotelsModel
    {
        [Required]
        public int hotelId { get; set; }

        [DisplayName("Nombre del Hotel")]
        public string hotelName { get; set; }

        [DisplayName("Numero de Estrellas del Hotel")]
        public int hotelStars { get; set; }

        [DisplayName("Direccion del Hotel")]
        public string hotelAddress { get; set; }

        [DisplayName("Telefono del Hotel")]
        public string hotelPhone { get; set; }
    }
}
