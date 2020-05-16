using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegisterRepositoryLibrary.Models.CarModels.CarModelModels
{
    public class CarModelModel
    {
        public CarModelModel() : base() { }

        public CarModelModel(string name) : base()
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
