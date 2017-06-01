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
        public DateTime Date { get; set; }
        public CheckAvalibleSeats Seats { get; set; }
        public CheckVehicle Vehicle { get; set; }
        public bool CanCreateTour { get; set; }
        public int? NumberOfToursAdded { get; set; }
        //public Booking booking { get; set; }
        public List<CheckAvalibleSeats> check { get; set; }
        private ITourSchedule itour;
        public TourSchedule()
        {
        }
        public TourSchedule(ITourSchedule itour)
        {
            this.itour = itour;
            Date = DateTime.Today.AddDays(+1);
            CanCreateTour = true;
            NumberOfToursAdded++;
        }
    }
}
