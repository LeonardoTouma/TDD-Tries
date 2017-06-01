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
    public class TourScheduleTests:ITourSchedule
    {
        TourSchedule tour = new TourSchedule();
        private List<TourSchedule> tours = new List<TourSchedule>();
        TravelAgency.Program prog = new Program();
        [Test,TestCaseSource(typeof(TourSchedule))]
        public void CanCreateNewTour(string Name, DateTime Date, CheckVehicle Vehicle, CheckAvalibleSeats Seats)
        {
            tour.Name = Name;
            tour.Seats = Seats;
            tour.Vehicle = Vehicle;
            tour.Date = Date;
            tours.Add(tour);
            Assert.IsTrue(tour.CanCreateTour);
            Assert.IsNotNull(tour.NumberOfToursAdded);
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
        [TestCase(-1)]
        public void CheckNumberOfToursAdded(int value)
        {
            tour.NumberOfToursAdded = value;
            prog.NumberOftoursAdded(value);
            if (value <= 0)
            {
                Assert.IsNotNull(tour.NumberOfToursAdded);
            }
        }
        public List<TourSchedule> GetTours()
        {
            return tours;
        }
    }
}
