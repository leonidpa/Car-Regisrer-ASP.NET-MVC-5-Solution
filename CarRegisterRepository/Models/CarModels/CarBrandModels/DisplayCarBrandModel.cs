using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegisterRepositoryLibrary.Models.CarModels.CarBrandModels
{
    public class DisplayCarBrandModel : CarBrandModel
    {
        public DisplayCarBrandModel() : base() { }

        public DisplayCarBrandModel(string name) : base(name) { }

        public DisplayCarBrandModel(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; set; }
    }
}
