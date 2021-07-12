using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Name: Michael Mena
 * Date: 10/29/2020
 * This program is a Windows form application that gets the info of an order at a hair salon and displays each option witht eh corresponding price
 * I, Michael Mena, 000817498 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
 */
namespace Lab3B
{
    /*This class is a base that will hold the name of each service aswell as the corresponding price
     */
    public class chargeAble
    {

        public string Name; // The name of each service
        public double Price; // The price of each service
        /*
         * the constructor for the chargeAble class
         * takes the name and price of the seervice and then creates it
         */
        public chargeAble(String name, double price)
        {
            Name = name; // sets the name of the service
            Price = price; // Sets the price of the service
        }
       

    }
}
