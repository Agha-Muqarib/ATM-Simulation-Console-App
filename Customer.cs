using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ATM_Simulation
{
    class Customer
    {
        // Fields or Attributes

        public string customerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int accountCardNumber { get; set; }
        public int pinNumber { get; set; }
        public double accountBalance { get; set; }

        // Constructor 

        public Customer(){}

        public Customer(string cus_ID, string fName, string lName, int accountNum, int pinNum, double accountBal)
        {
            this.customerID = cus_ID;
            this.firstName = fName;
            this.lastName = lName;
            this.accountCardNumber = accountNum;
            this.pinNumber = pinNum;
            this.accountBalance = accountBal;
        }


    // Methods

    public void DisplayRecord()
        {
            string record = $"\nThe account number {accountCardNumber} belongs to ID:{customerID}, {firstName} {lastName}, " +
                             $"pin number {pinNumber}, with an available balance equal to PKR. {accountBalance} /= ";
            Console.WriteLine(record);
        }

        public void validation()
        {

            try
            {
                // Taking Account Input
                Console.WriteLine("\nEnter Card Number: ");
                int enteredAccNo = Convert.ToInt32(Console.ReadLine());

                if (enteredAccNo == accountCardNumber)
                {

                    Console.WriteLine("\nAccount Verified!" + "\n" );

                    Console.WriteLine("Enter Pin Number: ");
                    int enteredPinNo = Convert.ToInt32(Console.ReadLine());

                    // Taking Pin Input

                    try
                    {

                        if (enteredPinNo == pinNumber)
                        {
                            Console.WriteLine("\nPin Verified ! " + "\n" );

                            DisplayRecord();
                            ProcessOptions();
                        }

                        else
                        {
                            throw new InvalidOperationException("\nInvalid Pin Number");
                        }

                    }
                    catch
                    {
                        Console.WriteLine("\nEnter Valid Pin Number.");
                    }

                }

                else
                {
                    throw new InvalidOperationException("\nInvalid Account Number");

                }
                
            }

            catch {
                Console.WriteLine("\nEnter Valid Account Number.");
            }

        }

        public void ProcessOptions()
        {
            Console.WriteLine("\nWelcome!\n");
            Console.WriteLine("Press 1 to View Transations." + "\n" +
                              "Press 2 to Withdraw Amount." + "\n" +
                              "Press 3 to change Pin-Code." + "\n");

            string mainOption = Console.ReadLine();


            switch (mainOption)
            {
                case "1":
                
                    Console.WriteLine("\nWelcome to Transactions");
                    break;

                case "2":
                    Console.WriteLine("\nSelect WithDrawal Method:");

                    Console.WriteLine("\nPress 1 for Fast Cash Withdrawal." + "\n" +
                                      "Press 2 to Custom Cash Withdrawal." + "\n");

                    string subOption = Console.ReadLine();

                  
                    if (subOption == "1")
                    {
                        //Console.WriteLine("fast withdrawal");
                        FastCashWithdrawal();
                    }   

                    else if (subOption == "2")
                    {
                        //Console.WriteLine("custom withdrawal");
                        customCashWithdrawal();
                    }

                    else
                    {
                        throw new InvalidOperationException("\nInvalid Option. Select from the given options.");
                    }
                    break;

                case "3":
                    //Console.WriteLine(Pin Number);
                    changePin();
                    break;
            }
            
        }


        public void FastCashWithdrawal()
        {
            Console.WriteLine("\nWelcome to fast Cash Withdrawal.\n");

            Console.WriteLine("Press 1 to withdraw PKR. 100 /= " + "\n" +
                               "Press 2 to withdraw PKR. 500 /= " + "\n" +
                               "Press 3 to withdraw PKR. 1000 /= " + "\n");

            int amount;

            string amountOption = Console.ReadLine();

            switch (amountOption) {

                case "1":

                    amount = 100;

                    if (amount < accountBalance)
                    {
                        accountBalance = accountBalance - amount;
                        Console.WriteLine("\nTransaction successfull. Your updated balance is PKR." + accountBalance + "/=");
                    }

                    else {
                        Console.WriteLine("\nTransaction unsuccessful due to Insufficient Account Balance which is PKR. " + accountBalance + "/=");
                    }
                    break;

                case "2":

                    amount = 500;

                    if (amount < accountBalance)
                    {
                        accountBalance = accountBalance - amount;
                        Console.WriteLine("\nTransaction successfull. Your updated balance is PKR." + accountBalance + "/=");
                    }

                    else
                    {
                        Console.WriteLine("\nTransaction unsuccessful due to Insufficient Account Balance which is PKR. " + accountBalance + "/=");
                    }

                    break;

                    case "3":

                    amount = 1000;
                    if (amount < accountBalance)
                    {
                        accountBalance = accountBalance - amount;
                        Console.WriteLine("\nTransaction successfull. Your updated balance is PKR." + accountBalance + "/=");
                    }

                    else
                    {
                        Console.WriteLine("\nTransaction unsuccessful due to Insufficient Account Balance which is PKR. " + accountBalance + "/=");
                    }

                    break;
            
            }
        }

        public void customCashWithdrawal()
        {
            Console.WriteLine("\nWelcome to Custom Cash Withdrawal.");
        }

        public void changePin()
        {
            Console.WriteLine("\nEnter your current Pin-Number:");
            int i = 0;
            int j = 3;

            int currentPin;

            while (i < 3)
            {
                currentPin = Convert.ToInt32(Console.ReadLine());

                if (currentPin == pinNumber)
                {
                    Console.WriteLine("\nPin Verified." +
                                      "\nEnter your new Pin:");

                    int newPin = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("newPin = " + newPin);
                    Console.WriteLine("pinNumber = " + pinNumber);

                    if (newPin.ToString().Length == 4)
                    {
                        pinNumber = newPin;

                        Console.WriteLine("pinNumber = " + pinNumber);

                        Console.WriteLine("\nPin Reset Successfull."
                                + "\nYour new pin is " + pinNumber);
                        break;
                    }
                
                    else
                    {
                        Console.WriteLine("\nPin should be equal to 4 digits. Enter pin again: ");
                        Console.WriteLine("You have " + j + " tries left.");
                        i++;
                        j--;
                    } 
                }

                else
                {
                        Console.WriteLine("\nInvalid Pin. Enter pin again: ");
                        Console.WriteLine("You have " + j + " tries left.");
                        i++;
                        j--;
                    
                }
            }
        }

       /* public void handleTransactions()
        {
            Console.WriteLine("\nWelcome to transactions");
        } */
    }
}
