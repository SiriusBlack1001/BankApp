using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //display title 
            Console.WriteLine("Bank App");
            Console.WriteLine("login page");

            //declare variable to store username and password
            string userName = null, passWord = null;

            Console.WriteLine("Username:");
            userName = Console.ReadLine();

            //read password only if username is entered
            if (userName!= "")
            {
                Console.WriteLine("password:");
                passWord = Console.ReadLine();
            }

            //check username and password
            if (userName == "machine" && passWord == "system")
            {
                int mainMenuChoice = -1;
                do
                {
                    

                    Console.WriteLine("\nMain Menu");
                    Console.WriteLine("1. Customers");
                    Console.WriteLine("2. Accounts");
                    Console.WriteLine("3. Fund Transfer");
                    Console.WriteLine("4. Funds Transfer Statement");
                    Console.WriteLine("5. Account Statement");
                    Console.WriteLine("0. Exit");

                    Console.WriteLine($"Enter choice: ");
                    mainMenuChoice = int.Parse(Console.ReadLine());

                    //check menu choice 
                    switch (mainMenuChoice)
                    {
                        case 1: CustomerMenu();//Disaply Customer
                            break;
                        case 2: AccountMenu(); //Disaply Accounts
                            break;
                        case 3: //Disaply Fund transfer
                            break;
                        case 4: //Disaply fund transfer statement
                            break;
                        case 5: //Display Account statement
                            break;
                            ;
                       
                    }
                } while (mainMenuChoice!= 0);
               
            }
            else
                Console.WriteLine("Invalid username or password!!");

            
            Console.WriteLine("Thank you!");
            Console.ReadKey();
            
        }

        static void CustomerMenu()
        {
            //variable customer menu choice
            int customerMenuChoice = -1;

            //do-while loop 
            do
            {
                switch (customerMenuChoice)
                {
                    case 1: //Add customer
                        break;
                    case 2: //view customer
                        break;
                    case 3: //update customer
                        break;
                    case 4: //delete customer 
                        break;
                    
                }
                Console.WriteLine("\nCustomer Menu");
                Console.WriteLine("1. Add Customer ");
                Console.WriteLine("2. View Customer");
                Console.WriteLine("3. Update Customer");
                Console.WriteLine("4. Delete Customer");
                Console.WriteLine("0. Back to main menu");

                Console.Write("Enter choice: ");
                customerMenuChoice = Convert.ToInt32(Console.ReadLine());

                switch (customerMenuChoice)
                {
                    case 1: CustomerPresentation.AddCustomer(); break;
                    case 2: CustomerPresentation.ViewCustomer(); break;
                    case 3: CustomerPresentation.UpdateCustomer(); break;

                }
            } while (customerMenuChoice!= 0);
        }

        static void AccountMenu()
        {
            //variable account menu choice
            int accountMenuChoice = -1;

            //do-while loop 
            do
            {
                switch (accountMenuChoice)
                {
                    case 1: //Add Account
                        break;
                    case 2: //view Account
                        break;
                    case 3: //update Account
                        break;
                    case 4: //delete Account 
                        break;

                }
                Console.WriteLine("\nCustomer Menu");
                Console.WriteLine("1. Add Account ");
                Console.WriteLine("2. View Account");
                Console.WriteLine("3. Update Account");
                Console.WriteLine("4. Delete Customer");
                Console.WriteLine("0. Back to main menu");

                Console.Write("Enter choice: ");
                accountMenuChoice = Convert.ToInt32(Console.ReadLine());


            } while (accountMenuChoice != 0);
        }

        
    }

    
}
