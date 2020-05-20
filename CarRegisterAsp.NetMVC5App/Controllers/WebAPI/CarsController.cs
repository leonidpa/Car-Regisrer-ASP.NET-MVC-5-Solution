using CarRegisterAsp.NetMVC5App.Controllers.WebAPI.Abstract;
using CarRegisterRepositoryLibrary.Models.CarModels;
using CarRegisterRepositoryLibrary.Models.PersonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AddCarModel = CarRegisterAsp.NetMVC5App.Models.AddCarModel;
using CarRegisterRepositoryLibrary.Models.CarModels.CarBrandModels;
using CarRegisterRepositoryLibrary.Models.CarModels.CarModelModels;
using CarRegisterAsp.NetMVC5App.Models;
using System.Threading.Tasks;

namespace CarRegisterAsp.NetMVC5App.Controllers.WebAPI
{
    [RoutePrefix("api/cars")]
    public class CarsController : CarRegisterApiController
    {
        public async Task<IHttpActionResult> GetAsync()
        {
            try
            {
                var personsGetTask = new Task<List<DisplayProfileModel>>(() => { return storageCarRegister.Persons.GetProfiles(); });
                personsGetTask.Start();
                var carsGetTask = new Task<List<DisplayCarModel>>(() => { return storageCarRegister.Cars.GetCars(); });
                carsGetTask.Start();

                await Task.WhenAll(personsGetTask, carsGetTask);

                var personsList = personsGetTask.Result;
                var carsList = carsGetTask.Result;

                var result = from person in personsList
                             join car in carsList
                             on person.Id equals car.OwnerProfileId
                             select new
                             {
                                 CarId = car.Id,
                                 PersonId = person.Id,
                                 FirstName = person.FirstName,
                                 LastName = person.LastName,
                                 Patronymic = person.Patronymic,
                                 PhoneNamber = person.PhoneNumber,
                                 CarNumber = car.Number,
                                 CarBrand = car.Brand,
                                 CarModel = car.Model
                             };


                return Ok(result?.ToList());
            }
            catch (Exception ex)
            {
                //throw new HttpException(404, e.Message);
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        [Route("car/{carId}")]
        public IHttpActionResult Get(long carId)
        {
            try
            {
                var car = storageCarRegister.Cars.GetCar(carId);
                var profile = storageCarRegister.Persons.GetProfile((long)car.OwnerProfileId);

                var carRecord =
                    new
                    {
                        FirstName = profile.FirstName,
                        LastName = profile.LastName,
                        Patronymic = profile.Patronymic,
                        PhoneNumber = profile.PhoneNumber,
                        Number = car.Number,
                        Brand = car.Brand,
                        Model = car.Model
                    };
                return Ok(carRecord);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [Route("update")]
        public IHttpActionResult Post([FromBody] UpdateCarRecordModel model)
        {
            var carProfileId = storageCarRegister.Persons.AddProfile(
                    new AddProfileModel
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Patronymic = model.Patronymic,
                        PhoneNumber = model.PhoneNamber
                    }
                    );

            var updateCarModel = new UpdateCarModel
            {
                CarBrandId = model.CarBrandId,
                CarModelId = model.CarModelId,
                CarNumber = model.CarNumber,
                Id = model.CarId,
                OwnerProfileId = carProfileId
            };
            storageCarRegister.Cars.UpdateCar(updateCarModel);

            return Ok();
        }

        [Route("add")]
        public IHttpActionResult Put([FromBody]AddCarModel model)
        {
            try
            {
                var carProfileId = storageCarRegister.Persons.AddProfile(
                    new AddProfileModel
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Patronymic = model.Patronymic,
                        PhoneNumber = model.PhoneNamber
                    }
                    );

                storageCarRegister.Cars.AddCar(
                    new CarRegisterRepositoryLibrary.Models.CarModels.AddCarModel
                    {
                        CarBrandId = model.CarBrandId,
                        CarModelId = model.CarModelId,
                        CarNumber = model.CarNumber,
                        OwnerProfileId = carProfileId
                    }
                    );
                return Ok();
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        [Route("delete/{carId}")]
        public IHttpActionResult Delete(long carId)
        {
            try
            { 
                storageCarRegister.Cars.DeleteCar(carId);
                return Ok();
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message
                });
            }
        }
    }
}
