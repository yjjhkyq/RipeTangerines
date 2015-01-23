using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Domain;
using Core.Data;
using Core.Domain.Customers;
namespace Service.Customers
{
    public partial class CustomerService : ICustomerService
    {
        IRepository<Customer> _customerRepository;
     

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer GetCustomerByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                return null;
            var customer = (from c in _customerRepository.Table
                           where c.Username == username
                           select c).FirstOrDefault();
            return customer;
        }

        public void Insert(Customer customer)
        {
            _customerRepository.Insert(customer);
        }
    }
}
