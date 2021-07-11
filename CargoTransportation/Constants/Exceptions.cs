using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportation.Constants
{
    // TODO: Добавить новые исключения
    public static class Exceptions
    {
        public const string WeightSemitrailerException = "Error weight value. Perhaps the mass was more than the permissible value!";
        public const string CargoTypeSemitrailerException = "Product type error!";
        public const string CargoNameSemitrailerException = "Product name error!";
        public const string CargoTemperatureSemitrailerException = "Product temperature error!";

        public const string TruckConnectionException = "This truck already has a semitrailer!";

        public const string FileTruckException = "Track error in file. The data may be incorrect in the file!";
        public const string FileSemitrailerException = "Semitrailer error in file. The data may be incorrect in the file!";

        public const string NewTestProductException = "Error. The current object is invalid for this transport type!";
    }
}
