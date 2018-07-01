using System;
using System.Data.SqlClient;
using _01.InitialSetup;

namespace _06.RemoveVillain
{
    class Program
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection(Configuration.ConnectionString);
            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT Id FROM Villains WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", villainId);

                int? result = (int?)command.ExecuteScalar();

                if (result == null)
                {
                    Console.WriteLine("No such villain was found.");
                    connection.Close();
                    return;
                }

                command = new SqlCommand("SELECT COUNT(*) FROM MinionsVillains WHERE VillainId = @Id", connection);
                command.Parameters.AddWithValue("@Id", villainId);
                int minionsCount = (int)command.ExecuteScalar();

                command = new SqlCommand("DELETE FROM MinionsVillains WHERE VillainId = @Id", connection);
                command.Parameters.AddWithValue("@Id", villainId);
                command.ExecuteNonQuery();

                command = new SqlCommand("SELECT Name FROM Villains WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", villainId);
                string villainName = (string)command.ExecuteScalar();

                command = new SqlCommand("DELETE FROM Villains WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", villainId);
                command.ExecuteNonQuery();

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{minionsCount} minions were released.");
            }
        }
    }
}
