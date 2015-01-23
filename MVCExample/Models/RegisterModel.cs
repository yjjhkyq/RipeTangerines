using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FluentValidation.Attributes;
using RipeTangerines.Validators.Customer;
 
namespace RipeTangerines.Models
{
    [Validator(typeof(RegisterValidator))]
    public class RegisterModel
    {
        [Display(Name="用户名:")]
        public string UserName { get; set; }
        [Display(Name = "Email:")]
        public string Email { get; set; }
        [Display(Name = "密码:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "确认密码:")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}