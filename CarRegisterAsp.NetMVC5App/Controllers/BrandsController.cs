using CarRegisterRepositoryLibrary.Models.CarModels.CarBrandModels;
using CarRegisterRepositoryLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CarRegisterAsp.NetMVC5App.Controllers
{
    public class BrandsController : Controller
    {
        private CarRegisterRepository storageCarRegister;

        public BrandsController()
        {
            storageCarRegister = CarRegisterRepository.GetInstance();
        }

        [HttpGet]
        public JsonResult GetAllBrandsData()
        {
            try
            {
                var brandsList = storageCarRegister.Cars.GetCarBrands();
                return Json(brandsList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //throw new HttpException(404, e.Message);
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult AddBrand(string brandName)
        {
            try
            {
                storageCarRegister.Cars.AddCarBrand(new AddCarBrandModel(brandName));
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult DeleteBrand(long brandId)
        {
            try
            {
                storageCarRegister.Cars.UnvisibleCarBrand(brandId);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }
    }
}