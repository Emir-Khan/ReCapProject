using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InMemoryCarDal car = new InMemoryCarDal();

            car.Add(new Car { Id = 4, BrandId = 4, ColorId = 4, ModelYear = 2020, DailyPrice = 250000, Description = "2020'nin en iyi arabası" });
            car.Delete(new Car { Id = 1 });
            car.Update(new Car { Id = 4, BrandId = 5, ColorId = 7, ModelYear = 2020, DailyPrice = 240000, Description = "2020'nin en iyi arabası" });
            car.GetById(new Car { Id = 5 });

            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.ModelYear);
            }
        }
    }
}
