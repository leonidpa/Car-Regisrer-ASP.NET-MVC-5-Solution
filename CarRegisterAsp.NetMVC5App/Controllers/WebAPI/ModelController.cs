using CarRegisterAsp.NetMVC5App.Controllers.WebAPI.Abstract;
using CarRegisterRepositoryLibrary.Models.CarModels.CarModelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarRegisterAsp.NetMVC5App.Controllers.WebAPI
{
    [RoutePrefix("api/models")]
    public class ModelController : CarRegisterApiController
    {
        [Route("{brandId}")]
        public IHttpActionResult Get(long brandId)
        {
            try
            {
                var modelsList = storageCarRegister.Cars.GetCarBrandModels(brandId);
                return Ok(modelsList);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        [Route("add/{brandId}/{modelName}")]
        public IHttpActionResult Post(long brandId, string modelName)
        {
            try
            {
                storageCarRegister.Cars.AddCarModel(new AddCarModelModel(brandId, modelName));
                return Ok();
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        [Route("delete/{modelId}")]
        public IHttpActionResult Delete(long modelId)
        {
            try
            {
                storageCarRegister.Cars.UnvisibleCarModel(modelId);
                return Ok();
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }
    }
}