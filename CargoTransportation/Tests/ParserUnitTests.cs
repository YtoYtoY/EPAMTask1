using System.Collections.Generic;
using CargoTransportation.Parser;
using CargoTransportation.Transport;
using CargoTransportation.Trasnsport;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CargoTransportation.Tests
{

    /// <summary>
    /// Класс для тестирования считывания и сохранения xml файла
    /// </summary>
    [TestClass]
    public class ParserUnitTests
    {

        [TestMethod]
        public void XmlReader_TestMethod()
        {
            XmlParse parser = new XmlParse();
            parser.DataRead(Constants.Constants.StreamReaderFilePath);

            List<Truck> expectedTrucks = Transports.trucks;
            List<Semitrailer> expectedTrailers = Transports.semitrailers;

            TransportUnitTests.FillingTransport();
            List<Truck> actualdTrucks = Transports.trucks;
            List<Semitrailer> actualdTrailer = Transports.semitrailers;

            CollectionAssert.Equals(expectedTrucks, actualdTrucks);
            CollectionAssert.Equals(expectedTrailers, actualdTrailer);
        }

        [TestMethod]
        public void XmlWriter_TestMethod()
        {
            TransportUnitTests.FillingTransport();
            XmlParse parser = new XmlParse();
            parser.DataWrite(Constants.Constants.XmlWriterFilePath);

            Transports.trucks = null;
            Transports.semitrailers = null;
        }

        [TestMethod]
        public void StreamReader_TestMethod()
        {
            StreamParse parser = new StreamParse();
            parser.DataRead(Constants.Constants.StreamReaderFilePath);

            List<Truck> expectedTrucks = Transports.trucks;
            List<Semitrailer> expectedTrailers = Transports.semitrailers;

            TransportUnitTests.FillingTransport();
            List<Truck> actualdTrucks = Transports.trucks;
            List<Semitrailer> actualdTrailer = Transports.semitrailers;

            CollectionAssert.Equals(expectedTrucks, actualdTrucks);
            CollectionAssert.Equals(expectedTrailers, actualdTrailer);
        }

        [TestMethod]
        public void StreamWriter_TestMethod()
        {
            TransportUnitTests.FillingTransport();
            StreamParse parser = new StreamParse();
            parser.DataWrite(Constants.Constants.StreamWriterFilePath);

            Transports.trucks = null;
            Transports.semitrailers = null;

        }

    }
}
