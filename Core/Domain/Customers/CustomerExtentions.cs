using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Domain.Customers
{
    public static class CustomerExtentions
    {
        /// <summary>
        /// Gets a value indicating whether customer is registered
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="onlyActiveCustomerRoles">A value indicating whether we should look only in active customer roles</param>
        /// <returns>Result</returns>
        public static bool IsRegistered(this Customer customer, bool onlyActiveCustomerRoles = true)
        {
            if (string.IsNullOrEmpty(customer.Username))
                return false;
            return false;
        }
    }
}
