using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportation.Cargo.Products
{
    public class Food : Cargo
    {
        public Food(string name, KeyValuePair<double, double> temperature, double weight)
        {
            Type = "Продукты питания";
            Name = name;
            MinTemperature = temperature.Key;
            MaxTemperature = temperature.Value;
            Weight = weight;
        }
    }
}
