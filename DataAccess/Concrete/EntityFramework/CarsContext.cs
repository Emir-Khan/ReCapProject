using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarsContext: DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory
           = LoggerFactory.Create(builder => { builder.AddConsole(); });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RentCar;Trusted_Connection=true");
            if (Debugger.IsAttached)
              optionsBuilder.UseLoggerFactory(MyLoggerFactory).EnableSensitiveDataLogging();
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Credit> Cards { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
