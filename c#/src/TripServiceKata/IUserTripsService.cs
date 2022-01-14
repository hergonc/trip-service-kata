using System.Collections.Generic;
using TripServiceKata.Entity;

namespace TripServiceKata
{
    public interface IUserTripsService
    {
        List<Trip> FindTripsByUser(User user);
    }
}