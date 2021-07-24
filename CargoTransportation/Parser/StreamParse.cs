using CargoTransportation.Transport;
using CargoTransportation.Trasnsport;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CargoTransportation.Parser
{

    class StreamParse : IParse
    {
        /// <summary>
        /// Метод чтения данных в котором используется объект класса StreamReader
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void DataRead(string path)
        {
            Transports.trucks = new List<Truck>();
            Transports.semitrailers = new List<Semitrailer>();

            Transports.GenerateSemitrailerTypes();
            Transports.GenerateTruckTypes();

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
                                    
                                    var typeOfTruck = Transports.trucksTypes.ToList()[type - 1];
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
                                    var typeOfTrailer = Transports.trailersTypes.ToList()[type - 1];
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

        /// <summary>
        /// Метод записи данных в котором используется объект класса StreamWriter
        /// </summary>
        /// <param name="path"></param>
        public void DataWrite(string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf - 8\"?>");
                writer.Write(CreateElement(0, "CarPark"));
                for (int i = 0; i < Transports.semitrailers.Count; i++)
                {
                    writer.Write(CreateElement(1, "Truck"));
                    writer.Write(CreateValueElement(2, "Model", Transports.trucks[i].GetModel().Key.ToString()));
                    writer.Write(CreateValueElement(2, "TrailerWeight", Transports.trucks[i].GetWeight().ToString()));
                    writer.Write(CloseElement(1, "Truck"));
                }
                for (int i = 0; i < Transports.semitrailers.Count; i++)
                {
                    writer.Write(CreateElement(1, "Semitrailer"));
                    writer.Write(CreateValueElement(2, "Type", Transports.semitrailers[i].GetTrailerType().Key.ToString()));
                    writer.Write(CreateValueElement(2, "Weight", Transports.semitrailers[i].GetWeight().ToString()));
                    writer.Write(CreateValueElement(2, "Value", Transports.semitrailers[i].Value.ToString()));
                    writer.Write(CloseElement(1, "Semitrailer"));

                }
                writer.Write(CloseElement(0, "CarPark"));
                writer.Close();
            }
        }

        /// <summary>
        /// Создание елемента с большим количеством данных
        /// </summary>
        /// <param name="tab">Последовательность для табуляции</param>
        /// <param name="text">Название элемента</param>
        /// <returns>&lt;text&gt;</returns>
        private static string CreateElement(int tab, string text)
        {
            string tabResult = String.Empty;
            for (int i = 0; i < tab; i++)
                tabResult += "\t";
            return tabResult + "<" + text + ">\n";
        }

        /// <summary>
        /// Создание элемента с значением (поле)
        /// </summary>
        /// <param name="tab">Последовательность для табуляции</param>
        /// <param name="text">Название элемента</param>
        /// <param name="value">Значение элемента</param>
        /// <returns>&lt;text&gt;value&lt;/text&gt;</returns>
        private static string CreateValueElement(int tab, string text, string value)
        {
            string tabResult = String.Empty;
            for (int i = 0; i < tab; i++)
                tabResult += "\t";
            return tabResult + "<" + text + ">" + value + "</" + text + ">\n"; 
        }

        /// <summary>
        /// Закрытие элемента
        /// </summary>
        /// <param name="tab">Последовательность для табуляции</param>
        /// <param name="text">Название элемента</param>
        /// <returns>&lt;/text&gt;</returns>
        private static string CloseElement(int tab, string text)
        {
            string tabResult = String.Empty;
            for (int i = 0; i < tab; i++)
                tabResult += "\t";
            return tabResult + "</" + text + ">\n";
        }
    }
}
