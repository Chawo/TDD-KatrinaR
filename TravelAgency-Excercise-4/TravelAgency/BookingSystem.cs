using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class BookingSystem
    {
        private string name { get; set; }
        private DateTime dateOfTheTour { get; set; }
        private Passenger passenger { get; set; }

        private List<BookingSystem> ListOfBooking = new List<BookingSystem>();

        

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime DateOfTheTour
        {
            get { return dateOfTheTour; }
            set { dateOfTheTour = value; }
        }

        public Passenger Passenger
        {
            get { return passenger; }
            set { passenger = value; }
        }

        public BookingSystem(ITourSchedule ItourSchedule)
        {
            // Taking in Interface
        }

        public BookingSystem()
        {
            
        }

        public BookingSystem(string name, DateTime dateTime, Passenger passenger)
        {
            Name = name;
            DateOfTheTour = dateOfTheTour;
            Passenger = passenger;
        }


        public void CreateBooking(string _name, DateTime _dateOfTheTour, Passenger _passenger)
        {
            
            if (string.IsNullOrEmpty(_name) || _dateOfTheTour.Date == null || _passenger == null)
            {
                throw new NoneExistensExeption();
            } 
            BookingSystem newBooking = new BookingSystem()
            {
                name = _name,
                dateOfTheTour = _dateOfTheTour.Date,
                passenger = _passenger
            };

            ListOfBooking.Add(newBooking);
        }

        public List<BookingSystem> GetBookingsFor(Passenger passenger)
        {
            var listOfBooking = ListOfBooking.Where(x => x.passenger == passenger).ToList();
            return listOfBooking;
        }
    }
}
