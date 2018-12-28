using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06.WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine()
                .Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string pattern = @".{20}";

            foreach (var ticket in tickets)
            {
                MatchCollection validTickets = Regex.Matches(ticket, pattern);
                
                foreach (Match t in validTickets)
                {
                    var tickets = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim()).ToArray();

                    var winnigTicket = false;
                    foreach (var ticket in tickets)
                    {
                        if (ticket.Length != 20)
                        {
                            Console.WriteLine("invalid ticket");
                            continue;
                        }

                        var left = new string(ticket.Take(10).ToArray());
                        var right = new string(ticket.Skip(10).ToArray());

                        var winningSymbols = new string[] { "@", "#", "\\$", "\\^" };

                        foreach (var winSymb in winningSymbols)
                        {
                            var regex = new Regex($"{winSymb}{{6,}}");

                            var leftMatch = regex.Match(left);
                            if (leftMatch.Success)
                            {
                                var rightMatch = regex.Match(right);
                                if (rightMatch.Success)
                                {
                                    winnigTicket = true;

                                    var symbolsLength = leftMatch.Value.Length;
                                    var jackpot = symbolsLength == 10 && rightMatch.Value.Length == 10 ? " Jackpot!" : string.Empty;
                                    Console.WriteLine($"ticket \"{ticket}\" - {symbolsLength}{winSymb.Trim('\\')}{jackpot}");
                                    break;
                                }
                            }
                        }
                        if (!winnigTicket)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - no match");
                        }

                    }
            }
        }
    }
}