using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Domain;
using System.Web;
using System.Web.Security;
using Service.Customers;
using Core.Domain.Customers;
namespace Service.Authentication
{
    public class FormsAuthenticationService : IAuthenticationService
    {
        private HttpContextBase _httpContext;
        private ICustomerService _customerService;

        public FormsAuthenticationService(HttpContextBase httpContextBase, ICustomerService customerService)
        {
            _httpContext = httpContextBase;
            _customerService = customerService;
        }

        public void SignIn(Customer customer, bool createPersistentCookie)
        {
            var now = DateTime.UtcNow.ToLocalTime();

            var ticket = new FormsAuthenticationTicket(
                1 /*version*/,
                customer.Username,
                now,
                now.Add(FormsAuthentication.Timeout),
                createPersistentCookie,
                customer.Username,
                FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (FormsAuthentication.CookieDomain != null)
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }

            _httpContext.Response.Cookies.Add(cookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public Customer GetAuthenticatedCustomer()
        {
            return _customerService.GetCustomerByUsername(_httpContext.User.Identity.Name);
        }

        public virtual Customer GetAuthenticatedCustomerFromTicket(FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");

            var usernameOrEmail = ticket.UserData;

            if (String.IsNullOrWhiteSpace(usernameOrEmail))
                return null;
            return _customerService.GetCustomerByUsername(usernameOrEmail);
        }
    }
}
