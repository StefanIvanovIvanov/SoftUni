using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using _01.InitialSetup;

namespace _05.ChangeTownNamesCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            SqlConnection connection = new SqlConnection(Configuration.ConnectionString);
            connection.Open();

            using (connection)
            {
                int? countryId = (int?)new SqlCommand($"SELECT Id FROM Countries WHERE Name = '{countryName}'", connection).ExecuteScalar();

                if (countryId == null)
                {
                    Console.WriteLine("No town names were affected.");
                }
                else
                {
                    int townsCount = (int)new SqlCommand($"SELECT COUNT(*) FROM Towns WHERE CountryId = {countryId}", connection).ExecuteScalar();

                    SqlDataReader reader = new SqlCommand($"SELECT * FROM Towns WHERE CountryId = {countryId}", connection).ExecuteReader();

                    var townNamesAffected = new List<String>();
                    var townIdsAffected = new List<int>();

                    using (reader)
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No town names were affected.");
                            reader.Close();
                            connection.Close();
                            return;
                        }

                        while (reader.Read())
                        {

                            string townName = (string)reader["Name"];
                            int townId = (int)reader["Id"];

                            townNamesAffected.Add(townName.ToUpper());
                            townIdsAffected.Add(townId);
                        }
                    }

                    for (int i = 0; i < townIdsAffected.Count; i++)
                    {
                        new SqlCommand($"UPDATE Towns SET Name = '{townNamesAffected[i].ToUpper()}' WHERE Id = {townIdsAffected[i]}", connection).ExecuteNonQuery();
                    }

                    Console.WriteLine($"{townsCount} town names were affected.");
                    Console.WriteLine($"[{String.Join(", ", townNamesAffected)}]");
                }
            }
        }
    }
}
