using CarRegisterRepositoryLibrary.Constants;
using CarRegisterRepositoryLibrary.Models.PersonModels;
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
        : base(CarRegisterConstants.PERSONSCONNECTIONSTRING)
        { }

        public virtual DbSet<DisplayProfileModel> GetProfile { get; set; }
    }
}
