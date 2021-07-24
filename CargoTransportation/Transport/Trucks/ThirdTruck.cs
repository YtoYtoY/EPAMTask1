using CargoTransportation.Transport;
using System.Collections.Generic;

namespace CargoTransportation.Trasnsport.Trucks
{
    public class ThirdTruck : Truck
    {
        public ThirdTruck(double weight) : base(weight)
        {
            specificType = new KeyValuePair<int, string>(3, this.GetType().Name);
            ValueConsumption = 9;
        }

    }
}
