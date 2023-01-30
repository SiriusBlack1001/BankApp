using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Entities;
using BankApp.Exceptions;
using bankApp.DataAccessLayer.DContracts;

namespace bankApp.DataAccessLayer
{
    /// <summary>
    /// Represent Data for bank customers
    /// </summary>
    public class CustomerDataAccessLayer:ICustomersDataAccessLayer
    {
        #region Fields
        private static List<Customer> _customer;
        #endregion

        #region Constructors
        static CustomerDataAccessLayer()
        {
            _customer = new List<Customer>();  
        }
        #endregion


        #region Properties
        /// <summary>
        /// Represent source customers collection
        /// </summary>
        private static List<Customer> Customers
        {
            set=> _customer = value;
            get => _customer;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns all exisiting customer
        /// </summary>
        /// <returns></returns>
        public List<Customer>GetCustomers()
        {
            try
            {
                //create a new customer list
                List<Customer> customerList = new List<Customer>();

                //copy all customers from the source collection into the new Customer list
                Customers.ForEach(item => customerList.Add(item.Clone() as Customer));
                return customerList;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        /// <summary>
        /// Returns list of customers that are matching with specified criteria
        /// </summary>
        /// <param name="predicate">Lambda Expression with condition</param>
        /// <returns>list of matching customers</returns>
        
        public List<Customer> GetCustomerByCondition(Predicate<Customer> predicate)
        {
            try
            {
                //create a new customer list
                List<Customer> customerList = new List<Customer>();

                //filter the collection
                List<Customer> filteredcustomers = Customers.FindAll(predicate);

                //copy all customers from the source collection into the new Customer list
                filteredcustomers.ForEach(item => customerList.Add(item.Clone() as Customer));
                return customerList;    
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }

           
        }

        /// <summary>
        /// Adds a new customer to the exisiting list
        /// </summary>
        /// <param name="customer">Customer object to add</param>
        /// <returns>Returns Guid of newly created customer</returns>
        public Guid AddCustomer(Customer customer)
        {
            try
            {
                //generate new Guid
                customer.CustomerID = Guid.NewGuid();

                //add customer
                Customers.Add(customer);
                return customer.CustomerID;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        /// <summary>
        /// Updates an exisiting customers details
        /// </summary>
        /// <param name="customer">Customer object with update details</param>
        /// <returns>determines whether the customers is updated or not</returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                //find exisiting customer by CustomerID
                Customer exisitngCustomer = Customers.Find(item => item.CustomerID == customer.CustomerID);

                //udate all details of customer
                if (exisitngCustomer != null)
                {
                    exisitngCustomer.CustomerCode = customer.CustomerCode;
                    exisitngCustomer.CustomerName = customer.CustomerName;
                    exisitngCustomer.CustomerAddress = customer.CustomerAddress;
                    exisitngCustomer.CustomerCity = customer.CustomerCity;
                    exisitngCustomer.CustomerCountry = customer.CustomerCountry;
                    exisitngCustomer.CustomerPhone = customer.CustomerPhone;

                    return true;//indicate the customer infromation is updated
                }
                else
                    return false; //existing customer not find!
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        /// <summary>
        /// deletes an existing customer based on CustomerID
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns>Indicate whether the customer is deleted or not</returns>
        public bool DeleteCustomer(Guid customerID)
        {
            try
            {
                if (Customers.RemoveAll(item => item.CustomerID == customerID) > 0)
                {
                    return true;//indicate one or more customer are deleted
                }
                else
                    return false;//indicate no customer is deleted
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
            //delete customer by CustomerID
            
        }



        #endregion
    }
}
