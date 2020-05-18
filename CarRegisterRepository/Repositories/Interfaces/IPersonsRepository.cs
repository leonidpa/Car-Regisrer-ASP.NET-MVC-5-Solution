using CarRegisterRepositoryLibrary.Models.PersonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegisterRepositoryLibrary.Repositories.Interfaces
{
    public interface IPersonsRepository
    {
        long AddProfile(AddProfileModel model);
        DisplayProfileModel GetProfile(long profileId);
        List<DisplayProfileModel> GetProfiles();
        bool UpdateProfile(UpdateProfileModel model);
        void DeleteProfile(long profileId);
    }
}
