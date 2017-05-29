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
        TourSchedule sut = new TourSchedule();

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
            
        }
    }
}
