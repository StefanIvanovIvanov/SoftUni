using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace _01.FetchingResultsetsWithADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=STEFAN;" +
                                      @"Database=SoftUni;" +
                                      @"Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM EMPLOYEES", connection);
                int employeesCount = (int) command.ExecuteScalar();
                Console.WriteLine($"Employees count: {employeesCount}");

                string town = Console.ReadLine();
                string commandText = $"INSERT INTO Towns VALUES ('{town}')";
                SqlCommand insertTownCommand = new SqlCommand(commandText, connection);
                int rowsAffeccted = insertTownCommand.ExecuteNonQuery();
                Console.WriteLine(rowsAffeccted);

                SqlTransaction transaction = connection.BeginTransaction("TownsInsteadOfDelete");
                town = Console.ReadLine();
                string transactionCommandText = $"DELETE FROM Towns WHERE Name = ('{town}')";
                SqlCommand transactionCommand=new SqlCommand(transactionCommandText, connection, transaction);
                rowsAffeccted = transactionCommand.ExecuteNonQuery();
                transaction.Rollback();
                Console.WriteLine(rowsAffeccted);


                List<Employee> employees=new List<Employee>();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string firstName = (string)dataReader["FirstName"];
                    string lastName = (string)dataReader["LastName"];
                    string jobTitle = (string)dataReader["JobTitle"];

                    Employee employee = new Employee(firstName, lastName, jobTitle);
                    employees.Add(employee);
                }

                var groups = employees.GroupBy(e => e.JobTitle).OrderByDescending(e => e.Key);
                string spaces = new string(' ', 4);
                foreach (var g in groups)
                {
                    Console.WriteLine(g.Key);
                    foreach (var e in g)
                    {
                        Console.WriteLine(spaces+e.FirstName+" "+e.LastName);
                    }
                }
            }

            connection.Close();
            //connection.Dispose();
        }
    }
}
