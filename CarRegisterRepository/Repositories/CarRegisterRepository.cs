using CarRegisterRepositoryLibrary.Services;
using CarRegisterRepositoryLibrary.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegisterRepositoryLibrary.Repositories
{
    public sealed class CarRegisterRepository
    {
        private static CarRegisterRepository instance;

        private static PersonsRepository personsRepository;

        private static CarsRepository carsRepository;

        private CarRegisterRepository()
        {
            personsRepository = RepositoryService.Get<PersonsRepository>();
            carsRepository = RepositoryService.Get<CarsRepository>();
        }

        public static CarRegisterRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new CarRegisterRepository();
            }
            return instance;
        }

        public IPersonsRepository Persons
        {
            get
            {
                return personsRepository;
            }
        }

        public ICarsRepository Cars
        {
            get
            {
                return carsRepository;
            }
        }
    }
}
