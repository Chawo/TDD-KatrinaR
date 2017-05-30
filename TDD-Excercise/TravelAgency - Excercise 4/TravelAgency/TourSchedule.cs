using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class TourSchedule
    {
        public string Name { get; set; }
        public DateTime DateOfTheTour { get; set; }
        public int AvailableNumberOfSeats { get; set; } 

        private List<TourSchedule> TourCalendar = new List<TourSchedule>();
        
        public void CreateTour(string name, DateTime dateOfTheTour, int availableNumberOfSeats)
        {

            var result = TourCalendar.Count(x => x.DateOfTheTour.Date == dateOfTheTour.Date);

            if (result >= 3)
            {
                throw new TourAllocationException(dateOfTheTour.AddDays(1).Date);
            }
            else
            {
                var newTour = new TourSchedule()
                {
                    Name = name,
                    DateOfTheTour = dateOfTheTour,
                    AvailableNumberOfSeats = availableNumberOfSeats
                };

                TourCalendar.Add(newTour);
            } 
            

        }

        public List<TourSchedule> GetToursFor(DateTime inDateTime)
        {
            return TourCalendar.Where(x => x.DateOfTheTour.Date == inDateTime.Date).ToList();
        }
    }
}
