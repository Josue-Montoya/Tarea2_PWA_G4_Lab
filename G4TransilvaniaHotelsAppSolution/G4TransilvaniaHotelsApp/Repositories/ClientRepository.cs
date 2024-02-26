using System.Data.SqlClient;
using System.Data;
using G4TransilvaniaHotelsApp.Data;
using G4TransilvaniaHotelsApp.Models;

namespace G4TransilvaniaHotelsApp.RepositoriesClient
{
    public class ClientRepository : IClientRepository
    {
        private readonly SqlDataAccess _dbConnection;

        public ClientRepository(SqlDataAccess dbConnection)
        {
            _dbConnection = dbConnection;

        }

        public IEnumerable<ClientModel> GetAll()
        { 
            List<ClientModel> clientList = new List<ClientModel>();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT clientId, clientName, clientEmail, clientPhone FROM Client;";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClientModel client = new ClientModel();
                            client.clientId = Convert.ToInt32(reader["clientId"]); 
                            client.clientName = reader["clientName"].ToString();
                            client.clientEmail = reader["clientEmail"].ToString();
                            client.clientPhone = reader["clientPhone"].ToString();

                            clientList.Add(client);
                        }
                    }
                }
            }

            return clientList;
        }

        public ClientModel GetClientByclientId(int id)
        {
            ClientModel clientModel = new ClientModel();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT clientId, clientName, clientEmail, clientPhone FROM Client where clientId = @clientId";

                    command.Parameters.AddWithValue("clientId", id);
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clientModel.clientId = Convert.ToInt32(reader["clientId"]);
                            clientModel.clientName = reader["clientName"].ToString();
                            clientModel.clientEmail = reader["clientEmail"].ToString();
                            clientModel.clientPhone = reader["clientPhone"].ToString();
                        }
                    }
                }
            }

            return clientModel;
        }

        public void add(ClientModel client)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Client 
                                           VALUES(@clientName, @clientEmail, @clientPhone)";

                    command.Parameters.AddWithValue("@clientName", client.clientName);
                    command.Parameters.AddWithValue("@clientEmail", client.clientEmail);
                    command.Parameters.AddWithValue("@clientPhone", client.clientPhone);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery(); 
                }
            }
        }



        public void Edit(ClientModel client)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Client
                                           SET clientName = @clientName,
                                           clientEmail = @clientEmail,
                                           clientPhone = @clientPhone
                                           WHERE clientId = @clientId";

                    command.Parameters.AddWithValue("@clientName", client.clientName);
                    command.Parameters.AddWithValue("@clientEmail", client.clientEmail);
                    command.Parameters.AddWithValue("@clientPhone", client.clientPhone);
                    command.Parameters.AddWithValue("@clientId", client.clientId);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();

                }
            }

        }

        public void Delete(int id)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM Client WHERE clientId = @clientId";

                    command.Parameters.AddWithValue("@clientId", id);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }
          
    }


}
