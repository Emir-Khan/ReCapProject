using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Araba başarıyla silindi.");
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Araba başarıyla güncellendi.");
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
            Console.WriteLine("Araba başarıyla eklendi.");
        }
    }
}
