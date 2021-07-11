using CargoTransportation.Transport;
using CargoTransportation.Trasnsport;
using CargoTransportation.Trasnsport.Semitrailers;
using CargoTransportation.Trasnsport.Trucks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace CargoTransportation.Parser
{
    class StreamFactory : IParse
    {
        public void DataRead(string path)
        {
            Transports.trucks = new List<Truck>();
            Transports.semitrailers = new List<Semitrailer>();

            using (StreamReader reader = File.OpenText(path))
            {
                string line = "";
                string pattern = @"[0-9\.]+";
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("CarPark") && line.Contains("/"))
                        break;
                    if (line.Contains("Truck") && !line.Contains("/"))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains("Model"))
                            {
                                int type = int.Parse(Regex.Match(line, pattern).Value);
                                
                                if ((line = reader.ReadLine()).Contains("TrailerWeight"))
                                {
                                    
                                    double weight = Double.Parse(Regex.Match(line, pattern).Value);

                                    //**********************************
                                    var typeOfTruck = Transports.trucksTypes[type - 1];
                                    var tmp = Activator.CreateInstance(typeOfTruck, weight) as Truck;
                                    Transports.trucks.Add(tmp);

                                    break;
                                }
                                
                            }
                        }
                    }
                    if (line.Contains("Semitrailer") && !line.Contains("/"))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains("Type"))
                            {
                                int type = int.Parse(Regex.Match(line, pattern).Value);

                                if ((line = reader.ReadLine()).Contains("Weight"))
                                {
                                    double weight = Double.Parse(Regex.Match(line, pattern).Value);
                                    double value = Double.Parse(Regex.Match(reader.ReadLine(), pattern).Value);

                                    //**********************************
                                    var typeOfTrailer = Transports.trailersTypes[type - 1];
                                    var tmp = Activator.CreateInstance(typeOfTrailer, weight, value) as Semitrailer;
                                    Transports.semitrailers.Add(tmp);

                                    break;
                                }

                            }
                        }

                    }
                }
            }
        }

        public void DataWrite(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            using (StreamWriter writer = new StreamWriter(path))
            {
                XmlNode rootNode = xmlDoc.CreateElement("CarPark");
                xmlDoc.AppendChild(rootNode);

               
                for (int i = 0; i < Transports.semitrailers.Count; i++)
                {
                    XmlNode truckNode = xmlDoc.CreateElement("Truck");

                    XmlNode modelNode = xmlDoc.CreateElement("Model");
                    modelNode.InnerText = Transports.trucks[i].GetModel().Key.ToString();
                    truckNode.AppendChild(modelNode);

                    XmlNode weightNode = xmlDoc.CreateElement("TrailerWeight");
                    weightNode.InnerText = Transports.trucks[i].GetWeight().ToString();
                    truckNode.AppendChild(weightNode);

                    rootNode.AppendChild(truckNode);
                }

                for (int i = 0; i < Transports.semitrailers.Count; i++)
                {

                    XmlNode trailerkNode = xmlDoc.CreateElement("Semitrailer");

                    XmlNode typekNode = xmlDoc.CreateElement("Type");
                    typekNode.InnerText = Transports.semitrailers[i].GetTrailerType().Key.ToString();
                    trailerkNode.AppendChild(typekNode);

                    XmlNode weightNode = xmlDoc.CreateElement("Weight");
                    weightNode.InnerText = Transports.semitrailers[i].GetWeight().ToString();
                    trailerkNode.AppendChild(weightNode);

                    XmlNode valueNode = xmlDoc.CreateElement("Value");
                    valueNode.InnerText = Transports.semitrailers[i].Value.ToString();
                    trailerkNode.AppendChild(valueNode);

                    rootNode.AppendChild(trailerkNode);
                }
            }
            xmlDoc.Save(path);
        }
    }
}
