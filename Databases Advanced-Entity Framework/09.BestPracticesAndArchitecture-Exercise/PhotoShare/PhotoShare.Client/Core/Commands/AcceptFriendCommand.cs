using System.Linq;
using PhotoShare.Client.Core.Dtos;
using PhotoShare.Services.Contracts;

namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Contracts;

    public class AcceptFriendCommand : ICommand
    {
        private readonly IUserService userService;

        public AcceptFriendCommand(IUserService userService)
        {
            this.userService = userService;
        }

        // AcceptFriend <username1> <username2>
        public string Execute(string[] data)
        {
            string username = data[0];
            string friendUsername = data[1];

            var userExists = this.userService.Exists(username);
            var friendExists = this.userService.Exists(friendUsername);

            if (!userExists)
            {
                throw new ArgumentException($"{username} not found!");
            }

            if (!friendExists)
            {
                throw new ArgumentException($"{friendUsername} not found!");
            }

            var user = this.userService.ByUsername<UserFriendsDto>(username);
            var friend = this.userService.ByUsername<UserFriendsDto>(friendUsername);

            bool isAlreadyFriend = user.Friends.Any(x => x.Username == friend.Username);

            if (isAlreadyFriend)
            {
                throw new InvalidOperationException($"{friend.Username} is already friend to {user.Username}");
            }

            this.userService.AcceptFriend(user.Id, friend.Id);

            return $"{user.Username} accepted {friend.Username} as a friend";
        }
    }
}
