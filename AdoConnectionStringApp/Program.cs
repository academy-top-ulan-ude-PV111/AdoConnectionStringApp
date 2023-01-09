using System.Data.SqlClient;
using System.Data;

namespace AdoConnectionStringApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=10;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string commandText = "";
            int result;
            /*
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                Console.WriteLine($"Connection string: {sqlConnection.ConnectionString}");
                Console.WriteLine($"Database: {sqlConnection.Database}");
                Console.WriteLine($"Server: {sqlConnection.DataSource}");
                Console.WriteLine($"Server version: {sqlConnection.ServerVersion}");
                Console.WriteLine($"State of connection: {sqlConnection.State}");

                //SqlCommand command = new();
                //command.CommandText = "CREATE TABLE books";
                //command.Connection = sqlConnection;

                commandText = "CREATE DATABASE LibraryDb";


                SqlCommand command = new(commandText, sqlConnection);
                result = command.ExecuteNonQuery();
                Console.WriteLine($"Create db: {result}");
            }
            */
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDb;Integrated Security=True;Connect Timeout=10;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand command = new();
                command.Connection = sqlConnection;

                /*
                commandText = "CREATE TABLE books (id INT IDENTITY(1, 1) PRIMARY KEY," +
                    "title NVARCHAR(100) NOT NULL," +
                    "author NVARCHAR(100) NULL)";
                command.CommandText = commandText;
                result = command.ExecuteNonQuery();
                Console.WriteLine($"Create table: {result}");

                commandText = "INSERT INTO books (title, author) " +
                    "VALUES ('War and piece', 'Leo Tolstoy')," +
                    "('Ruslan and Ludmila', 'Alexander Pushkin')";
                command.CommandText = commandText;
                result = command.ExecuteNonQuery();
                Console.WriteLine($"insert row: {result}");
                */

                commandText = "SELECT * FROM books";
                command.CommandText = commandText;
                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}\t\t{reader.GetName(2)}\t");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetValue(0)}\t{reader.GetValue(1)}\t\t{reader.GetValue(2)}\t");
                    }
                }
            }
        }
    }
}