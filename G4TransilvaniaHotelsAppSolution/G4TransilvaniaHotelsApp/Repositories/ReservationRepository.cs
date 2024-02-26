using G4TransilvaniaHotelsApp.Data;
using G4TransilvaniaHotelsApp.Models;
using System.Data;
using System.Data.SqlClient;

namespace G4TransilvaniaHotelsApp.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly SqlDataAccess _dbConnection;

        public ReservationRepository(SqlDataAccess dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<ReservationModel> GetAllReservations()
        {
            List<ReservationModel> reservationList = new List<ReservationModel>();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"Select reservationId, startDate, endDate, roomId, clientId, reservationPrice, paidReservation
                                            From Reservation";

                    command.CommandType = System.Data.CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ReservationModel reservation = new ReservationModel();
                            reservation.reservationId = Convert.ToInt32(reader["reservationId"]);
                            reservation.startDate = Convert.ToDateTime(reader["startDate"]);
                            reservation.endDate = Convert.ToDateTime(reader["endDate"]);
                            reservation.roomId = Convert.ToInt32(reader["roomId"]);
                            reservation.clientId = Convert.ToInt32(reader["clientId"]);
                            reservation.reservationPrice = Convert.ToDecimal(reader["reservationPrice"]);
                            reservation.paidReservation = reader["paidReservation"].ToString();

                            reservationList.Add(reservation);
                        }
                    }
                }
            }

            return reservationList;
        }

        public ReservationModel GetReservationById(int id)
        {
            ReservationModel reservation = new ReservationModel();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"Select reservationId, startDate, endDate, roomId, clientId, reservationPrice, paidReservation
                                            From Reservation Where reservationId = @reservationId";

                    command.Parameters.AddWithValue("@reservationId", id);
                    command.CommandType = System.Data.CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reservation.reservationId = Convert.ToInt32(reader["reservationId"]);
                            reservation.startDate = Convert.ToDateTime(reader["startDate"]);
                            reservation.endDate = Convert.ToDateTime(reader["endDate"]);
                            reservation.roomId = Convert.ToInt32(reader["roomId"]);
                            reservation.clientId = Convert.ToInt32(reader["clientId"]);
                            reservation.reservationPrice = Convert.ToDecimal(reader["reservationPrice"]);
                            reservation.paidReservation = reader["paidReservation"].ToString();
                        }
                    }
                }
            }

            return reservation;

        }
        public void AddReservation(ReservationModel reservation)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Reservation (startDate, endDate, roomId, clientId, reservationPrice, paidReservation)
                                VALUES (@startDate, @endDate, @roomId, @clientId, @reservationPrice, @paidReservation)";

                    command.Parameters.AddWithValue("@startDate", reservation.startDate);
                    command.Parameters.AddWithValue("@endDate", reservation.endDate);
                    command.Parameters.AddWithValue("@roomId", reservation.roomId);
                    command.Parameters.AddWithValue("@clientId", reservation.clientId);
                    command.Parameters.AddWithValue("@reservationPrice", reservation.reservationPrice);
                    command.Parameters.AddWithValue("@paidReservation", reservation.paidReservation);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }

        }
        public void EditReservation(ReservationModel reservation)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"Update Reservation Set
                                            startDate = @startdate,
                                            endDate = @enddate,
                                            roomId = @roomid,
                                            clientId = @clientid,
                                            reservationPrice = @reservationprice,
                                            paidReservation = @paidreservation
                                            Where reservationId = @reservationid";

                    command.Parameters.AddWithValue("@startdate", reservation.startDate);
                    command.Parameters.AddWithValue("@enddate", reservation.endDate);
                    command.Parameters.AddWithValue("@roomid", reservation.roomId);
                    command.Parameters.AddWithValue("@clientid", reservation.clientId);
                    command.Parameters.AddWithValue("@reservationprice", reservation.reservationPrice);
                    command.Parameters.AddWithValue("@paidreservation", reservation.paidReservation);
                    command.Parameters.AddWithValue("@reservationid", reservation.reservationId);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteReservation(int id)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM Reservation
											WHERE reservationId = @reservationid";
                    command.Parameters.AddWithValue("@reservationid", id);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }


    }
}
