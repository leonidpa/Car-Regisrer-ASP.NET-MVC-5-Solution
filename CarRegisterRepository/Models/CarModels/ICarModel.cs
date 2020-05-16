using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegisterRepositoryLibrary.Models.CarModels
{
    public interface ICarModel
    {
        long Id { get; set; }
        long? OwnerProfileId { get; set; }
        string Brand { get; set; }
        string Model { get; set; }
        string Number { get; set; }
    }
}
