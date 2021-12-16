using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }


        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(IsRentable(rental));
            if (result != null)
            {
                return result;
            }
            rental.RentDate = rental.RentDate.ToLocalTime();
            rental.ReturnDate = rental.ReturnDate.ToLocalTime();
            _rentalDal.Add(rental);

            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Rentaldeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<RentalDetailDto> GetById(int id)
        {
            var data = _rentalDal.GetRentalDetails();
            return new SuccessDataResult<RentalDetailDto>(data.Find(r => r.Id == id));
        }
        public IDataResult<List<Rental>> GetByUserId(int userId)
        {
            var data = _rentalDal.GetAll(r => r.UserId == userId);

            if (data.Count != 0)
            {
                return new SuccessDataResult<List<Rental>>(data);
            }

            return new ErrorDataResult<List<Rental>>(Messages.RentalCanNotFind);
        }
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUptated);
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult IsRentable(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId);

            if (result.Any(r =>
                r.ReturnDate >= rental.RentDate &&
                r.RentDate <= rental.ReturnDate
            ))
            {
                return new ErrorResult(Messages.RentalNotAvailable);
            }
            else if (rental.RentDate <= rental.ReturnDate)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult(Messages.RentalDateError);
            }


        }
    }
}
