using System;
using System.Collections.Generic;
using CargoTransportation.Cargo.Products;
using CargoTransportation.Constants;
using CargoTransportation.Trasnsport;
using CargoTransportation.Trasnsport.Semitrailers;
using CargoTransportation.Trasnsport.Trucks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CargoTransportation.Tests
{
    /// <summary>
    /// Класс для тестирования методов всего транспорта
    /// </summary>
    [TestClass]
    public class TransportUnitTests
    {
        private static List<Cargo.Cargo> cargos;
        public static void FillingTransport()
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

        private static void FillingCargo()
        {
            cargos = new List<Cargo.Cargo>();
            cargos.Add(new Oil("АИ95", new KeyValuePair<double, double>(15, 20), 5000));                    // 0
            cargos.Add(new Food("Бананы", new KeyValuePair<double, double>(5, 10), 10000));                 // 1
            cargos.Add(new Chemistry("Хлор", new KeyValuePair<double, double>(-35, -36), 15000));           // 2
            cargos.Add(new NewCargoTest("Стекло", new KeyValuePair<double, double>(5, 10), 4000, true));    // 3    
            cargos.Add(new Oil("ДТ", new KeyValuePair<double, double>(15, 20), 3000));                      // 4
            cargos.Add(new Food("Апельсины", new KeyValuePair<double, double>(5, 10), 2000));               // 5
            cargos.Add(new Chemistry("Аммиак", new KeyValuePair<double, double>(-35, -36), 700));           // 6
            cargos.Add(new NewCargoTest("Песок", new KeyValuePair<double, double>(0 , 30), 12000, false));  // 7
        }

        [TestMethod]
        public void AllTransport_TestMethod()
        {
            FillingTransport();
            FillingCargo();


            Transports.trucks[0].AddSemitrailer(Transports.semitrailers[0]);
            Assert.AreEqual(Transports.semitrailers[0], Transports.trucks[0].ConnectedSemitrailer);

            Transports.semitrailers.Add(new NewSemitrailerTest(25000, 2500));
            try
            {
                Transports.trucks[2].AddSemitrailer(Transports.semitrailers[3]); // false
                Assert.Fail();
            }
            catch
            {
                Assert.IsTrue(true);
            }

            Transports.trucks[2].RemoveSemitrailer();
            Assert.AreEqual(null, Transports.trucks[2].ConnectedSemitrailer);


            Transports.semitrailers[0].LoaddSemiTrailer(cargos[0]);
            for (int i = 1; i < cargos.Count; i++)
            {
                try
                {
                    Transports.semitrailers[0].LoaddSemiTrailer(cargos[i]); // false
                    Assert.Fail();
                }
                catch
                {
                    Assert.IsTrue(true);
                }
            }

            cargos.Add(new Oil("АИ95", new KeyValuePair<double, double>(15, 20), 1000));    // 8
            try
            {
                Transports.semitrailers[0].LoaddSemiTrailer(cargos[8]); // true

                Assert.AreEqual(6000, Transports.semitrailers[0].CurrentWeight);
                Assert.AreEqual(1, Transports.semitrailers[0].CurrentProducts.Count); // 1 - т.к. оба объекта отличаются только массой
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            Transports.semitrailers[1].LoaddSemiTrailer(cargos[2]); // true
            try
            {
                Transports.semitrailers[1].LoaddSemiTrailer(cargos[6]); // true
                Transports.semitrailers[1].LoaddSemiTrailer(cargos[4]); // false
                Assert.Fail();
            }
            catch
            {
                Assert.AreEqual(15700, Transports.semitrailers[1].CurrentWeight);
                Assert.AreEqual(2, Transports.semitrailers[1].CurrentProducts.Count);
            }


            Transports.semitrailers[2].LoaddSemiTrailer(cargos[1]); // true
            try
            {
                Transports.semitrailers[2].LoaddSemiTrailer(cargos[3]); // true
                Transports.semitrailers[2].LoaddSemiTrailer(cargos[5]); // true
                Transports.semitrailers[2].LoaddSemiTrailer(cargos[6]); // false
                Assert.Fail();
            }
            catch
            {
                Assert.AreEqual(16000, Transports.semitrailers[2].CurrentWeight);
                Assert.AreEqual(3, Transports.semitrailers[2].CurrentProducts.Count);
            }


            Transports.semitrailers[3].LoaddSemiTrailer(cargos[3]); // true
            try
            {
                Transports.semitrailers[3].LoaddSemiTrailer(cargos[3]); // true
                Transports.semitrailers[3].LoaddSemiTrailer(cargos[7]); // false
            }
            catch
            {
                Assert.AreEqual(8000, Transports.semitrailers[3].CurrentWeight);
                Assert.AreEqual(2, Transports.semitrailers[3].CurrentProducts.Count);
            }
        }
    }
}
