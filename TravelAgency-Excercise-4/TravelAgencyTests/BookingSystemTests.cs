using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TravelAgency;

namespace TravelAgencyTests
{
    [TestFixture]
    public class BookingSystemTests
    {
        private TourScheduleStub tourScheduleStub;
        private BookingSystem sut;

        [SetUp]
        public void Setup()
        {
            tourScheduleStub = new TourScheduleStub();
            sut = new BookingSystem(this.tourScheduleStub);
        }
        //This test will make sure that we get a Booking object back with the correct details. The Booking class does not exist yet. 
        [Test]
        public void CanCreateBooking()
        {

            tourScheduleStub.listOfTour.Add(new Tour { Name = "Happy New Year", DateOfTheTour = new DateTime(2012, 2, 12), AvailableNumberOfSeats = 20 });

            Passenger passenger = new Passenger() {
                fname = "Katrina",
                lname = "Rosales"
            };

            sut.CreateBooking("Happy New Year", new DateTime(2012, 2, 12), 10, passenger);

            var bookings = sut.GetBookingsFor(passenger);

            Assert.AreEqual(1, bookings.Count);
            Assert.AreEqual("Katrina Rosales", $"{bookings[0].Passenger.fname} {bookings[0].Passenger.lname}");
            Assert.AreEqual("Happy New Year", bookings[0].Name);
            Assert.AreEqual(new DateTime(2012, 2, 12), bookings[0].DateOfTheTour);
        }

        [Test]
        public void TourAllocationException()
        {
            
            Passenger passenger = new Passenger()
            {
                fname = "Katrina",
                lname = "Rosales"
            };

           
            Assert.Throws<NoneExistensExeption>(() => sut.CreateBooking("", new DateTime(), 0, passenger));
            
        }

        [Test]
        public void FullBookedTour()
        {
            tourScheduleStub.listOfTour.Add(new Tour { Name = "VIP Safari", DateOfTheTour = new DateTime(2014, 2, 12), AvailableNumberOfSeats = 2 });
              
            Passenger passenger = new Passenger()
            {
                fname = "Kalle",
                lname = "Anka"
            };
            
            Assert.Throws<NoneAvailableSeats>(() => sut.CreateBooking("VIP Safari", new DateTime(2014, 2, 12), 4, passenger));

        }
    }
}
