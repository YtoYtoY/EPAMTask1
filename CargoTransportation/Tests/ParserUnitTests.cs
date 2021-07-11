using System;
using System.Collections.Generic;
using CargoTransportation.Parser;
using CargoTransportation.Transport;
using CargoTransportation.Trasnsport;
using CargoTransportation.Trasnsport.Semitrailers;
using CargoTransportation.Trasnsport.Trucks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CargoTransportation.Tests
{
    [TestClass]
    public class ParserUnitTests
    {

        [TestMethod]
        public void XmlReader_TestMethod()
        {
            XmlFactory parser = new XmlFactory();
            parser.DataRead(Constants.Constants.StreamReaderFilePath);

            List<Truck> expectedTrucks = Transports.trucks;
            List<Semitrailer> expectedTrailers = Transports.semitrailers;

            TransportUnitTests.Filling();
            List<Truck> actualdTrucks = Transports.trucks;
            List<Semitrailer> actualdTrailer = Transports.semitrailers;

            CollectionAssert.Equals(expectedTrucks, actualdTrucks);
            CollectionAssert.Equals(expectedTrailers, actualdTrailer);
        }

        [TestMethod]
        public void XmlWriter_TestMethod()
        {
            TransportUnitTests.Filling();
            XmlFactory parser = new XmlFactory();
            parser.DataWrite(Constants.Constants.XmlWriterFilePath);

            Transports.trucks = null;
            Transports.semitrailers = null;
        }

        [TestMethod]
        public void StreamReader_TestMethod()
        {
            StreamFactory parser = new StreamFactory();
            parser.DataRead(Constants.Constants.StreamReaderFilePath);

            List<Truck> expectedTrucks = Transports.trucks;
            List<Semitrailer> expectedTrailers = Transports.semitrailers;

            TransportUnitTests.Filling();
            List<Truck> actualdTrucks = Transports.trucks;
            List<Semitrailer> actualdTrailer = Transports.semitrailers;

            CollectionAssert.Equals(expectedTrucks, actualdTrucks);
            CollectionAssert.Equals(expectedTrailers, actualdTrailer);
        }

        [TestMethod]
        public void StreamWriter_TestMethod()
        {
            TransportUnitTests.Filling();
            StreamFactory parser = new StreamFactory();
            parser.DataWrite(Constants.Constants.StreamWriterFilePath);

            Transports.trucks = null;
            Transports.semitrailers = null;

        }

    }
}
