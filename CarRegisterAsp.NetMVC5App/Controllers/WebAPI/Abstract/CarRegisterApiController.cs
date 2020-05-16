using CarRegisterRepositoryLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarRegisterAsp.NetMVC5App.Controllers.WebAPI.Abstract
{
    public abstract class CarRegisterApiController : ApiController
    {
        protected CarRegisterRepository storageCarRegister;

        public CarRegisterApiController()
        {
            storageCarRegister = CarRegisterRepository.GetInstance();
        }
    }
}