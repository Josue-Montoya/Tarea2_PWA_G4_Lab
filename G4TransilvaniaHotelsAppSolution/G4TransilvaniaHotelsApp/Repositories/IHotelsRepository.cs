using G4TransilvaniaHotelsApp.Models;
namespace G4TransilvaniaHotelsApp.Repositories
{
    public interface IHotelsRepository
    {
        IEnumerable<HotelsModel> GetAllHotels();

        void AddHotels(HotelsModel hotels);

        void EditHotels(HotelsModel hotels);

        void DeleteHotels(int idHotel);
    }
}
