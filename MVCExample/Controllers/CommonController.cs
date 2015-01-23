using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using RipeTangerines.Models.Common;
using Core.Domain.Customers;
using RipeTangerines.Models.Customer;
namespace RipeTangerines.Controllers
{
    public class CommonController : Controller
    {
        private readonly IWorkContext _workContext;

        public CommonController(IWorkContext workContext)
        {
            _workContext = workContext;
        }

        [NonAction]
        protected bool IsCurrentUserRegistered()
        {
            return _workContext.CurrentCustomer.IsRegistered();
        }

        [NonAction]
        protected CustomerNavigationModel GetCustomerNavigationModel(Customer customer)
        {
            var model = new CustomerNavigationModel();
            model.HideAvatar = true;
            model.HideRewardPoints = true;
            model.HideForumSubscriptions = true;
            model.HideReturnRequests = true;
            model.HideDownloadableProducts = true;
            model.HideBackInStockSubscriptions = true;
            return model;
        }

        //header links
        [ChildActionOnly]
        public ActionResult HeaderLinks()
        {
            var customer = _workContext.CurrentCustomer;
 
            var model = new HeaderLinksModel()
            {
                IsAuthenticated = customer.IsRegistered(true),

                CustomerEmailUsername = customer.IsRegistered() ? customer.Username : "",
                ShoppingCartEnabled = false,
                ShoppingCartItems = 0,
                WishlistEnabled = false,
                WishlistItems = 0,
                AllowPrivateMessages = false,
                UnreadPrivateMessages = "",
                AlertMessage = "",
            };

            return PartialView(model);
        }

        public ActionResult Info()
        {
            if (!IsCurrentUserRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;

            var model = new CustomerInfoModel();
            PrepareCustomerInfoModel(model, customer, false);

            return View(model);
        }

        [NonAction]
        protected void PrepareCustomerInfoModel(CustomerInfoModel model, Customer customer, bool excludeProperties)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            if (customer == null)
                throw new ArgumentNullException("customer");
            model.UserName = customer.Username;

            model.NavigationModel = GetCustomerNavigationModel(customer);
            model.NavigationModel.SelectedTab = CustomerNavigationEnum.Info;
        }

    }
}
