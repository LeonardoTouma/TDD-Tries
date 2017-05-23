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
        TourSchedule tour = new TourSchedule();
        private List<TourSchedule> tours = new List<TourSchedule>();
        //public List<int?> NumberOfTours { get; set; }
        TravelAgency.Program prog = new Program();
        //[TestCase("GrandTour","2017/05/24", "Ford1", "Seat1")]
        [Test,TestCaseSource(typeof(TourSchedule))]
        public void CanCreateNewTour(string Name, DateTime Date, CheckVehicle Vehicle, CheckAvalibleSeats Seats)
        {
            tour.Name = Name;
            tour.Seats = Seats;
            tour.Vehicle = Vehicle;
            tour.Date = Date;
            tours.Add(tour);
            Assert.IsTrue(tour.CanCreateTour);
        }
        [Test]
        public void CheckIfPossibleToCanCreateNewTour()
        {
            var ListOfThrowntours = prog.CheckIfCreateTourIsPossible(tours);
            Assert.AreEqual(ListOfThrowntours, tours);
        }
        public TourSchedule ReturnTourInstance()
        {
            var sut = new TourSchedule();
            return sut;
        }
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(15)]
        [TestCase(0)]
        public void CheckNumberOfToursAdded(int value)
        {
            tour.NumberOfToursAdded = value;
            prog.NumberOftoursAdded(value);
            Assert.IsNotNull(tour.NumberOfToursAdded);
        }
    }
}
