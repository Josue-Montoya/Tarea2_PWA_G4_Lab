using System.ComponentModel;

namespace G4TransilvaniaHotelsApp.Models
{
    public class RoomModel
    {
        public int ID { get; set; }

        [DisplayName("RoomNumber")]
        public string roomNumber { get; set; }

        [DisplayName("RoomType")]
        public string roomType { get; set; }

        [DisplayName("RoomPrice")]
        public decimal roomPrice { get; set; }

        [DisplayName("HotelId")]
        public int HotelId { get; set; }
    }
}
