using CarRegisterRepositoryLibrary.Models.CarModels;
using CarRegisterRepositoryLibrary.Models.CarModels.CarBrandModels;
using CarRegisterRepositoryLibrary.Models.CarModels.CarModelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegisterRepositoryLibrary.Repositories.Interfaces
{
    public interface ICarsRepository
    {
        void AddCarBrand(AddCarBrandModel model);
        List<DisplayCarBrandModel> GetCarBrands();
        void DeleteCarBrand(long carBrandId);
        void UnvisibleCarBrand(long carBrandId);
        /***************************************************************************/
        void AddCarModel(AddCarModelModel model);
        List<DisplayCarModelModel> GetCarBrandModels(long carBrandId);
        void DeleteCarModel(long carModelId);
        void UnvisibleCarModel(long carModelId);
        /****************************************************************************/
        IdbCarModel AddCar(AddCarModel model);
        DisplayCarModel GetCar(long carId);
        List<DisplayCarModel> GetCars();
        bool UpdateCar(UpdateCarModel model);
        void DeleteCar(long carId);
    }
}
