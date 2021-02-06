using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
                {
                new Car {Id=1,BrandId=1,ColorId=1,CarName="bmw",ModelYear=2019,DailyPrice=200000,Description="2019'un en iyi arabası"},
                new Car {Id=2,BrandId=2,ColorId=2,CarName="mercedes",ModelYear=2018,DailyPrice=180000,Description="2018'in en iyi arabası"},
                new Car {Id=3,BrandId=3,ColorId=2,CarName="volvo",ModelYear=2017,DailyPrice=160000,Description="2017'nin en iyi arabası"}
                };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine("Araba eklendi");
        }

        public void Delete(Car car)
        {
            Car deleteCar = null;
            deleteCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(deleteCar);
            Console.WriteLine($"{_cars.Count()} Arabanız kaldı");
            //Console.WriteLine(_cars.Count()+" Arabanız kaldı");
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(Car car)
        {
            return _cars.Where(c => c.Id == car.Id).ToList();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _cars.Where(c => c.ColorId == colorId).ToList();
        }

        public void Update(Car car)
        {
            Car car1 = _cars.SingleOrDefault(c => c.Id == car.Id);
            car1.BrandId = car.BrandId;
            car1.ColorId = car.ColorId;
            car1.ModelYear = car.ModelYear;
            car1.DailyPrice = car.DailyPrice;
            car1.Description = car.Description;
            Console.WriteLine("Araç güncellendi");
        }
    }
}
