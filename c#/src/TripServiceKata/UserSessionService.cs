using TripServiceKata.Entity;
using TripServiceKata.Service;

namespace TripServiceKata
{
    public class UserSessionService : IUserSessionService
    {
        public User LoggedUser()
        {
            return UserSession.GetInstance().GetLoggedUser();
        }
    }
}