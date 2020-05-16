using System;
using System.Linq;
using CarRegisterRepositoryLibrary.Models.CarModels;
using CarRegisterRepositoryLibrary.Models.CarModels.CarBrandModels;
using CarRegisterRepositoryLibrary.Models.CarModels.CarModelModels;
using CarRegisterRepositoryLibrary.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarRegisterRepository.Tests
{
    [TestClass]
    public class CarsRepositoryUnitTest
    {
        private void AddCarBrand(CarsRepository repository, string carBrandName)
        {
            var carBrandModel = new AddCarBrandModel(carBrandName);
            repository.AddCarBrand(carBrandModel);
        }

        private DisplayCarBrandModel GetSelectedCarBrand(CarsRepository repository, string carBrandName)
        {
            var carBrandsList = repository.GetCarBrands();

            var selectedCarBrand = carBrandsList.Where(e => e.Name == carBrandName).FirstOrDefault();

            return selectedCarBrand;
        }

        private void DeleteCarBrand(CarsRepository repository, long carBrandId)
        {
            repository.DeleteCarBrand(carBrandId);
        }

        [TestMethod]
        public void TestCarsRepositoryBrandCRUDMethods()
        {
            bool Create;
            bool Read;
            bool Delete;

            var repository = new CarsRepository();

            string carBrandName = "test";

            AddCarBrand(repository, carBrandName);
            Create = true;

            var selectedCarBrand = GetSelectedCarBrand(repository, carBrandName);
            Read = selectedCarBrand != null ? true : false;

            DeleteCarBrand(repository, selectedCarBrand.Id);
            Delete = true;

            Assert.IsTrue(Create && Read && Delete);
        }

        private void AddCarModel(CarsRepository repository, long carBrandId, string carBrandModelName)
        {
            var carModelModel = new AddCarModelModel(carBrandId, carBrandModelName);
            repository.AddCarModel(carModelModel);
        }

        private DisplayCarModelModel GetSelectedCarBrandModel(CarsRepository repository, long carBrandId, string carBrandModelName)
        {
            var carBrandModelsList = repository.GetCarBrandModels(carBrandId);

            var selectedCarBrandModel = carBrandModelsList.Where(e => e.Name == carBrandModelName).FirstOrDefault();

            return selectedCarBrandModel;
        }

        private void DeleteCarModel(CarsRepository repository, long carModelId)
        {
            repository.DeleteCarModel(carModelId);
        }

        [TestMethod]
        public void TestCarsRepositoryModelCRUDMethods()
        {
            bool Create;
            bool Read;
            bool Delete;

            var repository = new CarsRepository();

            string carBrandName = "test";

            AddCarBrand(repository, carBrandName);

            var selectedCarBrand = GetSelectedCarBrand(repository, carBrandName);

            long carBrandId = selectedCarBrand.Id;
            string carBrandModelName = "test";

            AddCarModel(repository, carBrandId, carBrandModelName);
            Create = true;

            var selectedCarBrandModel = GetSelectedCarBrandModel(repository, carBrandId, carBrandModelName);
            Read = selectedCarBrandModel != null ? true : false;

            DeleteCarBrand(repository, selectedCarBrand.Id);
            DeleteCarModel(repository, selectedCarBrandModel.Id);
            Delete = true;

            Assert.IsTrue(Create && Read && Delete);
        }

        private IdbCarModel AddCar(CarsRepository repository, long? ownerProfileId, long carBrandId, long carBrandModelId, string carNumber)
        {
            var addCarModel = new AddCarModel
            {
                OwnerProfileId = ownerProfileId,
                CarBrandId = carBrandId,
                CarModelId = carBrandModelId,
                CarNumber = carNumber
            };
            return repository.AddCar(addCarModel);
        }

        private DisplayCarModel GetSelectedCar(CarsRepository repository, long selectedCarId)
        {
            return repository.GetCar(selectedCarId);
        }

        private bool UpdateCar(CarsRepository repository, long carId, long carBrandId, long carBrandModelId)
        {
            var updatedCarNumber = "testUpdate";
            var updateCarModel = new UpdateCarModel
            {
                Id = carId,
                OwnerProfileId = null,
                CarBrandId = carBrandId,
                CarModelId = carBrandModelId,
                CarNumber = updatedCarNumber
            };
            return repository.UpdateCar(updateCarModel);
        }

        private void DeleteCar(CarsRepository repository, long carId)
        {
            repository.DeleteCar(carId);
        }

        [TestMethod]
        public void TestCarsRepositoryCarCRUDMethods()
        {
            bool Create;
            bool Read;
            bool Update;
            bool Delete;

            var repository = new CarsRepository();

            string carBrandName = "test";
            AddCarBrand(repository, carBrandName);
            var selectedCarBrand = GetSelectedCarBrand(repository, carBrandName);

            long carBrandId = selectedCarBrand.Id;
            string carBrandModelName = "test";
            AddCarModel(repository, carBrandId, carBrandModelName);
            var selectedCarBrandModel = GetSelectedCarBrandModel(repository, carBrandId, carBrandModelName);
            long carBrandModelId = selectedCarBrandModel.Id;

            long? ownerProfileId = null;
            string carNumber = "test";
            var addedCar = AddCar(repository, ownerProfileId, carBrandId, carBrandModelId, carNumber);
            Create = addedCar.Id > 0 ? true : false;
            if (addedCar?.Id == null || addedCar.Id <= 0) return;

            var selectedCar = GetSelectedCar(repository, addedCar.Id);
            Read = selectedCar != null ? true : false;
            if (selectedCar?.Id == null || selectedCar.Id <= 0) return;

            Update = UpdateCar(repository, selectedCar.Id, carBrandId, carBrandModelId);

            DeleteCar(repository, selectedCar.Id);
            DeleteCarBrand(repository, selectedCarBrand.Id);
            DeleteCarModel(repository, selectedCarBrandModel.Id);
            Delete = true;

            Assert.IsTrue(Create && Read && Update && Delete);
        }

        [TestMethod]
        public void TestCarsRepositoryGetCarsMethod()
        {
            bool Success = false;

            var repository = new CarsRepository();

            string carBrandName = "test";
            AddCarBrand(repository, carBrandName);
            var selectedCarBrand = GetSelectedCarBrand(repository, carBrandName);

            long carBrandId = selectedCarBrand.Id;
            string carBrandModelName = "test";
            AddCarModel(repository, carBrandId, carBrandModelName);
            var selectedCarBrandModel = GetSelectedCarBrandModel(repository, carBrandId, carBrandModelName);
            long carBrandModelId = selectedCarBrandModel.Id;

            long? ownerProfileId = null;
            string carNumber = "test";
            var addedCar = AddCar(repository, ownerProfileId, carBrandId, carBrandModelId, carNumber);
            if (addedCar?.Id == null || addedCar.Id <= 0) return;

            var selectedCar = GetSelectedCar(repository, addedCar.Id);
            if (selectedCar?.Id == null || selectedCar.Id <= 0) return;

            var carsList = repository.GetCars();
            if (carsList != null)
                Success = carsList.Count > 0 ? true : false;

            DeleteCar(repository, selectedCar.Id);
            DeleteCarBrand(repository, selectedCarBrand.Id);
            DeleteCarModel(repository, selectedCarBrandModel.Id);

            Assert.IsTrue(Success);
        }
    }
}
