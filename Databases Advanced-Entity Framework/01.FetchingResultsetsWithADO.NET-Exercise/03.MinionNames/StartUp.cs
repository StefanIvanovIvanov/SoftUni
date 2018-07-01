using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using _01.InitialSetup;

namespace _03.MinionNames
{
    class StartUp
    {
        static void Main(string[] args)
        {

            int villainId = int.Parse(Console.ReadLine());

            using (SqlConnection conection = new SqlConnection(Configuration.ConnectionString))
            {
                conection.Open();

                string villainName = GetVillainName(villainId, conection);

                if (villainName == null)
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                }
                else
                {
                    Console.WriteLine($"Villlain: {villainName}");
                    PrintNames(villainId, conection);
                }

                conection.Close();
            }
        }

        private static void PrintNames(int villainId, SqlConnection conection)
        {
            string minionsSql = "SELECT Name, Age FROM Minions AS m JOIN MinionsVillains AS mv ON mv.MinionId = m.Id WHERE mv.VillainId = @Id";

            using (SqlCommand command = new SqlCommand(minionsSql, conection))
            {
                command.Parameters.AddWithValue("Id", villainId);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("(no minions");
                    }
                    else
                    {
                        int row = 1;
                        while (reader.Read())
                        {
                            Console.WriteLine($"{row++}. {reader[0]} {reader[1]}");
                        }
                    }
                }
            }
        }

        private static string GetVillainName(int villainId, SqlConnection conection)
        {
            string nameSql = "SELECT Name FROM Villains WHERE Id = @id";

            using (SqlCommand command = new SqlCommand( nameSql, conection))
            {
                command.Parameters.AddWithValue("@id", villainId);
                return (string) command.ExecuteScalar();
            }
        }
    }
}
