using System;
using System.Collections.Generic;
using System.Text;
using PhotoShare.Client.Core.Contracts;
using PhotoShare.Services.Contracts;

namespace PhotoShare.Client.Core.Commands
{
    public class LogOutCommand : ICommand
    {
        private IUserSessionService userSession;

        public LogOutCommand(IUserSessionService userSession)
        {
            this.userSession = userSession;
        }

        public string Execute(string[] data) => this.userSession.Logout();
    }
}
