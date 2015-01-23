using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Data;
using Core.Domain;
using Core.Domain.Customers;

namespace Service.Customers
{
    public partial class CustomerRegistrationService : ICustomerRegistrationService
    {
        private ICustomerService _customerService;

        public CustomerRegistrationService(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public CustomerRegistrationResult Register(Customer customer)
        {
            CustomerRegistrationResult customerRegistrationResult = new CustomerRegistrationResult();
            Customer cus = _customerService.GetCustomerByUsername(customer.Username);
            var result = new CustomerRegistrationResult();
            if (null != cus)
            {
                result.AddError("用户已经存在");
            }
            _customerService.Insert(customer);
            return result;
        }


        public CustomerLoginResults ValidateCustomer(string usernameOrEmail, string password)
        {
            Customer customer = _customerService.GetCustomerByUsername(usernameOrEmail);
            if (null == customer)
                return CustomerLoginResults.CustomerNotExist;
            if (!customer.Password.Equals(password))
            {
                return CustomerLoginResults.WrongPassword;
            }
            return CustomerLoginResults.Successful;
        }
    }
}
