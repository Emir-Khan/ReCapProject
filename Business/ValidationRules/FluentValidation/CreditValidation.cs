using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditValidation : AbstractValidator<Credit>
    {
        public CreditValidation()
        {
            RuleFor(c => c.CardNumber).MaximumLength(16);
            RuleFor(c => c.CardNumber).MinimumLength(16);
            RuleFor(c => c.ExpiryDate).Must(DateCheck);
            RuleFor(c => c.Cvv).MaximumLength(3);
            RuleFor(c => c.Cvv).MinimumLength(3);
        }

        private bool DateCheck(DateTime arg)
        {
            var nowDate = DateTime.Now;
            if (arg > nowDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
