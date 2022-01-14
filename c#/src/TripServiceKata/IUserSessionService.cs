using TripServiceKata.Entity;

namespace TripServiceKata
{
    public interface IUserSessionService
    {
        User LoggedUser();
    }
}