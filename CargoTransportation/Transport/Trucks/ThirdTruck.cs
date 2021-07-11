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
        public ThirdTruck(double weight) : base(weight)
        {
            specificType = new KeyValuePair<int, string>(3, this.GetType().Name);
            ValueConsumption = 9;
        }

        public override Truck Create(double weight, int type)
        {
            if (type == specificType.Key)
                return new ThirdTruck(weight);
            else
                return null;
        }

    }
}
