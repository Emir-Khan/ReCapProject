using Business.Abstract;
using Business.BusinsessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;           
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [SecuredOperation("admin,car.add")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            var result = BusinessRules.Run(CheckIfProductNameExists(car.CarName));
            if (result!=null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IDataResult<List<CarDetailDto>> GetById(int id)
        {
            var result = _carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDetailDto>>(result.FindAll(c => c.CarId == id));
        }

        public IDataResult<CarDetailDto> GetBySingleId(int id)
        {
            var result = _carDal.GetCarDetails();
            return new SuccessDataResult<CarDetailDto>(result.Find(c => c.CarId == id));
        }

        public IDataResult<List<CarDetailDto>> GetByColorId(int colorId)
        {
            var result = _carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDetailDto>>(result.FindAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetByBrandId(int brandId)
        {
            var brand = _carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDetailDto>>(brand.FindAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<CarDetailDto>> GetCarsByFilter(int colorId,int brandId)
        {
            var cars =_carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDetailDto>>(cars.FindAll(p => p.BrandId == brandId&&p.ColorId==colorId));
        }



        private IResult CheckIfProductNameExists(string carName)
        {
            var result = _carDal.GetAll(c => c.CarName == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
    
}
