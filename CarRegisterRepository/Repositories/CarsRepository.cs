using CarRegisterRepositoryLibrary.Contexts;
using CarRegisterRepositoryLibrary.Models.CarModels;
using CarRegisterRepositoryLibrary.Models.CarModels.CarBrandModels;
using CarRegisterRepositoryLibrary.Models.CarModels.CarModelModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegisterRepositoryLibrary.Repositories
{
    public class CarsRepository
    {
        public void AddCarBrand(AddCarBrandModel model)
        {
            var inCarBrandName = new SqlParameter
            {
                ParameterName = "CarBrandName",
                Value = model.Name,
                DbType = System.Data.DbType.String,
                Direction = System.Data.ParameterDirection.Input
            };
            var sql = "exec AddCarBrand @CarBrandName";
            using (var dbContext = new CarsContext())
            {
                _ = dbContext.Database.ExecuteSqlCommand(sql, inCarBrandName);
            }
        }

        public List<DisplayCarBrandModel> GetCarBrands()
        {
            using (var dbContext = new CarsContext())
            {
                var carBrandsList = dbContext.GetCarBrand.SqlQuery("EXECUTE GetCarBrands").ToListAsync().Result;
                return carBrandsList;
            }
        }

        private void ActionCarBrand(long carBrandId, string commandName)
        {
            var inCarBrandId = new SqlParameter
            {
                ParameterName = "CarBrandId",
                Value = carBrandId,
                DbType = System.Data.DbType.Int64,
                Direction = System.Data.ParameterDirection.Input
            };
            var sql = String.Format("exec {0} @CarBrandId", commandName);
            using (var dbContext = new CarsContext())
            {
                _ = dbContext.Database.ExecuteSqlCommand(sql, inCarBrandId);
            }
            return;
        }

        public void DeleteCarBrand(long carBrandId)
        {
            ActionCarBrand(carBrandId, "DeleteCarBrand");
            return;
        }

        public void UnvisibleCarBrand(long carBrandId)
        {
            ActionCarBrand(carBrandId, "UnvisibleCarBrand");
            return;
        }
        /***************************************************************************/
        public void AddCarModel(AddCarModelModel model)
        {
            var inCarBrandId = new SqlParameter
            {
                ParameterName = "CarBrandId",
                Value = model.CarBrandId,
                DbType = System.Data.DbType.Int64,
                Direction = System.Data.ParameterDirection.Input
            };
            var inCarModelName = new SqlParameter
            {
                ParameterName = "CarModelName",
                Value = model.Name,
                DbType = System.Data.DbType.String,
                Direction = System.Data.ParameterDirection.Input
            };
            var sql = "exec AddCarModel @CarBrandId, @CarModelName";
            using (var dbContext = new CarsContext())
            {
                _ = dbContext.Database.ExecuteSqlCommand(sql, inCarBrandId, inCarModelName);
            }
        }

        public List<DisplayCarModelModel> GetCarBrandModels(long carBrandId)
        {
            using (var dbContext = new CarsContext())
            {
                var carBrandModelsList = dbContext.GetCarBrandModels.SqlQuery("EXECUTE GetCarBrandModels {0}", carBrandId).ToListAsync().Result;
                return carBrandModelsList;
            }
        }

        private void ActionCarModel(long carModelId, string commandName)
        {
            var inCarModelId = new SqlParameter
            {
                ParameterName = "CarModelId",
                Value = carModelId,
                DbType = System.Data.DbType.Int64,
                Direction = System.Data.ParameterDirection.Input
            };
            var sql = String.Format("exec {0} @CarModelId", commandName);
            using (var dbContext = new CarsContext())
            {
                _ = dbContext.Database.ExecuteSqlCommand(sql, inCarModelId);
            }
            return;
        }

        public void DeleteCarModel(long carModelId)
        {
            ActionCarModel(carModelId, "DeleteCarModel");
            return;
        }

        public void UnvisibleCarModel(long carModelId)
        {
            ActionCarModel(carModelId, "UnvisibleCarModel");
            return;
        }
        /****************************************************************************/
        public IdbCarModel AddCar(AddCarModel model)
        {
            var inOwnerProfileId =
                model.OwnerProfileId == null ?
                new SqlParameter
                {
                    ParameterName = "OwnerProfileId",
                    Value = DBNull.Value,
                    DbType = System.Data.DbType.Int64,
                    Direction = System.Data.ParameterDirection.Input
                }
                :
                new SqlParameter
                {
                    ParameterName = "OwnerProfileId",
                    Value = model.OwnerProfileId,
                    DbType = System.Data.DbType.Int64,
                    Direction = System.Data.ParameterDirection.Input
                };
            var inCarBrandId = new SqlParameter
            {
                ParameterName = "CarBrandId",
                Value = model.CarBrandId,
                DbType = System.Data.DbType.Int64,
                Direction = System.Data.ParameterDirection.Input
            };
            var inCarModelId = new SqlParameter
            {
                ParameterName = "CarModelId",
                Value = model.CarModelId,
                DbType = System.Data.DbType.Int64,
                Direction = System.Data.ParameterDirection.Input
            };
            var inCarNumber =
                string.IsNullOrEmpty(model.CarNumber) ?
                new SqlParameter
                {
                    ParameterName = "CarNumber",
                    Value = DBNull.Value,
                    DbType = System.Data.DbType.String,
                    Direction = System.Data.ParameterDirection.Input
                }
                :
                new SqlParameter
                {
                    ParameterName = "CarNumber",
                    Value = model.CarNumber,
                    DbType = System.Data.DbType.String,
                    Direction = System.Data.ParameterDirection.Input
                };
            var outResultCarId = new SqlParameter
            {
                ParameterName = "ResultCarId",
                DbType = System.Data.DbType.Int64,
                Direction = System.Data.ParameterDirection.Output
            };

            var sql = "exec AddCar @OwnerProfileId, @CarBrandId, @CarModelId, @CarNumber, @ResultCarId OUT";
            using (var dbContext = new CarsContext())
            {
                _ = dbContext.Database.ExecuteSqlCommand(sql, inOwnerProfileId, inCarBrandId, inCarModelId, inCarNumber, outResultCarId);
            }
            if (long.TryParse(outResultCarId.Value.ToString(), out long resultCarId))
                model.Id = resultCarId;

            return model;
        }

        public DisplayCarModel GetCar(long carId)
        {
            using (var dbContext = new CarsContext())
            {
                var carInstance = dbContext.GetCar.SqlQuery("EXECUTE GetCar {0}", carId).ToListAsync().Result.FirstOrDefault();
                return carInstance;
            }
        }

        public List<DisplayCarModel> GetCars()
        {
            using (var dbContext = new CarsContext())
            {
                var carsList = dbContext.GetCar.SqlQuery("EXECUTE GetCars").ToListAsync().Result;
                return carsList;
            }
        }

        public bool UpdateCar(UpdateCarModel model)
        {
            var inCarId = new SqlParameter
            {
                ParameterName = "CarId",
                Value = model.Id,
                DbType = System.Data.DbType.Int64,
                Direction = System.Data.ParameterDirection.Input
            };
            var inOwnerProfileId =
                model.OwnerProfileId == null ?
                new SqlParameter
                {
                    ParameterName = "OwnerProfileId",
                    Value = DBNull.Value,
                    DbType = System.Data.DbType.Int64,
                    Direction = System.Data.ParameterDirection.Input
                }
                :
                new SqlParameter
                {
                    ParameterName = "OwnerProfileId",
                    Value = model.OwnerProfileId,
                    DbType = System.Data.DbType.Int64,
                    Direction = System.Data.ParameterDirection.Input
                };
            var inCarBrandId = new SqlParameter
            {
                ParameterName = "CarBrandId",
                Value = model.CarBrandId,
                DbType = System.Data.DbType.Int64,
                Direction = System.Data.ParameterDirection.Input
            };
            var inCarModelId = new SqlParameter
            {
                ParameterName = "CarModelId",
                Value = model.CarModelId,
                DbType = System.Data.DbType.Int64,
                Direction = System.Data.ParameterDirection.Input
            };
            var inCarNumber =
                string.IsNullOrEmpty(model.CarNumber) ?
                new SqlParameter
                {
                    ParameterName = "CarNumber",
                    Value = DBNull.Value,
                    DbType = System.Data.DbType.String,
                    Direction = System.Data.ParameterDirection.Input
                }
                :
                new SqlParameter
                {
                    ParameterName = "CarNumber",
                    Value = model.CarNumber,
                    DbType = System.Data.DbType.String,
                    Direction = System.Data.ParameterDirection.Input
                };
            var outResult = new SqlParameter
            {
                ParameterName = "Result",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };

            var sql = "exec UpdateCar @CarId, @OwnerProfileId, @CarBrandId, @CarModelId, @CarNumber, @Result OUT";
            using (var dbContext = new CarsContext())
            {
                _ = dbContext.Database.ExecuteSqlCommand(sql, inCarId, inOwnerProfileId, inCarBrandId, inCarModelId, inCarNumber, outResult);
            }

            if (!Boolean.TryParse(outResult.Value.ToString(), out bool result))
                return false;

            return result;
        }

        private void ActionCar(long carId, string commandName)
        {
            var inCarId = new SqlParameter
            {
                ParameterName = "CarId",
                Value = carId,
                DbType = System.Data.DbType.Int64,
                Direction = System.Data.ParameterDirection.Input
            };
            var sql = String.Format("exec {0} @CarId", commandName);
            using (var dbContext = new CarsContext())
            {
                _ = dbContext.Database.ExecuteSqlCommand(sql, inCarId);
            }
            return;
        }

        public void DeleteCar(long carId)
        {
            ActionCar(carId, "DeleteCar");
            return;
        }
    }
}
