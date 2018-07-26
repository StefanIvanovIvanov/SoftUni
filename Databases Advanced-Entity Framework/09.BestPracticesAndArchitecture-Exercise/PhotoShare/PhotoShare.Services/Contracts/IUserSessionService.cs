using PhotoShare.Models;

namespace PhotoShare.Services.Contracts
{
    public interface IUserSessionService
    {
        User User { get; }

        bool IsLoggedIn { get; }

        User Login(string username, string password);

        string Logout();

        void Authorize();
    }
}
