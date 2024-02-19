using System;
using System.Threading.Tasks;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
//using MySql.Data.MySqlClient;

namespace ExternlaLibrary.Standard
{
    public class Person
    {
        public Guid Id => Guid.NewGuid();
        public string Name => "John Smith";
        public string Email => "john.smith@electron-quick-start.com";

    }

	public class Library {
		public Person GetPerson() {
			return new Person();
		}

		public DateTime GetServerTime() {
			DateTime currentDateTime;
			string connectionString = "Server=127.0.0.1;database=test;uid=sa;pwd=afrodite;Pooling=False;Connection Timeout=600;";
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
		
		/*
		public async Task<DateTime> GetMySqlTime() {			
			DateTime currentDateTime;
			string connectionString = "Server=localhost;database=test;uid=user1;pwd=user1user1;Pooling=False;Connection Timeout=600;Allow User Variables=True;";
			MySqlConnection connection = new MySqlConnection(connectionString); 

				// Apre la connessione
				await connection.OpenAsync();
				return DateTime.Now;

				string sql = "SELECT NOW();"; // Query per ottenere la data corrente
				MySqlCommand cmd = new MySqlCommand(sql, connection);
				currentDateTime = (DateTime)cmd.ExecuteScalar(); // Esegue la query e ottiene il risultato come oggetto DateTime


				// Chiude la connessione
				connection.Close();
				return currentDateTime;
			
		}
		*/
	}
}