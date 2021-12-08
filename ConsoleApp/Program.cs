using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryTest();
            //CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            UserManager userManager = new UserManager(new EfUserDal());

            // ADDING CARS

            //carManager.Add(new Car { Id = 1, ColorId = 1, BrandId = 1, CarName = "BMW 320i", ModelYear = 2019, DailyPrice = 400, Description = "2019 Model BMW" });
            //carManager.Add(new Car { Id = 2, ColorId = 2, BrandId = 2, CarName = "Opel INSIGNIA", ModelYear = 2020, DailyPrice = 375, Description = "2020 Model Opel INSIGNIA" });
            //carManager.Add(new Car { Id = 3, ColorId = 1, BrandId = 3, CarName = "KIA", ModelYear = 2021, DailyPrice = 320, Description = "2021 Model KIA" });
            //carManager.Add(new Car { Id = 4, ColorId = 3, BrandId = 4, CarName = "Mercedes c180", ModelYear = 2018, DailyPrice = 450, Description = "2018 Model Mercedes" });
            //carManager.Add(new Car { Id = 5, ColorId = 1, BrandId = 5, CarName = "Fiat Doblo", ModelYear = 2017, DailyPrice = 200, Description = "Eniştemin doblosu" });
            //carManager.Add(new Car { Id = 6, ColorId = 4, BrandId = 6, CarName = "Maserati MC20", ModelYear = 2021, DailyPrice = 1500, Description = "2021 Model Maserati" });

            // ADDING BRANDS

            //brandManager.Add(new Brand { BrandId = 1,BrandName="BMW" });
            //brandManager.Add(new Brand { BrandId = 2, BrandName = "Opel" });
            //brandManager.Add(new Brand { BrandId = 3, BrandName = "KIA" });
            //brandManager.Add(new Brand { BrandId = 4, BrandName = "Mercedes" });
            //brandManager.Add(new Brand { BrandId = 5, BrandName = "Fiat" });
            //brandManager.Add(new Brand { BrandId = 6, BrandName = "Maserati" });

            // ADDING COLORS

            //colorManager.Add(new Color { ColorId = 1, ColorName = "Beyaz" });
            //colorManager.Add(new Color { ColorId = 2, ColorName = "Mavi" });
            //colorManager.Add(new Color { ColorId = 3, ColorName = "Turuncu" });
            //colorManager.Add(new Color { ColorId = 4, ColorName = "siyah" });

            // DELETE A CAR

            //carManager.Delete(new Car { Id = 3, ColorId = 1, BrandId = 3, CarName = "KIA", ModelYear = 2021, DailyPrice = 320, Description = "2021 Model KIA" });

            //GetCarDetailsTest(carManager);

            //rentalManager.Add(new Rental { Id = 1, CarId = 1, CustomerId = 1, RentDate = new DateTime(2019, 3, 25, 8, 50, 29), ReturnDate = new DateTime(2019, 3, 25, 19, 37, 51) });
            //userManager.Add(new User { Id = 1, FirstName = "Emirhan", LastName = "Köseoğlu", Email = "ajbfqeuo@gmail.com", Password = "!2a3456" });

            OnGarage(rentalManager);

            NotOnGarage(rentalManager);

        }

        private static void NotOnGarage(RentalManager rentalManager)
        {
            var result = rentalManager.GetRentalDetails();
            foreach (var item in result.Data)
            {
                if (!(item.ReturnDate == null))
                {
                    Console.WriteLine($"Kiralayan: {item.FirstName}, Araç: {item.CarName}, Çıkış Tarihi: {item.RentDate} (KULLANIMDA!)");
                }
            }
        }
        private static void OnGarage(RentalManager rentalManager)
        {
            var result = rentalManager.GetRentalDetails();
            foreach (var item in result.Data)
            {
                if (item.ReturnDate == null)
                {
                    Console.WriteLine($"Kiralayan: {item.FirstName}, Araç: {item.CarName}, Çıkış Tarihi: {item.RentDate}, Teslim Tarihi {item.ReturnDate} (Teslim Edildi)");
                }
            }
        }

        private static void GetCarDetailsTest(CarManager carManager)
        {
            var result = carManager.GetCarDetails();

            foreach (var car in result.Data)
            {
                Console.WriteLine($"ID: {car.CarId} ,Car Name: {car.CarName} ,Brand ID: {car.BrandId} ,Brand Name: {car.BrandName} ,Color ID: {car.ColorId} ,Color Name: {car.ColorName}");
            }
        }

        private static void InMemoryTest()
        {
            InMemoryCarDal car = new InMemoryCarDal();

            car.Add(new Car { CarId = 4, BrandId = 4, ColorId = 4, ModelYear = 2020, DailyPrice = 250000, Description = "2020'nin en iyi arabası" });
            car.Delete(new Car { CarId = 1 });
            car.Update(new Car { CarId = 4, BrandId = 5, ColorId = 7, ModelYear = 2020, DailyPrice = 240000, Description = "2020'nin en iyi arabası" });
            car.GetById(new Car { CarId = 5 });
        }
    }
}
