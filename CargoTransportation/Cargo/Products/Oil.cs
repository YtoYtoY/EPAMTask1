using System.Collections.Generic;

namespace CargoTransportation.Cargo.Products
{
    /// <summary>
    /// Тип груза - топливо
    /// </summary>
    public class Oil : Cargo
    {
        public Oil(string name, KeyValuePair<double, double> temperature, double weight) : base(name, temperature, weight)
        {
            Type = this.GetType().Name;
        }
        public override object GetInfo()
        {
            return null;
        }
    }
}
