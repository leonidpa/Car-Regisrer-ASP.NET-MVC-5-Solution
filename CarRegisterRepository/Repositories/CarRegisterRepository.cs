using CarRegisterRepositoryLibrary.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegisterRepositoryLibrary.Repositories
{
    public class CarRegisterRepository
    {
        private static CarRegisterRepository instance;

        private static PersonsRepository personsRepository;

        private static CarsRepository carsRepository;

        private CarRegisterRepository()
        {
            personsRepository = new PersonsRepository();
            carsRepository = new CarsRepository();
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
