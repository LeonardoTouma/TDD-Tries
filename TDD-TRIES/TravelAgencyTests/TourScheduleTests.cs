using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency;

namespace TravelAgencyTests
{
    [TestFixture]
    public class TourScheduleTests
    {
        private List<TourSchedule> tours = new List<TourSchedule>();
        //[TestCase("GrandTour","2017/05/24", "Ford1", "Seat1")]
        [Test,TestCaseSource(typeof(TourSchedule))]
        public void CanCreateNewTour(string Name, DateTime Date, CheckVehicle Vehicle, CheckAvalibleSeats Seats)
        {
            TourSchedule tour = new TourSchedule();
            tour.Name = Name;
            tour.Seats = Seats;
            tour.Vehicle = Vehicle;
            tour.Date = Date;
            tours.Add(tour);
            Assert.IsTrue(tour.CanCreateTour);
        }
        public TourSchedule ReturnTourInstance()
        {
            var sut = new TourSchedule();
            return sut;
        }
    }
}
