using CargoTransportation.Transport;
using System.Collections.Generic;

namespace CargoTransportation.Trasnsport.Trucks
{
    public class FirstTruck : Truck
    {
        public FirstTruck(double weight) : base(weight)
        {
            specificType = new KeyValuePair<int, string>(1, this.GetType().Name);
            ValueConsumption = 5;
        }
    }
}
