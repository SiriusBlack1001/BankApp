using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bankApp.DataAccessLayer;
using bankApp.DataAccessLayer.DContracts;
using BankApp.BusinessLogic.BALContracts;
using BankApp.Entities;
using BankApp.Exceptions;

namespace BankApp.BusinessLogic
{
    /// <summary>
    /// Represents customer business logic
    /// </summary>
    public class CustomerBusinessLogicLayer:ICustomersBusinessLogicLayer
    {
        #region Private Fields
        private ICustomersDataAccessLayer _customersDataAccessLayer;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor that initializes CustomersDataAccessLayer
        /// </summary>
        public CustomerBusinessLogicLayer()
        {
            _customersDataAccessLayer = new CustomerDataAccessLayer();
        }
        #endregion

        #region Propertise
        /// <summary>
        /// Private property that represents reference of CustomersDataAccessLayer
        /// </summary>
        private ICustomersDataAccessLayer CustomersDataAccessLayer
        {
            set=> _customersDataAccessLayer = value;
            get => _customersDataAccessLayer;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Return all exisiting customers
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomers()
        {
            try
            {
                //invoke D
                return CustomersDataAccessLayer.GetCustomers();
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
        /// Returns a set of customers that matches with specified criteria
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>The list of matching customers</returns>
        public List<Customer> GetCustomerByCondition(Predicate<Customer> predicate)
        {
            try
            {
                //invoke D
                return CustomersDataAccessLayer.GetCustomerByCondition(predicate);
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
        /// Adds a new customer to the existing customers list
        /// </summary>
        /// <param name="customer">The customer objetcs to add</param>
        /// <returns>Returns true that indicates the customer us added successfully</returns>
        public Guid AddCustomer(Customer customer)
        {
            try
            {
                // get all customers
                List<Customer> allCustomers = CustomersDataAccessLayer.GetCustomers();
                long maxCustCode = 0;
                foreach (var item in allCustomers)
                {
                    if (item.CustomerCode > maxCustCode)
                    {
                        maxCustCode = item.CustomerCode;
                    }
                }
                //generate new customer number
                if (allCustomers.Count >= 1)
                {
                    customer.CustomerCode = maxCustCode + 1;
                }
                else
                    customer.CustomerCode = BankApp.Configuration.Settings.BaseCustomerNo + 1;

                //invoke D
                return CustomersDataAccessLayer.AddCustomer(customer);
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
        /// Update the exisiting customer
        /// </summary>
        /// <param name="customer">Customer object that contains the customer details to update</param>
        /// <returns>Returns true that indicate the customer is uodated successfuly</returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                //invoke D
                return CustomersDataAccessLayer.UpdateCustomer(customer);
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
        /// Deletes an exisiting customer
        /// </summary>
        /// <param name="customerID">Customer to delete</param>
        /// <returns>indicate the customer is deleted successfully</returns>
        public bool DeleteCustomer(Guid customerID)
        {
            try
            {
                //invoke D
                return CustomersDataAccessLayer.DeleteCustomer(customerID);
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
        #endregion
    }
}
