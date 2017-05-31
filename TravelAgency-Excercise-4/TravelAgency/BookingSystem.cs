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
        private int seats { get; set; }
        private Passenger passenger { get; set; }

        private ITourSchedule tourSchedule;

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

        public int Seats
        {
            get { return seats; }
            set { seats = value; }
        }

        public Passenger Passenger
        {
            get { return passenger; }
            set { passenger = value; }
        }

        public BookingSystem(ITourSchedule ItourSchedule)
        {
            tourSchedule = ItourSchedule;
        }

        public BookingSystem()
        {
            
        }

        public BookingSystem(string name, DateTime dateTime, int seats, Passenger passenger)
        {
            Name = name;
            Seats = seats;
            DateOfTheTour = dateOfTheTour;
            Passenger = passenger;
        }


        public void CreateBooking(string _name, DateTime _dateOfTheTour, int _seats, Passenger _passenger)
        {
            var tour = tourSchedule.listOfTour.FirstOrDefault(x => x.Name == _name);

            if (string.IsNullOrEmpty(_name) || _dateOfTheTour.Date == null || _seats == 0 || _passenger == null)
            {
                throw new NoneExistensExeption();
            }
            if (tour.AvailableNumberOfSeats < _seats)
            {
                throw new NoneAvailableSeats();

            }
            BookingSystem newBooking = new BookingSystem()
            {
                name = _name,
                dateOfTheTour = _dateOfTheTour.Date,
                seats = _seats,
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
