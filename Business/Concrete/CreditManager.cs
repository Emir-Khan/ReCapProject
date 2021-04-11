using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditManager : ICreditService
    {
        ICreditDal _creditDal;
        public CreditManager(ICreditDal creditDal)
        {
            _creditDal = creditDal;
        }

        [ValidationAspect(typeof(CreditValidation))]
        public IResult Add(Credit card)
        {
            _creditDal.Add(card);
            return new SuccessResult(Messages.CardAdded);
        }

        public IResult Delete(Credit card)
        {
            _creditDal.Delete(card);
            return new SuccessResult(Messages.CardDeleted);
        }

        public IDataResult<List<Credit>> GetAll()
        {
            return new SuccessDataResult<List<Credit>>(_creditDal.GetAll());
        }

        public IDataResult<List<Credit>> GetCardsByUserId(int id)
        {
            return new SuccessDataResult<List<Credit>>(_creditDal.GetAll(c => c.UserId == id));
        }
    }     
}
