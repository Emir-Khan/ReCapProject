using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IResult Delete(Car car);
        IResult Update(Car car);
        IResult Add(Car car);
        IDataResult<Car> GetById(int id);
        IDataResult<List<CarDetailDto>> GetByColorId(int colorId);
        IDataResult<Car> GetByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarsByFilter(int branId, int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}
