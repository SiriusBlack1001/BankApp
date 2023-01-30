using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Configuration
{
    /// <summary>
    /// Project level Configuration setting
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Customer number starts from 1001; incremented by 1
        /// </summary>
        public static long BaseCustomerNo { get; set; } = 1000;
    }
}
