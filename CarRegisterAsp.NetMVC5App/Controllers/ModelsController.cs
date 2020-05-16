using CarRegisterRepositoryLibrary.Models.CarModels.CarModelModels;
using CarRegisterRepositoryLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CarRegisterAsp.NetMVC5App.Controllers
{
    public class ModelsController : Controller
    {
        private CarRegisterRepository storageCarRegister;

        public ModelsController()
        {
            storageCarRegister = CarRegisterRepository.GetInstance();
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