using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress().WithMessage("Geçerli Bir Email Adresi Giriniz");
            RuleFor(u => u.Email).Must(EndsWith).WithMessage("Email .com ile bitmeli");

            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();

        }

        private bool EndsWith(string arg)
        {
            return arg.EndsWith(".com");
        }
    }
}
