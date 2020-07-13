using CarRegisterRepositoryLibrary.Services;
using CarRegisterRepositoryLibrary.Models.PersonModels;
using CarRegisterRepositoryLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegisterRepositoryLibrary.Contexts
{
    public class PersonsContext : DbContext
    {
        public PersonsContext()
        : base(RepositoryService.ConnectionString<PersonsRepository>())
        { }

        public virtual DbSet<DisplayProfileModel> GetProfile { get; set; }
    }
}
