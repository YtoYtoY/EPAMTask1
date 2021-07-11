using System;
using System.Collections.Generic;
using CargoTransportation.Trasnsport;
using CargoTransportation.Trasnsport.Semitrailers;
using CargoTransportation.Trasnsport.Trucks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CargoTransportation.Tests
{
    [TestClass]
    public class TransportUnitTests
    {
        public static List<Transport.Truck> Trucks;
        public static List<Transport.Semitrailer> Semitrailers;

        [TestMethod]
        public void AllTransport_TestMethod()
        {
            Trucks = new List<Transport.Truck>();
            Semitrailers = new List<Transport.Semitrailer>();

            Trucks.Add(new FirstTruck(26000));
            Trucks.Add(new SecondTruck(30000));
            Trucks.Add(new ThirdTruck(21300));

            Semitrailers.Add(new Tanker(15000));
            Semitrailers.Add(new Awning(21000));
            Semitrailers.Add(new Refrigerator(17890));


            //Assert
        }
    }
}
