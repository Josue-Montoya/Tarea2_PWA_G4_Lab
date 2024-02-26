using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace G4TransilvaniaHotelsApp.Models
{
    public class RoomModel
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [DisplayName("RoomNumber")]
        public string roomNumber { get; set; }

        [Required]
        [DisplayName("RoomType")]
        public string roomType { get; set; }

        [Required]
        [DisplayName("RoomPrice")]
        public decimal roomPrice { get; set; }

        [Required]
        [DisplayName("HotelId")]
        public int HotelId { get; set; }
    }
}
