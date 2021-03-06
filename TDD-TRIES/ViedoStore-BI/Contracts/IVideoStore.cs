﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViedoStore_BI
{
    public interface IVideoStore:IRentals
    {
            void RegisterCustomer(string name, string socialSecurityNumber);
            void AddMovie(Movie movie);
            void RentMovie(string movieTitle, string socialSecurityNumber);
            List<Customer> GetCustomers_Thrue_List();
            void ReturnMovie(string movieTitle, string socialSecurityNumber);
    }
}
