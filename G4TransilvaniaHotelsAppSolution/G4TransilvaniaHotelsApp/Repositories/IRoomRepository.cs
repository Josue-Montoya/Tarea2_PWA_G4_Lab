using G4TransilvaniaHotelsApp.Models;

namespace G4TransilvaniaHotelsApp.Repositories
{
    public interface IRoomRepository
    {
        IEnumerable<RoomModel> RoomsGetAll();

        RoomModel GetRoomById(int id);

        void AddRoom(RoomModel rooms);

        void EditRoom(RoomModel rooms);

        void DeleteRoom(int id);
    }
}
