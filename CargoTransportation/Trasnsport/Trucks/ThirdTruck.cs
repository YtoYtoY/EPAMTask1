using CargoTransportation.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportation.Trasnsport.Trucks
{
    public class ThirdTruck : Truck
    {
        public ThirdTruck(double weight) : base(weight) { }

        public override Truck Create(double weight)
        {
            return new ThirdTruck(weight);
        }
    }
}
