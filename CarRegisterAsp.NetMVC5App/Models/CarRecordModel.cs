using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRegisterAsp.NetMVC5App.Models
{
    public abstract class CarRecordModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNamber { get; set; }
        public string CarNumber { get; set; }
        public long CarBrandId { get; set; }
        public long CarModelId { get; set; }
    }
}