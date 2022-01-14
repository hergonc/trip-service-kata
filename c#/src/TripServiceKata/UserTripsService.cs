using System.Collections.Generic;
using TripServiceKata.Entity;
using TripServiceKata.Service;

namespace TripServiceKata
{
    public class UserTripsService : IUserTripsService
    {
        public List<Trip> FindTripsByUser(User user)
        {
            return TripDAO.FindTripsByUser(user);
        }
    }
}