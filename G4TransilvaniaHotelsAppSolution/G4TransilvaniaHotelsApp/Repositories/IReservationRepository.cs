using G4TransilvaniaHotelsApp.Models;

namespace G4TransilvaniaHotelsApp.Repositories
{
    public interface IReservationRepository
    {
        IEnumerable<ReservationModel> GetAllReservations();

        ReservationModel GetReservationById(int id);

        void AddReservation(ReservationModel reservation);

        void EditReservation(ReservationModel reservation);

        void DeleteReservation(int id);
    }
}
