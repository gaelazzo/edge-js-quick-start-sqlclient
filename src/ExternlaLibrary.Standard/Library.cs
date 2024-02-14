using System;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace ExternlaLibrary.Standard
{
    public class Person
    {
        public Guid Id => Guid.NewGuid();
        public string Name => "John Smith";
        public string Email => "john.smith@electron-quick-start.com";

    }

    public class Library
    {
        public Person GetPerson()
        {
            return new Person();
        }
		public DateTime GetServerTime() {
			DateTime currentDateTime;
			string connectionString = "Server=myServerAddress;Database=myDatabase;User Id=myUsername;Password=myPassword;";
			using (SqlConnection connection = new SqlConnection(connectionString)) {

				// Apre la connessione
				connection.Open();

				// Query per ottenere la data del server
				string query = "SELECT GETDATE() AS CurrentDateTime";

				// Esegue la query
				SqlCommand command = new SqlCommand(query, connection);
				SqlDataReader reader = command.ExecuteReader();

				// Legge la data dal risultato della query
				currentDateTime = (DateTime)reader["CurrentDateTime"];

				// Chiude la connessione
				connection.Close();
				return currentDateTime;
			}
		}
	}
}