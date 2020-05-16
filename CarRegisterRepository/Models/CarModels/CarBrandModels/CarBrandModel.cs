using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegisterRepositoryLibrary.Models.CarModels.CarBrandModels
{
    public class CarBrandModel
    {
        public CarBrandModel() : base()
        { }

        public CarBrandModel(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
