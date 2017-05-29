using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class TourSchedule
    {
        private string Name { get; set; }
        private DateTime DateOfTheTour { get; set; }
        private int AvailableNumberOfSeats { get; set; }

        //public TourSchedule(string _name, DateTime _dateOfTheTour, int _availableNumberOfSeats)
        //{
        //    Name = _name;
        //    DateOfTheTour = _dateOfTheTour;
        //    AvailableNumberOfSeats = _availableNumberOfSeats;
        //}

        private List<TourSchedule> TourCalendar = new List<TourSchedule>();
        
        public void CreateTour(string name, DateTime dateOfTheTour, int availableNumberOfSeats)
        {
            var newTour = new TourSchedule()
            {
                Name = name,
                DateOfTheTour = dateOfTheTour,
                AvailableNumberOfSeats = availableNumberOfSeats
            };

            TourCalendar.Add(newTour);

        }

        public List<TourSchedule> GetToursFor(DateTime inDateTime)
        {
            if (inDateTime.Date == null)
            {

            }
            var result = TourCalendar.FindAll(x=>x.DateOfTheTour == inDateTime.Date);
            return result;
        }
    }
}
