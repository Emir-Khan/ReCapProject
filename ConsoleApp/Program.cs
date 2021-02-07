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
            //InMemoryTest();
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            // ADDING CARS

            //carManager.Add(new Car { Id = 1, ColorId = 1, BrandId = 1, CarName = "BMW 320i", ModelYear = 2019, DailyPrice = 250000, Description = "2019 Model BMW" });
            //carManager.Add(new Car { Id = 2, ColorId = 2, BrandId = 2, CarName = "Opel INSIGNIA", ModelYear = 2020, DailyPrice = 350000, Description = "2029 Model Opel INSIGNIA" });
            //carManager.Add(new Car { Id = 3, ColorId = 1, BrandId = 3, CarName = "KIA", ModelYear = 2021, DailyPrice = 300000, Description = "2021 Model KIA" });

            // ADDING BRANDS

            //brandManager.Add(new Brand { BrandId = 1,BrandName="BMW" });
            //brandManager.Add(new Brand { BrandId = 2, BrandName = "Opel" });
            //brandManager.Add(new Brand { BrandId = 3, BrandName = "KIA" });

            // ADDING COLORS

            //colorManager.Add(new Color { ColorId = 1, ColorName = "Beyaz" });
            //colorManager.Add(new Color { ColorId = 2, ColorName = "Mavi" });

            // DELETE A CAR

            //carManager.Delete(new Car { Id = 3, ColorId = 1, BrandId = 3, CarName = "KIA", ModelYear = 2021, DailyPrice = 300000, Description = "2021 Model KIA" });

            GetCarDetailsTest(carManager);            

        }

        private static void GetCarDetailsTest(CarManager carManager)
        {
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine($"ID: {car.CarId} ,Car Name: {car.CarName} ,Brand ID: {car.BrandId} ,Brand Name: {car.BrandName} ,Color ID: {car.ColorId} ,Color Name: {car.ColorName}");
            }
        }

        private static void InMemoryTest()
        {
            InMemoryCarDal car = new InMemoryCarDal();

            car.Add(new Car { Id = 4, BrandId = 4, ColorId = 4, ModelYear = 2020, DailyPrice = 250000, Description = "2020'nin en iyi arabası" });
            car.Delete(new Car { Id = 1 });
            car.Update(new Car { Id = 4, BrandId = 5, ColorId = 7, ModelYear = 2020, DailyPrice = 240000, Description = "2020'nin en iyi arabası" });
            car.GetById(new Car { Id = 5 });
        }
    }
}
