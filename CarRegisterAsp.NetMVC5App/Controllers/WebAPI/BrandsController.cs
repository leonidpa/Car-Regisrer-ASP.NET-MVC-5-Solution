using CarRegisterAsp.NetMVC5App.Controllers.WebAPI.Abstract;
using CarRegisterRepositoryLibrary.Models.CarModels.CarBrandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarRegisterAsp.NetMVC5App.Controllers.WebAPI
{
    [RoutePrefix("api/brands")]
    public class BrandsController : CarRegisterApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                var brandsList = storageCarRegister.Cars.GetCarBrands();
                return Ok(brandsList);
            }
            catch (Exception ex)
            {
                //throw new HttpException(404, e.Message);
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        [Route("add/{brandName}")]
        public IHttpActionResult Post(string brandName)
        {
            try
            {
                storageCarRegister.Cars.AddCarBrand(new AddCarBrandModel(brandName));
                return Ok();
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        [Route("delete/{brandId}")]
        public IHttpActionResult Delete(long brandId)
        {
            try
            {
                storageCarRegister.Cars.UnvisibleCarBrand(brandId);
                return Ok();
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }
    }
}