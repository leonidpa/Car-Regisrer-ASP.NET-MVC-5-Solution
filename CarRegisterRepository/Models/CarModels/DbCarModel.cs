using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegisterRepositoryLibrary.Models.CarModels
{
    public abstract class DbCarModel : IdbCarModel
    {
        public long Id { get; set; }
        public long? OwnerProfileId { get; set; }
        public long CarBrandId { get; set; }
        public long CarModelId { get; set; }
        public string CarNumber { get; set; }
    }
}
