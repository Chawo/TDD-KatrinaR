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
             
        }

        [Test]
        public void ExpectOneTourFromList()
        {
                        
            var dateTime = DateTime.Parse("2013, 1, 1");
            var result = sut.GetToursFor(dateTime);
             

            Assert.AreEqual(1, result.Count);
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
    }
}
