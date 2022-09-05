using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_Simulation
{
     class Transactions : Customer
    {

        public string customerID { get; set; }
        public string transactionID { get; set; }
        public string date { get; set; }
        public double accountBalance { get; set; }



        public Transactions(string cus_id, string trans_id, double accBal)
        {
            customerID = cus_id;
            transactionID = trans_id;
            date = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            accountBalance = accBal;
        }

        public void displayAccountNumber()
        {
            Console.WriteLine("ID=" + customerID + ", balance = " + accountBalance);
        }
    }
}