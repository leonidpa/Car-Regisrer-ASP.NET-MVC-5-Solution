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

namespace CarRegisterAsp.NetMVC5App.Controllers.WebAPI
{
    [RoutePrefix("api/cars")]
    public class CarsController : CarRegisterApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                var personsList = storageCarRegister.Persons.GetProfiles();
                var carsList = storageCarRegister.Cars.GetCars();

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

        public string Get(int id)
        {
            return "value";
        }

        [Route("add")]
        public IHttpActionResult Post([FromBody]AddCarModel model)
        {
            try
            {
                var carProfileId = storageCarRegister.Persons.AddProfile(
                    new AddProfileModel {
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
                //throw new HttpException(404, e.Message);
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
