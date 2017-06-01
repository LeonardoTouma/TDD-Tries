using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{

    //------------------------EX 4------------------------
    //------------------------EX 4------------------------
    //------------------------EX 4------------------------
    //------------------------EX 4------------------------
    //------------------------EX 4------------------------
    //------------------------EX 4------------------------
    [TestFixture]
    class BookingSystemTests : ITourSchedule
    {
        //private TourSchedule ItourSchedule;
        private List<TourSchedule> tours;
        private List<Booking> bookings;
        [SetUp]
        public void SetUpMethod()
        {
            var sut = ReturnTourInstance();
            //CanCreateBooking();

        }
        public TourSchedule ReturnTourInstance()
        {
            var sut = new TourSchedule();
            return sut;
        }

        //-------------------------------------------------

        public void CanCreateBooking(Booking booking, Passanger passanger)
        {
            tours = new List<TourSchedule>()
            {
                new TourSchedule
            {
                Date = DateTime.Now, Name = "Tour1",
                Seats = CheckAvalibleSeats.Seat1,
                Vehicle = CheckVehicle.Ford1,
                CanCreateTour =true  } };
            var booking1 = new Booking()
            {
                Tours = tours,
                ID = booking.ID,
            };
            bookings.Add(booking1);

            //---------------------------------------
            //---------------------------------------
            //---------------------------------------
            //---------------------------------------
            var passanger1 = new Passanger()
            {
                Firstname = passanger.Firstname,
                Lastname = passanger.Lastname,
                Bookings = new List<Booking>()
                {
                    new Booking()
                {
                     ID = passanger.ID, Tours = new List<TourSchedule>()
                    {
                    new TourSchedule()
                    {
                     Vehicle = CheckVehicle.Ford2, Name = "tour1", Seats = CheckAvalibleSeats.Seat2,
                        CanCreateTour = true, Date = DateTime.Now, }}}
                }
                
            };
            booking.Passangers.Add(passanger1);
            GetBookingsFor(passanger1, booking);
        }
        [TestCaseSource(typeof(Booking))]
        [TestCaseSource(typeof(Passanger))]
        public List<Booking> GetBookingsFor(Passanger passanger, Booking booking/*TourSchedule tour*/)
        {
            //var booking1 = new Booking();
            Assert.Contains(booking, bookings);
            //Assert.ReferenceEquals(booking, tour);
            Assert.ReferenceEquals(booking, passanger);
            return bookings;
        }
        [TestCaseSource(typeof(Booking))]
        [TestCaseSource(typeof(TourSchedule))]
        public void Check_If_Able_To_Book_On_Non_Existing_Tour(Booking booking, TourSchedule tour)
        {
            //var tour = new List<TourSchedule>() { new TourSchedule { CanCreateTour = true, Date = DateTime.Now, Name = "tour3", Seats = CheckAvalibleSeats.Seat1, Vehicle = CheckVehicle.Ford2 } };
            var book = new Booking() { Tours = new List<TourSchedule>() { new TourSchedule() { CanCreateTour = true, Date = DateTime.Now, Name = "tour3", Seats = CheckAvalibleSeats.Seat4, Vehicle = CheckVehicle.Ford3 } } };
            var tour1 = new TourSchedule()
            {
                CanCreateTour = tour.CanCreateTour,
                Date = tour.Date,
                Name = tour.Name,
                Seats = tour.Seats,
                Vehicle = tour.Vehicle
            };
            foreach (var item in book.Tours)
            {
                if (book.Tours.Count() > 0)
                {
                    if (!book.Tours.Contains(tour1))
                    {
                        Assert.ReferenceEquals(book.Tours, tour1);
                        Assert.AreNotEqual(tour1, tour);
                    }
                    else
                    {
                        bookings = new List<Booking>();
                        bookings.Add(book);
                    }
                }
                if (tour.check.Count() == book.Passangers.Count())
                {
                    Assert.AreEqual(tour.check.Count(), book.Passangers.Count());
                    Console.WriteLine("No more seats avalible.");
                }
                else if (tour.check.Count() > book.Passangers.Count())
                {
                    throw new InvalidOperationException();
                }
                else if (tour.check.Count() < book.Passangers.Count())
                {
                    Console.WriteLine("Create a new tour.");
                }
            }
            
        }
        public void CanCreateNewTour(string Name, DateTime Date, CheckVehicle Vehicle, CheckAvalibleSeats Seats)
        {
            throw new NotImplementedException();
        }

        public void CheckIfPossibleToCanCreateNewTour()
        {
            throw new NotImplementedException();
        }

        public void CheckNumberOfToursAdded(int value)
        {
            throw new NotImplementedException();
        }
        public List<TourSchedule> GetTours()
        {
            return tours;
        }


    }
}
