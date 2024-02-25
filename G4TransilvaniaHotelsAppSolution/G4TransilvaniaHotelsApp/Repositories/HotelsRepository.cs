using G4TransilvaniaHotelsApp.Data;
using G4TransilvaniaHotelsApp.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace G4TransilvaniaHotelsApp.Repositories
{
    public class HotelsRepository : IHotelsRepository
    {
        private readonly SqlDataAccess _dbConnection;

        public HotelsRepository(SqlDataAccess dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<HotelsModel> GetAllHotels()
        {
            List<HotelsModel> hotelsList = new List<HotelsModel>();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Hotel";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HotelsModel hotel = new HotelsModel();
                            hotel.hotelId = Convert.ToInt32(reader["hotelId"]);
                            hotel.hotelName = reader["hotelName"].ToString();
                            hotel.hotelStars = Convert.ToInt32(reader["hotelStars"]);
                            hotel.hotelAddress = reader["hotelAddress"].ToString();
                            hotel.hotelPhone = reader["hotelPhone"].ToString();
                            hotelsList.Add(hotel);

                        }
                    }
                }
            }
            return hotelsList;
        }

        public void AddHotels(HotelsModel hotels)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Hotel VALUES(@Name, @stars, @address, @phone)";
                    command.Parameters.AddWithValue("@Name", hotels.hotelName);
                    command.Parameters.AddWithValue("@stars", hotels.hotelStars);
                    command.Parameters.AddWithValue("@address", hotels.hotelAddress);
                    command.Parameters.AddWithValue("@phone", hotels.hotelPhone);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditHotels(HotelsModel hotels)
        {
			using (var connection = _dbConnection.GetConnection())
			{
				connection.Open();

				using (var command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = @"UPDATE Hotel 
											SET 
												hotelName = @name,
												hotelStars = @stars,
												hotelAddress = @address,
												hotelPhone = @phone
											WHERE 
												hotelId = @id";
					command.Parameters.AddWithValue("@Name", hotels.hotelName);
					command.Parameters.AddWithValue("@stars", hotels.hotelStars);
					command.Parameters.AddWithValue("@address", hotels.hotelAddress);
					command.Parameters.AddWithValue("@phone", hotels.hotelPhone);
                    command.Parameters.AddWithValue("@id", hotels.hotelId);
					command.CommandType = CommandType.Text;
					command.ExecuteNonQuery();
				}
			}
		}
        public void DeleteHotels(int idHotel)
        {
			using (var connection = _dbConnection.GetConnection())
			{
				connection.Open();

				using (var command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = @"DELETE FROM Hotel
											WHERE hotelId = @id";
					command.Parameters.AddWithValue("@id", idHotel);
					command.CommandType = CommandType.Text;
					command.ExecuteNonQuery();
				}
			}
		}
    }
}
