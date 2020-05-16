using CarRegisterRepositoryLibrary.Models.CarModels.CarBrandModels;
using CarRegisterRepositoryLibrary.Models.CarModels.CarModelModels;
using CarRegisterRepositoryLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace CarRegisterAsp.NetMVC5App.Controllers
{
    public class HomeController : Controller
    {
        private CarRegisterRepository storageCarRegister;

        public HomeController()
        {
            storageCarRegister = CarRegisterRepository.GetInstance();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BrandModelManagment()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Car register demo ASP.NET MVC 5 AngularJs ADO.NET web application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";

            return View();
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

        [HttpGet]
        public JsonResult GetAllModelsData(long brandId)
        {
            try
            {
                var modelsList = storageCarRegister.Cars.GetCarBrandModels(brandId);
                return Json(modelsList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult AddModel(long brandId, string modelName)
        {
            try
            {
                storageCarRegister.Cars.AddCarModel(new AddCarModelModel(brandId, modelName));
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult DeleteModel(long modelId)
        {
            try
            {
                storageCarRegister.Cars.UnvisibleCarModel(modelId);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

    }
}