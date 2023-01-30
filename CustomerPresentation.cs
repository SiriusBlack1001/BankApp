using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Entities;
using BankApp.Exceptions;
using BankApp.BusinessLogic;
using BankApp.BusinessLogic.BALContracts;
using BankApp.Entities.Contracts;

namespace BankApp
{
    static class CustomerPresentation
    {
        internal static void AddCustomer()
        {
            try
            {
                //create an object of Customer
                Customer customer = new Customer();

                //read all details from the user
                Console.WriteLine("\n****ADD CUSTOMER****");
                Console.Write("Customer Name: ");
                customer.CustomerName = Console.ReadLine();
                Console.Write("Customer Address: ");
                customer.CustomerAddress = Console.ReadLine();
                Console.Write("Customer City: ");
                customer.CustomerCity = Console.ReadLine();
                Console.Write("Customer Country: ");
                customer.CustomerCountry = Console.ReadLine();
                Console.Write("Customer Phone: ");
                customer.CustomerPhone = Console.ReadLine();

                //create BAl object
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomerBusinessLogicLayer();
                Guid newGuid = customersBusinessLogicLayer.AddCustomer(customer);
               
                List<Customer> matchingCustomers = customersBusinessLogicLayer.GetCustomerByCondition(item=> item.CustomerID == newGuid);
                if (matchingCustomers.Count >= 1)
                {
                    Console.WriteLine("New Customer Code:" + matchingCustomers[0].CustomerCode);
                    Console.WriteLine("Customer Added.\n");
                }
                else
                    Console.WriteLine("Customer not added");
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
            
        }

        internal static void ViewCustomer()
        {
            try
            {
                //create BAl object
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomerBusinessLogicLayer();

                List<Customer> allCustomers = customersBusinessLogicLayer.GetCustomers();
               

                Console.WriteLine("\n***ALL CUSTOMER***");
                //read all customers
                foreach (var item in allCustomers)
                {
                    Console.WriteLine("Customer Code:" + item.CustomerCode);
                    Console.WriteLine("Customer Name:" + item.CustomerName);
                    Console.WriteLine("Customer Address:" + item.CustomerAddress);
                    Console.WriteLine("Customer City:" + item.CustomerCity);
                    Console.WriteLine("Customer Country:" + item.CustomerCountry);
                    Console.WriteLine("Customer Phone:" + item.CustomerPhone);
                    Console.WriteLine();
                }

                var updatedCustomerInfo = allCustomers.FirstOrDefault(item => item.CustomerCode == 1001);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void UpdateCustomer()
        {
            try
            {
                //create BAl object
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomerBusinessLogicLayer();
                
                List<Customer> existingCustomers = customersBusinessLogicLayer.GetCustomers();

                var updateCustomer = existingCustomers.FirstOrDefault(x => x.CustomerCode == 1001);

                
                if (existingCustomers.Any())
                {
                    foreach (var item in existingCustomers)
                    {
                        Console.WriteLine("Customer Code:" + item.CustomerCode);
                        Console.WriteLine("Customer Name:" + item.CustomerName);
                        Console.WriteLine("Customer Address:" + item.CustomerAddress);
                        Console.WriteLine("Customer City:" + item.CustomerCity);
                        Console.WriteLine("Customer Country:" + item.CustomerCountry);
                        Console.WriteLine("Customer Phone:" + item.CustomerPhone);
                        Console.WriteLine("\n");
                    }

                    Console.WriteLine("\n***UPDATE CUSTOMER INFROMATION***");
                    //read all customers
                    Console.Write("Customer Name: ");
                    updateCustomer.CustomerName = Console.ReadLine();
                    Console.Write("Customer Address: ");
                    updateCustomer.CustomerAddress = Console.ReadLine();
                    Console.Write("Customer City: ");
                    updateCustomer.CustomerCity = Console.ReadLine();
                    Console.Write("Customer Country: ");
                    updateCustomer.CustomerCountry = Console.ReadLine();
                    Console.Write("Customer Phone: ");
                    updateCustomer.CustomerPhone = Console.ReadLine();
                    Console.WriteLine("Customer Information Updated.\n");
                }
                else
                    Console.WriteLine("Customer information not update");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }
    }
}
