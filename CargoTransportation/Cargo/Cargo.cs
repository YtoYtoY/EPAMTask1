using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportation.Cargo
{
    public abstract class Cargo
    {
        public Cargo(string name, KeyValuePair<double, double> temperature, double weight)
        {
            Name = name;
            MinTemperature = temperature.Key;
            MaxTemperature = temperature.Value;
            Weight = weight;
        }
        public string Type { get; set; }
        public string Name { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public double Weight { get; set; }
    }
}
