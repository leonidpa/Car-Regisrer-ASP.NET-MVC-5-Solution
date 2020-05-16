using CarRegisterRepositoryLibrary.Contexts;
using CarRegisterRepositoryLibrary.Models.PersonModels;
using CarRegisterRepositoryLibrary.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegisterRepositoryLibrary.Repositories
{
    public class PersonsRepository : IPersonsRepository
    {
        public long AddProfile(AddProfileModel model)
        {
            var inFirstName = new SqlParameter
            {
                ParameterName = "FirstName",
                Value = model.FirstName,
                DbType = System.Data.DbType.String,
                Direction = System.Data.ParameterDirection.Input
            };
            var inLastName = new SqlParameter
            {
                ParameterName = "LastName",
                Value = model.LastName,
                DbType = System.Data.DbType.String,
                Direction = System.Data.ParameterDirection.Input
            };
            var inPatronymic = new SqlParameter
            {
                ParameterName = "Patronymic",
                Value = model.Patronymic,
                DbType = System.Data.DbType.String,
                Direction = System.Data.ParameterDirection.Input
            };
            var inPhoneNumber = new SqlParameter
            {
                ParameterName = "PhoneNumber",
                Value = model.PhoneNumber,
                DbType = System.Data.DbType.String,
                Direction = System.Data.ParameterDirection.Input
            };
            var outResultProfileId = new SqlParameter
            {
                ParameterName = "ResultProfileId",
                DbType = System.Data.DbType.Int64,
                Direction = System.Data.ParameterDirection.Output
            };
            var sql = "exec AddProfile @FirstName, @LastName, @Patronymic, @PhoneNumber, @ResultProfileId OUT";
            using (var dbContext = new PersonsContext())
            {
                _ = dbContext.Database.ExecuteSqlCommand(sql, inFirstName, inLastName, inPatronymic, inPhoneNumber, outResultProfileId);
            }

            if (!long.TryParse(outResultProfileId.Value.ToString(), out long result))
                return 0;

            return result;
        }

        public DisplayProfileModel GetProfile(long profileId)
        {
            using (var dbContext = new PersonsContext())
            {
                var profile = dbContext.GetProfile.SqlQuery("EXECUTE GetProfile {0}", profileId).ToListAsync().Result.FirstOrDefault();
                return profile;
            }
        }

        public List<DisplayProfileModel> GetProfiles()
        {
            using (var dbContext = new PersonsContext())
            {
                var profilesList = dbContext.GetProfile.SqlQuery("EXECUTE GetProfiles").ToListAsync().Result;
                return profilesList;
            }
        }

        public bool UpdateProfile(UpdateProfileModel model)
        {
            var inId = new SqlParameter
            {
                ParameterName = "Id",
                Value = model.Id,
                DbType = System.Data.DbType.Int64,
                Direction = System.Data.ParameterDirection.Input
            };
            var inFirstName = new SqlParameter
            {
                ParameterName = "FirstName",
                Value = model.FirstName,
                DbType = System.Data.DbType.String,
                Direction = System.Data.ParameterDirection.Input
            };
            var inLastName = new SqlParameter
            {
                ParameterName = "LastName",
                Value = model.LastName,
                DbType = System.Data.DbType.String,
                Direction = System.Data.ParameterDirection.Input
            };
            var inPatronymic = new SqlParameter
            {
                ParameterName = "Patronymic",
                Value = model.Patronymic,
                DbType = System.Data.DbType.String,
                Direction = System.Data.ParameterDirection.Input
            };
            var inPhoneNumber = new SqlParameter
            {
                ParameterName = "PhoneNumber",
                Value = model.PhoneNumber,
                DbType = System.Data.DbType.String,
                Direction = System.Data.ParameterDirection.Input
            };
            var outResult = new SqlParameter
            {
                ParameterName = "Result",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };

            var sql = "exec UpdateProfile @Id, @FirstName, @LastName, @Patronymic, @PhoneNumber, @Result OUT";
            using (var dbContext = new PersonsContext())
            {
                _ = dbContext.Database.ExecuteSqlCommand(sql, inId, inFirstName, inLastName, inPatronymic, inPhoneNumber, outResult);
            }

            if (!Boolean.TryParse(outResult.Value.ToString(), out bool result))
                return false;

            return result;
        }

        public void DeleteProfile(long profileId)
        {
            var inProfileId = new SqlParameter
            {
                ParameterName = "ProfileId",
                Value = profileId,
                DbType = System.Data.DbType.Int64,
                Direction = System.Data.ParameterDirection.Input
            };
            var sql = "exec DeleteProfile @ProfileId";
            using (var dbContext = new PersonsContext())
            {
                _ = dbContext.Database.ExecuteSqlCommand(sql, inProfileId);
            }
            return;
        }
    }
}
