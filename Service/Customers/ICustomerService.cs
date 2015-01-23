using System;
using Core.Domain;
using Core.Domain.Customers;
namespace Service.Customers
{
    public interface ICustomerService
    {
        Customer GetCustomerByUsername(string username);
        void Insert(Customer customer);
    }
}
