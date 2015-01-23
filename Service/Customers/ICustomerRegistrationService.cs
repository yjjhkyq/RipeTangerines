using System;
using Core.Domain;
using Core.Domain.Customers;
namespace Service.Customers
{
    public interface ICustomerRegistrationService
    {
        CustomerRegistrationResult Register(Customer customer);
        CustomerLoginResults ValidateCustomer(string usernameOrEmail, string password);
    }
}
