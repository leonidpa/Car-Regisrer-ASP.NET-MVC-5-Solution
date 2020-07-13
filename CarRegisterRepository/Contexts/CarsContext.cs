using CarRegisterRepositoryLibrary.Services;
using CarRegisterRepositoryLibrary.Models.CarModels;
using CarRegisterRepositoryLibrary.Models.CarModels.CarBrandModels;
using CarRegisterRepositoryLibrary.Models.CarModels.CarModelModels;
using CarRegisterRepositoryLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegisterRepositoryLibrary.Contexts
{
    public class CarsContext : DbContext
    {
        public CarsContext()
        : base(RepositoryService.ConnectionString<CarsRepository>())
        { }

        public virtual DbSet<DisplayCarBrandModel> GetCarBrand { get; set; }

        public virtual DbSet<DisplayCarModelModel> GetCarBrandModels { get; set; }

        public virtual DbSet<DisplayCarModel> GetCar { get; set; }

    }
}
