using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Exceptions
{
    /// <summary>
    /// Exeception class that represents validation erros raised in customer class 
    /// </summary>
    public class CustomerException:ApplicationException
    {
        /// <summary>
        /// Constructor that initializes exception message
        /// </summary>
        /// <param name="message"></param>
        public CustomerException(string message):base(message)
        {

        }

        /// <summary>
        /// Constructor that initializes exception message and inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public CustomerException(string message, Exception innerException):base(message, innerException)
        {

        }
        
    }
}
