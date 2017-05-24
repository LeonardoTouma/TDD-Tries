using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViedoStore_TESTS.WhatKindOfTestsWeNeed
{
    /*
     * PRIO 1 FOR IRENTALS: 
     * ---------
     Being able to add a rental.
     All rentals will get a 3 day later due date.
     Should be able to get rentals by social security number.
     Can rent more than one movie.
     Cannot rent more than 3 movies (So renting a fourth is not allowed).
     Customers may not posses two copies of the same movie. 
     Customers may not rent anymore movies if they possess movies with a late due date (Tell don't ask here... The exception we throw here should
     give us a message including all the movies that are late. Also the due dates of these movies should be printed).
     ----------------------------------------------------------------------------------------------------------------
        PRIO 1 FOR IVIDEOSTORE:
            A movie title cannot be empty.
            Adding a fourth copy of the same movie should not be possible.
            We shouln't be able to add the same customer twice.
            When adding a customer we must use the following format on the socialSecurityNumber: "YYYY-MM-DD" where the letters are representing integers.
            We should not be able to rent a non existent movie. (Tests like this should check that we are not calling the IRentals implementation .AddRental() ).
            A customer that is not registered cannot rent a movie.
      */
}
