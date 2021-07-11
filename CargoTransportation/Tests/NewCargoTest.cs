using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportation.Tests
{

    /// <summary>
    /// Класс для тестирования описывающий масштаб объектов
    /// </summary>
    public class NewCargoTest : Cargo.Cargo 
    {
        public  bool Dimensions { get; set; }
        public NewCargoTest(string name, KeyValuePair<double, double> temperature, double weight, bool dimensions) : base(name, temperature, weight)
        {
            Type = this.GetType().Name;
            Dimensions = dimensions;
        }
    }
}
