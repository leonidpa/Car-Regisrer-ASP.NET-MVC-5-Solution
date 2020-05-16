using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegisterRepositoryLibrary.Models.CarModels
{
    public abstract class CarModel : ICarModel
    {
        public long Id { get; set; }
        public long? OwnerProfileId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Number { get; set; }
    }
}
