using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Domain.Customers
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            this.CustomerGuid = Guid.NewGuid();
        }
        /// <summary>
        /// Gets or sets the customer Guid
        /// </summary>
        public Guid CustomerGuid { get; set; }

        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the password
        /// </summary>
        public string Password { get; set; }


    }
}
