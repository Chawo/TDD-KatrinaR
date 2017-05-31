using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class TourSchedule : ITourSchedule
    { 
        public List<Tour> listOfTour { get; set; }

        public TourSchedule()
        {
            listOfTour = new List<Tour>();
        }


        public void CreateTour(string name, DateTime dateOfTheTour, int availableNumberOfSeats)
        {

            var result = listOfTour.Count(x => x.DateOfTheTour.Date == dateOfTheTour.Date);

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

                listOfTour.Add(newTour);
            }


        }

        public List<Tour> GetToursFor(DateTime inDateTime)
        {
            return listOfTour.Where(x => x.DateOfTheTour.Date == inDateTime.Date).ToList();
        }
    }
}
