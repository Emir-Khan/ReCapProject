using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, CarsContext>, ICarImageDal
    {
        public List<CarImageDetailDto> GetCarImageDetails()
        {
            using (CarsContext context=new CarsContext())
            {
                var result = from i in context.CarImages
                             join c in context.Cars
                             on i.CarId equals c.CarId
                             select new CarImageDetailDto
                             {
                                 Id=i.Id,
                                 CarId=c.CarId,
                                 ImagePath=i.ImagePath,
                                 Date=i.Date
                             };
                return result.ToList();
            }
        }
    }
}
