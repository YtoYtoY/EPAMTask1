using CargoTransportation.Transport;
using CargoTransportation.Trasnsport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace CargoTransportation.Parser
{
    class XmlParse : IParse
    {

        /// <summary>
        /// Метод чтения данных в котором используется объект класса XmlReader
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void DataRead(string path)
        {
            Transports.trucks = new List<Truck>();
            Transports.semitrailers = new List<Semitrailer>();

            Transports.GenerateSemitrailerTypes();
            Transports.GenerateTruckTypes();

            //Чтение из Xml файла седельных тягачей
            using (var reader = XmlReader.Create(path))
            {
                reader.ReadToFollowing("Truck");
                do
                {

                    reader.ReadToFollowing("Model");
                    var model = Convert.ToInt32(reader.ReadElementContentAsString());

                    reader.ReadToFollowing("TrailerWeight");
                    var weight = Convert.ToDouble(reader.ReadElementContentAsString());

                    //**********************************
                    var typeOfTruck = Transports.trucksTypes.ToList()[model - 1];
                    var tmp = Activator.CreateInstance(typeOfTruck, weight) as Truck;
                    Transports.trucks.Add(tmp);

                } while (reader.ReadToFollowing("Truck"));
            }

            //Чтение из Xml файла полуприцепов
            using (var reader = XmlReader.Create(path))
            { 

                reader.ReadToFollowing("Semitrailer");
                do
                {

                    reader.ReadToFollowing("Type");
                    var type = Convert.ToInt32(reader.ReadElementContentAsString());

                    reader.ReadToFollowing("Weight");
                    var weight = Convert.ToDouble(reader.ReadElementContentAsString());

                    reader.ReadToFollowing("Value");
                    var value = Convert.ToDouble(reader.ReadElementContentAsString());

                    //**********************************
                    var typeOfTrailer = Transports.trailersTypes.ToList()[type - 1];
                    var tmp = Activator.CreateInstance(typeOfTrailer, weight, value) as Semitrailer;
                    Transports.semitrailers.Add(tmp);

                } while (reader.ReadToFollowing("Semitrailer"));
            }
        }

        /// <summary>
        /// Метод записи данных в Xml файл с использованием объекта класса XmlWriter
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void DataWrite(string path)
        {
            // XmlWriterSettings нужен для автоматической вставки отступов и переходов на новую строку
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t",
                NewLineOnAttributes = true
            };

            // Запись данных в файл
            using (XmlWriter writer = XmlWriter.Create(path, xmlWriterSettings))
            {
                writer.WriteStartDocument();

                writer.WriteStartElement("CarPark");

                for(int i = 0; i < Transports.semitrailers.Count; i++)
                {
                    writer.WriteStartElement("Truck");

                    writer.WriteStartElement("Model");
                    writer.WriteString(Transports.trucks[i].GetModel().Key.ToString());
                    writer.WriteEndElement();

                    writer.WriteStartElement("TrailerWeight");
                    writer.WriteString(Transports.trucks[i].GetWeight().ToString());
                    writer.WriteEndElement();                  

                    writer.WriteEndElement();
                }

                for(int i = 0; i < Transports.semitrailers.Count; i++)
                {
                    writer.WriteStartElement("Semitrailer");

                    writer.WriteStartElement("Type");
                    writer.WriteString(Transports.semitrailers[i].GetTrailerType().Key.ToString());
                    writer.WriteEndElement();

                    writer.WriteStartElement("Weight");
                    writer.WriteString(Transports.semitrailers[i].GetWeight().ToString());
                    writer.WriteEndElement();

                    writer.WriteStartElement("Value");
                    writer.WriteString(Transports.semitrailers[i].Value.ToString());
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }
                writer.WriteEndDocument();
                writer.Close();
            }
        }
    }
}
