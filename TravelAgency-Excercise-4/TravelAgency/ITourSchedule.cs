using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public interface ITourSchedule
    {
        List<Tour> GetToursFor(DateTime inDateTime);
        void CreateTour(string name, DateTime dateOfTheTour, int availableNumberOfSeats);

    }
}
