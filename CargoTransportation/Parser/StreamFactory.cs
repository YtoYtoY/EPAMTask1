using CargoTransportation.Transport;
using CargoTransportation.Trasnsport;
using CargoTransportation.Trasnsport.Trucks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CargoTransportation.Parser
{
    // TODO: Создать логику записи xml-файлов
    class StreamFactory : IParse
    {


        public void DataRead(string path)
        {
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
                            if ((line = reader.ReadLine()).Contains("Model") && !line.Contains("/"))
                            {
                                int type = int.Parse(Regex.Match(line, pattern).Value);
                                
                                if ((line = reader.ReadLine()).Contains("TrailerWeight"))
                                {
                                    double weight = Double.Parse(Regex.Match(line, pattern).Value);
                                    ///
                                    Truck truck = new FirstTruck(weight);
                                    ///
                                    break;
                                }
                                
                            }
                        }
                    }
                    if (line.Contains("Semitrailer") && !line.Contains("/"))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains("Weight"))
                            {
                                double weight = Double.Parse(Regex.Match(line, pattern).Value);
                                double value = Double.Parse(Regex.Match(reader.ReadLine(), pattern).Value);

                                break;
                            }
                        }

                    }
                }
            }
        }

        public void DataWrite(string path)
        {
            using(StreamWriter writer = File.CreateText(path))
            {

            }
        }
    }
}
