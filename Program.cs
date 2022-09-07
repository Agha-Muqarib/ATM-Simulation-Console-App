using System;
using System.Diagnostics;

namespace ATM_Simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating Customer Records

            Customer Agha = new Customer("C-001", "Agha", "Muqarib", 12345, 1234, 20000.25);
            /*    Customer Aamir = new Customer("Aamir", "Arshad", 89756, 2222, 15000.25);
                Customer Majid = new Customer("Majid", "Khan", 21475, 0123, 30000.25);
                Customer Saleem = new Customer("Saleem", "Jatoi", 65879, 4567, 21000.25);
                Customer Faheem = new Customer("Faheem", "Aziz", 02515, 6789, 10000.25);

                */


            Transactions t1 = new Transactions(Agha.customerID, "T-001", Agha.accountBalance);

            // Driver Code

            Console.WriteLine("\nWelcome to ATM.\n\nPlease Select your Option:");

            bool visitflag = false;

            while (true) {


                Console.WriteLine("\nPress 1 for the Main Menu" + "\n" +
                                     "Press 2 to Exit." + "\n");


                string app = Console.ReadLine();

                if (app == "1")
                {
                    if (visitflag == false)
                    {
                        Agha.validation();
                       // Agha.DisplayRecord();
                        visitflag = true;
                    }

                    else
                    {
                        Agha.ProcessOptions();
                    }
                }

                else if (app == "2")
                {

                    Console.WriteLine("\nThankyou, see you later :)\n\n");
                    break;
                }

                else
                {
                    Console.WriteLine("\nInvalid Input\n");
                }
            }
            
        }

    }
}
