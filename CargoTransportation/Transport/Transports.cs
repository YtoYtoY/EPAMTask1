using CargoTransportation.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CargoTransportation.Trasnsport
{

    /// <summary>
    /// Автопарк
    /// </summary>
    public static class Transports
    {
        public static List<Truck> trucks;
        public static List<Semitrailer> semitrailers;


        public static IEnumerable<Type> trucksTypes;
        public static IEnumerable<Type> trailersTypes;


        public static void GenerateTruckTypes()
        {
            Type ourtype = typeof(Truck);
            trucksTypes = Assembly.GetAssembly(ourtype).GetTypes().Where(type => type.IsSubclassOf(ourtype));
        }
        public static void GenerateSemitrailerTypes()
        {
            Type ourtype = typeof(Semitrailer);
            trailersTypes = Assembly.GetAssembly(ourtype).GetTypes().Where(type => type.IsSubclassOf(ourtype));

        }
    }
}
