using CargoTransportation.Tests;
using CargoTransportation.Transport;
using CargoTransportation.Trasnsport.Semitrailers;
using CargoTransportation.Trasnsport.Trucks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportation.Trasnsport
{
    public static class Transports
    {
        public static List<Truck> trucks;
        public static List<Semitrailer> semitrailers;






        public static List<Type> trucksTypes = new List<Type>()
        {
            typeof(FirstTruck),
            typeof(SecondTruck),
            typeof(ThirdTruck)
        };





        public static List<Type> trailersTypes = new List<Type>()
        {
            typeof(Tanker),
            typeof(Awning),
            typeof(Refrigerator),
            typeof(NewSemitrailerTest) // :(
        };
    }
}
