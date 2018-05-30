using System;
using System.Collections.Generic;

namespace _03.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, BankAccount>accounts=new Dictionary<int, BankAccount>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split();

                string commandType = tokens[0];

                switch (commandType)
                {
                    case "Create":
                        int id = int.Parse(tokens[1]);
                        if (accounts.ContainsKey(id))
                        {
                            Console.WriteLine("Account already exists");
                        }
                        else
                        {
                            BankAccount acc=new BankAccount();
                            acc.Id = id;
                            accounts.Add(id, acc);
                        }
                        break;
                    case "Deposit":
                         id = int.Parse(tokens[1]);
                        if (ValidateAccount(id, accounts))
                        {
                            accounts[id].Deposit(int.Parse(tokens[2]));
                        }
                        break;
                    case "Withdraw":
                         id = int.Parse(tokens[1]);
                        if (ValidateAccount(id, accounts))
                        {
                            accounts[id].Withdraw(int.Parse(tokens[2]));
                        }
                        break;
                    case "Print":
                         id = int.Parse(tokens[1]);
                        if (ValidateAccount(id, accounts))
                        {
                            Console.WriteLine(accounts[id]);
                        }
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
        }

        private static bool ValidateAccount(int id, Dictionary<int, BankAccount> accounts)
        {
            if (accounts.ContainsKey(id))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Account does not exist");
                return false;
            }
        }
    }
}
