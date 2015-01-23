using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RipeTangerines.Models.Customer
{
    public class CustomerInfoModel
    {
        [Display(Name="用户名")]
        [AllowHtml]
        public string UserName { get; set; }

        public CustomerNavigationModel NavigationModel { get; set; }
    }
}