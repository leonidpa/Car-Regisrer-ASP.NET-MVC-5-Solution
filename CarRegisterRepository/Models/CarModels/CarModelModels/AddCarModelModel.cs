using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegisterRepositoryLibrary.Models.CarModels.CarModelModels
{
    public class AddCarModelModel : CarModelModel
    {
        public AddCarModelModel() : base() { }

        public AddCarModelModel(long carBrandId, string name) : base(name)
        {
            CarBrandId = carBrandId;
        }

        public long CarBrandId { get; set; }

    }
}
