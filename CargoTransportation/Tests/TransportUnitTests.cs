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

        public static void Filling()
        {
            Transports.trucks = new List<Transport.Truck>();
            Transports.semitrailers = new List<Transport.Semitrailer>();

            Transports.trucks.Add(new FirstTruck(26000));
            Transports.trucks.Add(new SecondTruck(30000));
            Transports.trucks.Add(new ThirdTruck(21300));

            Transports.semitrailers.Add(new Tanker(15000, 1000));
            Transports.semitrailers.Add(new Awning(21000, 1500));
            Transports.semitrailers.Add(new Refrigerator(17890, 2000));
        }

        [TestMethod]
        public void AllTransport_TestMethod()
        {
            Filling();


            Assert.IsTrue(true);
        }
    }
}
