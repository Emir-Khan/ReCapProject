using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryCarDal car = new InMemoryCarDal();

            //car.Add(new Car { Id = 4, BrandId = 4, ColorId = 4, ModelYear = 2020, DailyPrice = 250000, Description = "2020'nin en iyi arabası" });
            //car.Delete(new Car { Id = 1 });
            //car.Update(new Car { Id = 4, BrandId = 5, ColorId = 7, ModelYear = 2020, DailyPrice = 240000, Description = "2020'nin en iyi arabası" });
            //car.GetById(new Car { Id = 5 });

            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car { Id = 1, BrandId = 1, ColorId = 1, CarName = "bmw", ModelYear = 2019, DailyPrice = 200000, Description = "2019'un en iyi arabası" });

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.CarName);
            }

            //EfCarDal carManager = new EfCarDal();

            //carManager.Add(new Car { Id = 6, BrandId = 6,CarName="kia", ColorId = 8, ModelYear = 2021, DailyPrice = 200000, Description = "2021 Model kia" });

        }
    }
}
