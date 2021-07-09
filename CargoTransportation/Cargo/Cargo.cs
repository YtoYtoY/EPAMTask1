using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportation.Cargo
{
    public abstract class Cargo
    {
        public string Name { get; private set; }
        public double Temperature { get; private set; }

    }
}
