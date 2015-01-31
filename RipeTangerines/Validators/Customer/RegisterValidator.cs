using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using RipeTangerines.Models;
namespace RipeTangerines.Validators.Customer
{
    public class RegisterValidator : AbstractValidator<RegisterModel>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("请输入用户名");
            RuleFor(x => x.Email).EmailAddress().WithMessage("错误的Email地址");
            RuleFor(x => x.Password).NotEmpty().WithMessage("请输入密码");
            RuleFor(x => x.Password).Length(6, 13).WithMessage("密码最少为6位");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("确认密码不能为空");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("两次输入密码不一致");
        }
    }
}