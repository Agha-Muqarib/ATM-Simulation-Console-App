using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ATM_Simulation
{
    class Transactions : Customer
    {

        public string customerID { get; set; }
        public int transactionID { get; set; }
        public string date { get; set; }

        public double accountBalance { get; set; }

        public int i { get; set; }


        Object[] transactionArray = { };

        public void TransactionItems(string cus_id, int amount, double accBal)
        {

            Object[] transactionObj = {

                new { key = "customerID" , value = cus_id },
                new { key = "transactionID", value = i },
                new { key = "date" , value = DateTime.Now.ToString("dddd, dd MMMM yyyy") },
                new { key = "transAmmount", value = amount },
                new { key = "accountBalance", value = accBal }
            };


            // Add Objects at the end of array

            transactionArray = transactionArray.Append(transactionObj).ToArray();

        }

        public void DisplayTransactions()
        { 

        int x = 0;
            foreach (Object[] obj in transactionArray) {
                Console.WriteLine(JsonConvert.SerializeObject(obj, Formatting.Indented));
                Console.WriteLine("x= " + x);
                x = x+1;
            }
        }
    }  
}