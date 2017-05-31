using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class TourSchedule : ITourSchedule
    { 
        private List<Tour> TourCalendar = new List<Tour>();
         
        public void CreateTour(string name, DateTime dateOfTheTour, int availableNumberOfSeats)
        {

            var result = TourCalendar.Count(x => x.DateOfTheTour.Date == dateOfTheTour.Date);

            if (result >= 3)
            {
                throw new TourAllocationException(dateOfTheTour.AddDays(1).Date);
            }
            else
            {
                var newTour = new Tour()
                {
                    Name = name,
                    DateOfTheTour = dateOfTheTour,
                    AvailableNumberOfSeats = availableNumberOfSeats
                };

                TourCalendar.Add(newTour);
            }


        }

        public List<Tour> GetToursFor(DateTime inDateTime)
        {
            return TourCalendar.Where(x => x.DateOfTheTour.Date == inDateTime.Date).ToList();
        }
    }
}
