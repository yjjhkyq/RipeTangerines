using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Domain;
using Core.Domain.Customers;
using RipeTangerines.Models;
using Service.Authentication;
using Service.Customers;

namespace RipeTangerines.Controllers
{
    public partial class CustomerController : Controller
    {
        private IAuthenticationService _authenticationService;
        private ICustomerRegistrationService _customerRegistrationService;
        private ICustomerService _customerService;



        public CustomerController(IAuthenticationService authenticationService, ICustomerRegistrationService customerRegistrationService,
            ICustomerService customerService)
        {
            _authenticationService = authenticationService;
            _customerRegistrationService = customerRegistrationService;
            _customerService = customerService;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer() {  Username = registerModel.UserName, Email = registerModel.Email, Password = registerModel.Password};
                _customerRegistrationService.Register(customer);
                _authenticationService.SignIn(customer, true);
                return RedirectToRoute("HomePage");
            }
            return View(registerModel);
        }

        public ActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = _customerRegistrationService.ValidateCustomer(model.Username, model.Password);
                switch (loginResult)
                {
                    case CustomerLoginResults.Successful:
                        {
                            Customer customer = _customerService.GetCustomerByUsername(model.Username);
                            _authenticationService.SignIn(customer, model.RememberMe);
                            return RedirectToRoute("HomePage");
                        }
                    case CustomerLoginResults.CustomerNotExist:
                        ModelState.AddModelError("", "用户名不存在");
                        break;
                    case  CustomerLoginResults.WrongPassword:
                        ModelState.AddModelError("", "密码错误");
                        break;
                    default:
                        ModelState.AddModelError("", "未知异常");
                        break;
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            _authenticationService.SignOut();
            return RedirectToRoute("HomePage");
        }


    }
}
