using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency;

namespace TravelAgencyTests
{
    public class TourScheduleStub : ITourSchedule
    {
        public List<Tour> Tours = new List<Tour>();

        public void CreateTour(string name, DateTime dateOfTheTour, int availableNumberOfSeats)
        {
            //Tour newTour = new Tour()
            //{
            //    Name = name,
            //    DateOfTheTour = dateOfTheTour,
            //    AvailableNumberOfSeats = availableNumberOfSeats
            //};

            //Tours.Add(newTour);
        }

        public List<Tour> GetToursFor(DateTime inDateTime)
        {
            return Tours;
        }
    }
}
