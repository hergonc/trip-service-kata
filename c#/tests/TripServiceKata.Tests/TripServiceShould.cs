using System.Collections;
using System.Collections.Generic;
using TripServiceKata.Entity;
using Xunit;

namespace TripServiceKata.Tests
{
    public class TripServiceShould
    {

        [Fact]
        public void user_have_one_trip()
        {
            var friend = new User();
            var userSessionService = new UserSessionServiceMock(friend);
            var userTripsService = new UserTripServiceMock();
            var tripService = new TripService(userSessionService, userTripsService);
            var user = new User();
            user.AddFriend(friend);
            var tripsExpected = tripService.GetTripsByUser(user);

            Assert.Single(tripsExpected);
        }
    }

    class UserSessionServiceMock : IUserSessionService
    {
        private User user;

        public UserSessionServiceMock(User user)
        {
            this.user = user;
        }

        public User LoggedUser()
        {
            return user;
        }
    }

    class UserTripServiceMock : IUserTripsService
    {
        public List<Trip> FindTripsByUser(User user)
        {
            return new List<Trip>() { new Trip() };
        }

    }
}
