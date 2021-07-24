using CargoTransportation.Transport;
using System.Collections.Generic;

namespace CargoTransportation.Trasnsport.Trucks
{
    public class SecondTruck : Truck
    {
        public SecondTruck(double weight) : base(weight)
        {
            specificType = new KeyValuePair<int, string>(2, this.GetType().Name);
            ValueConsumption = 7;
        }
    }
}
