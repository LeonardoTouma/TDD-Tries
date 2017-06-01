using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class Program
    {
        //List<TourSchedule> tours = new List<TourSchedule>();
        static void Main(string[] args)
        {
           
        }
        public List<TourSchedule> CheckIfCreateTourIsPossible(List<TourSchedule> tours)
        {
            foreach (var item in tours)
            {
                switch(item.Seats)
                {
                    case CheckAvalibleSeats.Seat1:
                        item.Seats = CheckAvalibleSeats.Seat1;
                        break;
                    case CheckAvalibleSeats.Seat2:
                        item.Seats = CheckAvalibleSeats.Seat2;
                        break;
                    case CheckAvalibleSeats.Seat3:
                        item.Seats = CheckAvalibleSeats.Seat3;
                        break;
                    case CheckAvalibleSeats.Seat4:
                        item.Seats = CheckAvalibleSeats.Seat4;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
                switch (item.Vehicle)
                {
                    case CheckVehicle.Ford1:
                        item.Vehicle = CheckVehicle.Ford1;
                        break;
                    case CheckVehicle.Ford2:
                        item.Vehicle = CheckVehicle.Ford2;
                        break;
                    case CheckVehicle.Ford3:
                        item.Vehicle = CheckVehicle.Ford3;
                        break;
                    case CheckVehicle.Ford4:
                        item.Vehicle = CheckVehicle.Ford4;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
            return tours;

        }
        public int NumberOftoursAdded(int tour)
        {
            int nr = 0;
            if (tour != nr )
            {
                if (tour <= 3)
                {
                    return tour;
                }
                return nr;
            }
            return nr;
        }
    }
}
