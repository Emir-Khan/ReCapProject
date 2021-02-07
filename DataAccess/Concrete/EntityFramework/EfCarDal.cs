using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarsContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarsContext context = new CarsContext())
            {
                var result = from p in context.Cars
                             join c in context.Brands
                             on p.BrandId equals c.BrandId
                             join d in context.Colors
                             on p.ColorId equals d.ColorId
                             select new CarDetailDto
                             {
                                 BrandId = c.BrandId,
                                 BrandName = c.BrandName,
                                 CarId = p.Id,
                                 CarName = p.CarName,
                                 ColorId = d.ColorId,
                                 ColorName = d.ColorName
                             };
                return result.ToList();
            }
        }
    }
}
