using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegisterRepositoryLibrary.Models.CarModels.CarBrandModels
{
    public class AddCarBrandModel : CarBrandModel
    {
        public AddCarBrandModel() : base()
        { }

        public AddCarBrandModel(string name) : base(name)
        {
            Name = name;
        }
    }
}
