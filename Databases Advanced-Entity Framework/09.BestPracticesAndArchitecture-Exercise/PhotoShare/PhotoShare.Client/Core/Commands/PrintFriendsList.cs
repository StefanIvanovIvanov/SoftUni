using System;
using System.Linq;
using System.Text;
using PhotoShare.Client.Core.Contracts;
using PhotoShare.Models;
using PhotoShare.Services.Contracts;

namespace PhotoShare.Client.Core.Commands
{
    public class PrintFriendsListCommand : ICommand
    {
        private readonly IUserService userService;

        public PrintFriendsListCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            string userName = args[0];

            var userExists = this.userService.Exists(userName);

            if (!userExists)
            {
                throw new ArgumentException($"User {userName} not found");
            }

            var user = userService.ByUsername<User>(userName);

            var friendsList = user.FriendsAdded.ToList();

            if (friendsList.Count == 0)
            {
                return "No friends for thise user. :(";
            }
            else
            {
                StringBuilder sb=new StringBuilder();

                sb.AppendLine("Friends:");
                foreach (var friend in friendsList)
                {
                    sb.AppendLine("-" + friend);
                }
                return sb.ToString().TrimEnd();
            }
        }
    }
}
