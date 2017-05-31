using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public interface ITourSchedule
    {
        void CreateTour(string name, DateTime dateOfTheTour, int availableNumberOfSeats);
        List<Tour> GetToursFor(DateTime inDateTime);
        List<Tour> listOfTour { get; set; }

    }
}
