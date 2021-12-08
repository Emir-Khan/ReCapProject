using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManger : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManger(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        
        public IResult Add(IFormFile file, int carId)
        {
            var carImage = new CarImage();
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            carImage.CarId = carId;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarImageDetailDto>> GetByCarId(int id)
        {
            var img = _carImageDal.GetCarImageDetails();

            if (img.Find(c => c.CarId == id)!=null)
            {
                return new SuccessDataResult<List<CarImageDetailDto>>(img.FindAll(c => c.CarId == id));
            }
            return new ErrorDataResult<List<CarImageDetailDto>>(Messages.ImageNotFound);
        }

        public IDataResult<List<CarImageDetailDto>> GetCarImageDetails()
        {
            return new SuccessDataResult<List<CarImageDetailDto>>(_carImageDal.GetCarImageDetails());
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            FileHelper.Update(carImage.ImagePath, file);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }
    }
}
