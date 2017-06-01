using System;
using System.Collections.Generic;

namespace TravelAgency
{
    //------------------------EX 4------------------------
    //------------------------EX 4------------------------
    //------------------------EX 4------------------------
    //------------------------EX 4------------------------
    //------------------------EX 4------------------------
    //------------------------EX 4------------------------
    public interface ITourSchedule
    {
        void CanCreateNewTour(string Name, DateTime Date, CheckVehicle Vehicle, CheckAvalibleSeats Seats);
        void CheckIfPossibleToCanCreateNewTour();
        TourSchedule ReturnTourInstance();
        void CheckNumberOfToursAdded(int value);
        List<TourSchedule> GetTours();

    }
}