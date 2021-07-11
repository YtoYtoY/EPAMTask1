using CargoTransportation.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportation.Trasnsport.Trucks
{
    public class FirstTruck : Truck
    {
        public FirstTruck(double weight) : base(weight)
        {
            specificType = new KeyValuePair<int, string>(1, this.GetType().Name);
            ValueConsumption = 5;
        }

        public override Truck Create(double weight, int type)
        {
            if (type == specificType.Key)
                return new FirstTruck(weight);
            else
                return null;
        }
    }
}
