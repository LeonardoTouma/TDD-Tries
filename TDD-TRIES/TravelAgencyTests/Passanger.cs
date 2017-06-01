using System.Collections.Generic;

namespace TravelAgency
{
    public class Passanger
    {
        public Passanger()
        {
        }

        public object Firstname { get; set; }
        public object Lastname { get; set; }
        public List<Booking> Bookings { get; set; }
        public int ID { get; internal set; }
    }
}