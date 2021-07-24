using System.Collections.Generic;

namespace CargoTransportation.Cargo.Products
{
    /// <summary>
    /// Тип груза - еда
    /// </summary>
    public class Food : Cargo
    {
        public Food(string name, KeyValuePair<double, double> temperature, double weight) : base(name, temperature, weight)
        {
            Type = this.GetType().Name;
        }

        public override object GetInfo()
        {
            return null;
        }
    }
}
