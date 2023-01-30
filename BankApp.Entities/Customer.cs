using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Entities.Contracts;
using BankApp.Exceptions;

namespace BankApp.Entities
{
    /// <summary>
    /// Represent customer of the bank
    /// </summary>
    public class Customer : ICustomer, ICloneable
    {

        #region Private fields

        private Guid _customerID;
        private long _customerCode;
        private string _customerName;
        private string _customerAddress;
        private string _customerCity;
        private string _customerCountry;
        private string _customerPhone;
        #endregion



        #region Public Properties
        /// <summary>
        /// Guid respresent the unique identifer of the customer
        /// </summary>
        public Guid CustomerID { get => _customerID; set => _customerID = value; }

        /// <summary>
        /// Auto-generated code number of the customer
        /// </summary>
        public long CustomerCode
        { 
            get => _customerCode;
            set
            {
                if (value>0) 
                {
                    _customerCode = value;
                }
                else
                    throw new CustomerException("customer code should be positive number only");
                
            }
        }

        /// <summary>
        /// Name of the customer
        /// </summary>
        public string CustomerName 
        { 
            get => _customerName;
            set 
            {
                //customer name should be less than 40 characters
                if (value.Length <= 40 && string.IsNullOrEmpty(value) == false)
                {
                    _customerName = value;
                }
                else
                    throw new CustomerException("Customer name should not be null and less than 40 characters long");
                
            } 
        }

        /// <summary>
        /// Address of the customer
        /// </summary>
        public string CustomerAddress { get => _customerAddress; set => _customerAddress = value; }

        /// <summary>
        /// city of the customer
        /// </summary>
        public string CustomerCity { get => _customerCity; set => _customerCity = value; }

        /// <summary>
        /// Country of the customer
        /// </summary>
        public string CustomerCountry { get => _customerCountry; set => _customerCountry = value; }

        /// <summary>
        /// Phone of the customer
        /// </summary>
        public string CustomerPhone
        { 
            get => _customerPhone;
            set 
            {
                //Phone number must be 10 digit 
                if (value.Length == 10)
                {
                    _customerPhone = value;
                }
                else
                    throw new CustomerException("Phone number should be 10-digit.");
                
            } 
        }
        #endregion

        #region Method
        public Object Clone()
        {
            return new Customer() {CustomerID = this.CustomerID, CustomerCode = this.CustomerCode, CustomerName = this.CustomerName, 
            CustomerAddress = this.CustomerAddress,  CustomerCity = this.CustomerCity, CustomerCountry = this.CustomerCountry, 
            CustomerPhone = this.CustomerPhone };
           
        }
        #endregion
    }

}   


