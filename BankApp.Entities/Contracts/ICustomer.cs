using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Entities.Contracts
{
    /// <summary>
    /// Represents interface of the customer entity
    /// </summary>
    public interface ICustomer
    {
        #region Properties

        Guid CustomerID { get; set; }
        long CustomerCode { get; set; }
        string CustomerName { get; set; }   
        string CustomerAddress { get; set; }
        string CustomerCity { get; set; }
        string CustomerCountry { get; set; }
        string CustomerPhone { get; set; }
        #endregion
    }

}
