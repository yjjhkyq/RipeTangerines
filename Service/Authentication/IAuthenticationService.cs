using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Domain;
using Core.Domain.Customers;

namespace Service.Authentication
{
    public interface IAuthenticationService
    {
        void SignIn(Customer customer, bool createPersistentCookie);
        void SignOut();
        Customer GetAuthenticatedCustomer();
    }
}
