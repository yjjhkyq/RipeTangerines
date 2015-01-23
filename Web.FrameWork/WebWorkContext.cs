using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Core.Domain.Customers;
using Service.Authentication;

namespace Web.FrameWork
{
    /// <summary>
    /// Work context for web application
    /// </summary>
    public partial class WebWorkContext : IWorkContext
    {
        #region Const

        private const string CustomerCookieName = "Nop.customer";

        #endregion

        #region Fields


        private readonly IAuthenticationService _authenticationService;

        private Customer _cachedCustomer;
        private Customer _originalCustomerIfImpersonated;


        #endregion

        #region Ctor

        public WebWorkContext(IAuthenticationService authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        #endregion

        #region Utilities



        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the current customer
        /// </summary>
        public virtual Customer CurrentCustomer
        {
            get
            {
                if (_cachedCustomer != null)
                    return _cachedCustomer;
                Customer customer = null;
                customer = _authenticationService.GetAuthenticatedCustomer();
                if (null == customer)
                    customer = new Customer();
                _cachedCustomer = customer;
                return _cachedCustomer;
            }
            set
            {

                _cachedCustomer = value;
            }
        }

        /// <summary>
        /// Get or set value indicating whether we're in admin area
        /// </summary>
        public virtual bool IsAdmin { get; set; }

        #endregion
    }
}
