using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegisterRepositoryLibrary.Constants
{
    public sealed class CarRegisterConstants
    {
        public const string PERSONSCONNECTIONSTRING =
            @"Data Source=DESKTOP-UF7VQET\SQLEXPRESS;Initial Catalog=dbCR_Persons;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public const string CARSCONNECTIONSTRING =
            @"Data Source=DESKTOP-UF7VQET\SQLEXPRESS;Initial Catalog=dbCR_Cars;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
