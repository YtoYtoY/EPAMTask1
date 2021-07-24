using System.Collections.Generic;

namespace CargoTransportation.Cargo
{
    /// <summary>
    /// Абстрактный класс описывает грузовой объект
    /// </summary>
    public abstract class Cargo
    {
        public Cargo(string name, KeyValuePair<double, double> temperature, double weight)
        {
            Name = name;
            MinTemperature = temperature.Key;
            MaxTemperature = temperature.Value;
            Weight = weight;
        }
        public abstract object GetInfo();
        public string Type { get; set; }
        public string Name { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public double Weight { get; set; }

        public override string ToString()
        {
            return Type + ";" + Name + ";" + Weight;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    
}
