using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegisterRepositoryLibrary.Models.CarModels.CarModelModels
{
    public class DisplayCarModelModel : CarModelModel
    {
        public DisplayCarModelModel() : base() { }

        public DisplayCarModelModel(long id, string name) : base(name)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
