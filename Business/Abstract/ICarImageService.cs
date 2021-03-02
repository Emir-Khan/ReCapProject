using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IResult Delete(CarImage carImage);
        IResult Update(CarImage carImage);
        IResult Add(IFormFile file ,CarImage carImage);
        IDataResult<CarImage> GetById(int id);
    }
}
