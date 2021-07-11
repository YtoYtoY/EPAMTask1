using CargoTransportation.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportation.Trasnsport.Trucks
{
    public class SecondTruck : Truck
    {
        public SecondTruck(double weight) : base(weight)
        {
            specificType = new KeyValuePair<int, string>(2, this.GetType().Name);
            ValueConsumption = 7;
        }

        public override Truck Create(double weight, int type)
        {
            if (type == specificType.Key)
                return new SecondTruck(weight);
            else
                return null;
        }
    }
}
