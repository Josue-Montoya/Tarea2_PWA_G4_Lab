using G4TransilvaniaHotelsApp.Data;
using System.Data;
using System.Data.SqlClient;
using G4TransilvaniaHotelsApp.Models;

namespace G4TransilvaniaHotelsApp.Repositories
{
    public class RoomRepository : IRoomRepository
    {

        private readonly SqlDataAccess _dbConnection;

        public RoomRepository(SqlDataAccess dbConnection)
        {
            _dbConnection = dbConnection;  
           
        }

        public IEnumerable<RoomModel> RoomsGetAll()
        {
            List<RoomModel> roomList = new List<RoomModel>();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"Select roomId, roomNumber, roomType, roomPrice, hotelId 
                                            From Room";

                    command.CommandType = System.Data.CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RoomModel room = new RoomModel();
                            room.ID = Convert.ToInt32(reader["roomId"]);
                            room.roomNumber = reader["roomNumber"].ToString();
                            room.roomType = reader["roomType"].ToString();
                            room.roomPrice = Convert.ToDecimal(reader["roomPrice"]);
                            room.HotelId = Convert.ToInt32(reader["hotelId"]);

                            roomList.Add(room);
                        }
                    }
                }
            }

            return roomList;
            
        }

        public RoomModel GetRoomById(int id)
        {
            RoomModel room = new RoomModel();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using(var command = new SqlCommand()) 
                {
                    command.Connection = connection;
                    command.CommandText = @"Select roomId, roomNumber, roomType, roomPrice, hotelId 
                                            From Room Where roomId = @roomId";

                    command.Parameters.AddWithValue("@roomId", id);
                    command.CommandType = CommandType.Text;

                    using(var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            room.ID = Convert.ToInt32(reader["roomId"]);
                            room.roomNumber = reader["roomNumber"].ToString();
                            room.roomType = reader["roomType"].ToString();
                            room.roomPrice = Convert.ToDecimal(reader["roomPrice"]);
                            room.HotelId = Convert.ToInt32(reader["hotelId"]);
                        }
                    }
                }
            }

            return room;

        }

        public void AddRoom(RoomModel rooms)
        {   
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"Insert Into Room Values
                                            (@roomNumber, @roomType, @roomPrice, @hotelId)";

                    command.Parameters.AddWithValue("@roomNumber", rooms.roomNumber);
                    command.Parameters.AddWithValue("@roomType", rooms.roomType);
                    command.Parameters.AddWithValue("@roomPrice", rooms.roomPrice);
                    command.Parameters.AddWithValue("@hotelId", rooms.HotelId);

                    command.CommandType= CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }

        }

        public void EditRoom(RoomModel rooms)
        {
            using(var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"Update Room Set
                                            roomNumber = @roomNumber,
                                            roomType = @roomType,
                                            roomPrice = @roomPrice,
                                            hotelId = @hotelId
                                            Where roomId = @roomId";

                    command.Parameters.AddWithValue("@roomNumber", rooms.roomNumber);
                    command.Parameters.AddWithValue("@roomType", rooms.roomType);
                    command.Parameters.AddWithValue("@roomPrice", rooms.roomPrice);
                    command.Parameters.AddWithValue("@hotelId", rooms.HotelId);
                    command.Parameters.AddWithValue("@roomId", rooms.ID);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteRoom(int id)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM Room
											WHERE roomId = @roomId";
                    command.Parameters.AddWithValue("@roomId", id);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
