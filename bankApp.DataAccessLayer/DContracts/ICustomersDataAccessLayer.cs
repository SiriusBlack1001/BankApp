using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Entities;

namespace bankApp.DataAccessLayer.DContracts
{
    /// <summary>
    /// interface represents customer data access layer
    /// </summary>
    public interface ICustomersDataAccessLayer
    {
        /// <summary>
        /// Return all exisiting customers
        /// </summary>
        /// <returns></returns>
        List<Customer> GetCustomers();

        /// <summary>
        /// Returns a set of customers that matches with specified criteria
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>The list of matching customers</returns>
        List<Customer> GetCustomerByCondition(Predicate<Customer> predicate);

        /// <summary>
        /// Adds a new customer to the existing customers list
        /// </summary>
        /// <param name="customer">The customer objetcs to add</param>
        /// <returns>Returns true that indicates the customer us added successfully</returns>
        Guid AddCustomer(Customer customer);

        /// <summary>
        /// Update the exisiting customer
        /// </summary>
        /// <param name="customer">Customer object that contains the customer details to update</param>
        /// <returns>Returns true that indicate the customer is uodated successfuly</returns>
        bool UpdateCustomer(Customer customer);

        /// <summary>
        /// Deletes an exisiting customer
        /// </summary>
        /// <param name="customerID">Customer to delete</param>
        /// <returns>indicate the customer is deleted successfully</returns>
        bool DeleteCustomer(Guid customerID);
    }
}
