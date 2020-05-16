using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegisterRepositoryLibrary.Models.CarModels
{
    public interface IdbCarModel
    {
        long Id { get; set; }
        long? OwnerProfileId { get; set; }
        long CarBrandId { get; set; }
        long CarModelId { get; set; }
        string CarNumber { get; set; }
    }
}
