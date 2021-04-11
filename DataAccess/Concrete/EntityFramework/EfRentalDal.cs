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
    public class EfRentalDal:EfEntityRepositoryBase<Rental,CarsContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarsContext context = new CarsContext())
            {
                var result = from c in context.Cars
                             join r in context.Rentals
                             on c.Id equals r.CarId
                             join u in context.Users
                             on r.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 Id=r.Id,
                                 CarId = c.Id,
                                 UserId = u.Id,
                                 CarName = c.CarName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();            
            }
        }
    }
}
