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
        ICarImageService _carImageService;
        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }


        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        [SecuredOperation("admin,car.delete")]
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
        public IResult Add(Car car)
        {
            var result = BusinessRules.Run(CheckIfProductNameExists(car.CarName));
            if (result != null)
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
            return new SuccessDataResult<List<CarDetailDto>>(IsHasImage().Data);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByFilter(int colorId, int brandId)
        {
            var cars = _carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDetailDto>>(cars.FindAll(p => p.BrandId == brandId && p.ColorId == colorId));
        }

        private IDataResult<List<CarDetailDto>> IsHasImage()
        {
            List<CarDetailDto> result = new List<CarDetailDto>();
            var cars = _carDal.GetCarDetails();
            for (int i = 0; i < cars.Count; i++)
            {
                if (_carImageService.GetByCarId(cars[i].CarId).Success)
                {
                    result.Add(new CarDetailDto()
                    {
                        CarId = cars[i].CarId,
                        BrandId = cars[i].BrandId,
                        ColorId = cars[i].ColorId,
                        BrandName = cars[i].BrandName,
                        CarName = cars[i].CarName,
                        ColorName = cars[i].ColorName,
                        DailyPrice = cars[i].DailyPrice,
                        ModelYear = cars[i].ModelYear,
                        Description = cars[i].Description,
                        HasImage = true
                    });
                }
                else
                {
                    result.Add(new CarDetailDto()
                    {
                        CarId = cars[i].CarId,
                        BrandId = cars[i].BrandId,
                        ColorId = cars[i].ColorId,
                        BrandName = cars[i].BrandName,
                        CarName = cars[i].CarName,
                        ColorName = cars[i].ColorName,
                        DailyPrice = cars[i].DailyPrice,
                        ModelYear = cars[i].ModelYear,
                        Description = cars[i].Description,
                        HasImage = false
                    });
                }
            }
            return new SuccessDataResult<List<CarDetailDto>>(result);
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
