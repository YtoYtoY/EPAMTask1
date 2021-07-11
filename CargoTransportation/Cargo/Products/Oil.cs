using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportation.Cargo.Products
{
    public class Oil : Cargo
    {
        public Oil(string name, KeyValuePair<double, double> temperature, double weight) : base(name, temperature, weight)
        {
            Type = this.GetType().Name;
        }
    }
}
