using CarRegisterRepositoryLibrary.Models.PersonModels;
using CarRegisterRepositoryLibrary.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegisterRepository.Tests
{
    [TestClass]
    public class PersonsRepositoryUnitTest
    {
        [TestMethod]
        public void TestPersonsRepositoryCRUDMethods()
        {
            bool CreateProfile;
            bool ReadProfile;
            bool UpdateProfile;
            bool DeleteProfile;

            var personsRepository = new PersonsRepository();

            var addProfileModel =
                new AddProfileModel
                {
                    FirstName = "test",
                    LastName = "test",
                    Patronymic = "test",
                    PhoneNumber = "test"
                };
            var addedProfileId = personsRepository.AddProfile(addProfileModel);
            CreateProfile = addedProfileId > 0 ? true : false;

            var profile = personsRepository.GetProfile(addedProfileId);
            ReadProfile = !string.IsNullOrEmpty(profile?.FirstName) ? true : false;

            var updateProfileModel =
                new UpdateProfileModel
                {
                    Id = addedProfileId,
                    FirstName = "testUpdated",
                    LastName = "testUpdated",
                    Patronymic = "testUpdated",
                    PhoneNumber = "testUpdated"
                };
            UpdateProfile = personsRepository.UpdateProfile(updateProfileModel);

            personsRepository.DeleteProfile(addedProfileId);
            DeleteProfile = true;

            Assert.IsTrue(CreateProfile && ReadProfile && UpdateProfile && DeleteProfile);
        }

        [TestMethod]
        public void TestGetProfilesMethod()
        {
            bool Success;

            var personsRepository = new PersonsRepository();

            var addProfileModel =
                new AddProfileModel
                {
                    FirstName = "test",
                    LastName = "test",
                    Patronymic = "test",
                    PhoneNumber = "test"
                };
            var addedProfileId = personsRepository.AddProfile(addProfileModel);
            var profilesList = personsRepository.GetProfiles();
            Success = profilesList.Count > 0 ? true : false;
            personsRepository.DeleteProfile(addedProfileId);

            Assert.IsTrue(Success);
        }
    }
}
