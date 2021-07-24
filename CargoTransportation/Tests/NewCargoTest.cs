using System.Collections.Generic;

namespace CargoTransportation.Tests
{

    /// <summary>
    /// Новый грузовой объект
    /// </summary>
    public class NewCargoTest : Cargo.Cargo 
    {
        public bool Dimensions { get; set; }
        public NewCargoTest(string name, KeyValuePair<double, double> temperature, double weight, bool dimensions) : base(name, temperature, weight)
        {
            Type = this.GetType().Name;
            Dimensions = dimensions;
        }

        public override object GetInfo()
        {
            return Dimensions;
        }
    }
}
