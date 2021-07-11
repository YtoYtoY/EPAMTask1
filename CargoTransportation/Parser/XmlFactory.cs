using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CargoTransportation.Parser
{
    // TODO: Создать логику записи xml-файлов
    class XmlFactory : IParse
    {
        public void DataRead(string path)
        {
            using (XmlReader reader = XmlReader.Create(path))
            {
                reader.MoveToContent();
                if(reader.IsEmptyElement)
                {
                    reader.Read();
                    return;
                }
                reader.Read();
                while(!reader.EOF)
                {
                    double weight = 0, value = 0;
                    if(reader.IsStartElement())
                    {
                        switch(reader.Name)
                        {
                            case "Truck":
                                {
                                    //Model
                                    weight = Convert.ToDouble(reader.ReadElementContentAsString());
                                    break;
                                }
                            case "Semitrailer":
                                {
                                    //Type
                                    weight = Convert.ToDouble(reader.ReadElementContentAsString());
                                    value = Convert.ToDouble(reader.ReadElementContentAsString());
                                    break;
                                }
                            default:
                                {
                                    reader.Skip();
                                    break;
                                }
                        }
                    }
                    else
                    {
                        reader.Read();
                        break;
                    }
                }
            }
            //reader.ReadStartElement("CarPark");
            //while (reader.Name == "Truck")
            //{
            //    XmlElement el = (XmlElement)XmlNode.ReadFrom(reader);
            //}

            //while (reader.Name == "Semitrailer")
            //{
            //    XElement el = (XElement)XNode.ReadFrom(reader);
            //}
            //reader.ReadEndElement();
        }

        public void DataWrite(string path)
        {
            throw new NotImplementedException();
        }
    }
}
