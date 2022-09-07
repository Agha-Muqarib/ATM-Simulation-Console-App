using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml;
using Newtonsoft.Json;

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

        public Customer() { }

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


        // Validations and verifications
        public void validation()
        {

            try
            {
                // Taking Account Number Input
                Console.WriteLine("\nEnter Card Number: ");
                int enteredAccNo = Convert.ToInt32(Console.ReadLine());

                if (enteredAccNo == accountCardNumber)
                {

                    Console.WriteLine("\nAccount Verified!" + "\n");

                    Console.WriteLine("Enter Pin Number: ");
                    int enteredPinNo = Convert.ToInt32(Console.ReadLine());

                    // Taking Pin Input

                    try
                    {

                        if (enteredPinNo == pinNumber)
                        {
                            Console.WriteLine("\nPin Verified ! " + "\n");

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

        // Options for user

        public void ProcessOptions()
        {
            Console.WriteLine("\nWelcome!\n");
            Console.WriteLine("Press 1 to Withdraw Amount." + "\n" +
                              "Press 2 to change Pin-Code." + "\n");

            string mainOption = Console.ReadLine();


            switch (mainOption)
            {
               
                case "1":
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
                        CustomCashWithdrawal();
                    }

                    else
                    {
                        throw new InvalidOperationException("\nInvalid Option. Select from the given options.");
                    }
                    break;

                case "2":
                    //Console.WriteLine(Pin Number);
                    ChangePin();
                    break;


            }

        }

       // Fast Cash Withdrawal

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

                        Transactions transaction = new Transactions();
                        transaction.TransactionItems(customerID, amount, accountBalance);
                        transaction.DisplayTransactions();

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

        // Custom Cash Withdrawal

        public void CustomCashWithdrawal()
        {
            Console.WriteLine("\nWelcome to Custom Cash Withdrawal.");

            DayOfWeek transactionTimeDay = DateTime.Now.DayOfWeek; ;
            int transactionLimit = 5;
            DayOfWeek currentDay = DateTime.Now.DayOfWeek;

            while (transactionTimeDay == currentDay)
            { 

                if (transactionLimit != 0)
                {
                    Console.WriteLine("\nEnter the amount you wish to withdraw:");
                    int transactionAmount = Convert.ToInt32(Console.ReadLine());

                    if (transactionAmount <= 1000)
                    {
                        accountBalance = accountBalance - transactionAmount;
                        Console.WriteLine("\nAmount Withdrawal successful. Your new account balance is PKR. " + accountBalance + "/=\n");
                        transactionLimit--;
                        Console.WriteLine("\nYou've " + transactionLimit + " Transactions left for today.\nPress 1 to transact again.\nPress 2 to exit.");

                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice == 2)
                        {
                            Console.WriteLine("\nThankyou, see you later.");
                            break;
                        }
                    }

                    else
                    {
                        Console.WriteLine("\nAmount cannot be greater than PKR. 1000/=");
                    }

                }
                
                else
                {
                    Console.WriteLine("\nThe transaction limit for today is exceeded.");
                    break;
                
                }    
            }
        }

        // Change Pin Number
        public void ChangePin()
        {
            Console.WriteLine("\nEnter your current Pin-Number:");
            int i = 0;
            int j = 2;

            int currentPin;

            while (i < 3)
            {
                currentPin = Convert.ToInt32(Console.ReadLine());

                if (currentPin == pinNumber)
                {
                    Console.WriteLine("\nPin Verified.\n\nEnter your new Pin:");

                    int newPin = Convert.ToInt32(Console.ReadLine());

                    //Console.WriteLine("newPin = " + newPin);
                   // Console.WriteLine("pinNumber = " + pinNumber);

                    if (newPin.ToString().Length == 4)
                    {
                        pinNumber = newPin;

                        //Console.WriteLine("pinNumber = " + pinNumber);

                        Console.WriteLine("\nPin Reset Successfull."
                                + "\nYour new pin is " + pinNumber + ".");
                        DisplayRecord();
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

                    if (j < 0)
                    {
                        Console.WriteLine("\nYou've no tries left. Account is suspended for a day. Be back tomorrow.");
                    }
                    
                }
            }
        }
    }
}
