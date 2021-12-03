using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.UserId).NotEmpty();
            RuleFor(r => r.RentDate).NotEmpty().Must(DateCheck).WithMessage("Bir Sorun Oluştu");
            
        }
        private bool DateCheck(DateTime arg)
        {
            DateTime nowDate = DateTime.Now;
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
