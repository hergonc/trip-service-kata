using System.Collections.Generic;
using TripServiceKata.Entity;
using Xunit;

namespace TripServiceKata.Tests
{
    public class TripServiceShould
    {
        private readonly User friend;
        private readonly TripService tripService;

        public TripServiceShould()
        {
            friend = new User();
            var userSessionService = new UserSessionServiceMock(friend);
            var userTripsService = new UserTripServiceMock();
            tripService = new TripService(userSessionService, userTripsService);
        }

        [Fact]
        public void user_have_one_trip()
        {
            var user = new User();
            user.AddFriend(friend);

            var tripsExpected = tripService.GetTripsByUser(user);

            Assert.Single(tripsExpected);
        }

        [Fact]
        public void user_have_not_trip()
        {
            var tripsExpected = tripService.GetTripsByUser(new User());

            Assert.Empty(tripsExpected);
        }

        [Fact]
        public void user_have_three_friends_and_one_trip()
        {
            var user = new User();
            user.AddFriend(new User());
            user.AddFriend(new User());
            user.AddFriend(friend);

            var tripsExpected = tripService.GetTripsByUser(user);

            Assert.Single(tripsExpected);
        }

        [Fact]
        public void user_have_three_friends_and_no_trip()
        {
            var user = new User();
            user.AddFriend(new User());
            user.AddFriend(new User());
            user.AddFriend(new User());

            var tripsExpected = tripService.GetTripsByUser(user);

            Assert.Empty(tripsExpected);
        }
    }

    internal class UserSessionServiceMock : IUserSessionService
    {
        private readonly User user;

        public UserSessionServiceMock(User user)
        {
            this.user = user;
        }

        public User LoggedUser()
        {
            return user;
        }
    }

    internal class UserTripServiceMock : IUserTripsService
    {
        public List<Trip> FindTripsByUser(User user)
        {
            return new List<Trip>() { new Trip() };
        }

    }
}
