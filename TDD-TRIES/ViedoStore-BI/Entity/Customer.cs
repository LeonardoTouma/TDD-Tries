using System;

namespace ViedoStore_BI
{
    public class Customer
    {
        //customer entity

        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateWhenJoin { get; set; }
        public string SSN { get; set; }
        public bool IsRegisterd { get; set; }
        public Customer()
        {
            DateWhenJoin = DateTime.Now;
            ID++;
        }
    }
}