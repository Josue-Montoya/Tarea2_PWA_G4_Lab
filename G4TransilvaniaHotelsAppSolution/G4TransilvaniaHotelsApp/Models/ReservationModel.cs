namespace G4TransilvaniaHotelsApp.Models
{
    public class ReservationModel
    {
        public int reservationId { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public int roomId { get; set; }

        public int clientId { get; set; }

        public decimal reservationPrice { get; set; }    

        public string paidReservation { get; set; }
    }
}
