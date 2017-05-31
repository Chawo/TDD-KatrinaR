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
    public class TourScheduleTests
    {
        private TourSchedule sut;

        [SetUp]
        public void Setup()
        {
            sut = new TourSchedule();
        }

        [Test]
        public void CanCreateNewTour()
        {
            sut.CreateTour(
            "New years day safari",
            new DateTime(2013, 1, 1), 20);
            var result = sut.GetToursFor(new DateTime(2013, 1, 1));


            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("New years day safari", result[0].Name);
            Assert.AreEqual(20, result[0].AvailableNumberOfSeats);

        }

        [Test]
        public void ToursAreScheduledByDateOnly()
        {
            sut.CreateTour(
                "New years day safari",
                new DateTime(2013, 1, 1, 10, 15, 0), 20);

            var result = sut.GetToursFor(new DateTime(2013, 1, 1));
            var expected = new DateTime(2013, 1, 1);

            Assert.AreEqual(expected, result[0].DateOfTheTour.Date);

        }

        [Test]
        public void GetToursForGivenDayOnly()
        {
            sut.CreateTour(
            "Christmas day safari",
            new DateTime(2013, 12, 24, 10, 15, 0), 200);

            sut.CreateTour(
            "Beach day safari",
            new DateTime(2013, 8, 6, 10, 15, 0), 50);

            sut.CreateTour(
            "Valentines day safari",
            new DateTime(2013, 2, 14, 10, 15, 0), 60);

            sut.CreateTour(
            "Mothers day safari",
            new DateTime(2013, 5, 29, 10, 15, 0), 100);

            var result = sut.GetToursFor(new DateTime(2013, 5, 29));


            Assert.AreEqual(new DateTime(2013, 5, 29), result[0].DateOfTheTour.Date);

            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void TourAllocationException()
        {
            sut.CreateTour("Kids day safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);
            sut.CreateTour("Water day safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);
            sut.CreateTour("Animal day safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);

            Assert.Throws<TourAllocationException>(() => sut.CreateTour("Animal day safari", new DateTime(2013, 1, 1, 10, 15, 0), 20));



        }
    }

    
}
