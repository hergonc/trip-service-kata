using System.Collections.Generic;
using System.Linq;
using TripServiceKata.Entity;
using TripServiceKata.Exception;
using TripServiceKata.Service;

namespace TripServiceKata
{
    public class TripService
    {
        private readonly IUserSessionService userSessionService;
        private readonly IUserTripsService userTripsService;

        public TripService(IUserSessionService sessionService, IUserTripsService userTripsService)
        {
            userSessionService = sessionService;
            this.userTripsService = userTripsService;
        }

        public List<Trip> GetTripsByUser(User user)
        {
            var loggedUser = userSessionService.LoggedUser();
            if (loggedUser == null) throw new UserNotLoggedInException();
            return HasFriend(user, loggedUser) ? 
                userTripsService.FindTripsByUser(user) : 
                new List<Trip>();
        }

        private bool HasFriend(User user, User loggedUser) =>
            Enumerable.Contains(user.GetFriends(), loggedUser);
    }
}