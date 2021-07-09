using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportation.Transport

{
    public abstract class Truck
    {
        public double FuelConsumption { get; private set; }
        public static double PermissibleWeight { get; private set; }

        public abstract void AddSemitrailer(Semitrailer semitrailer);
        public abstract void RemoveSemitrailer(Semitrailer semitrailer);

        public Semitrailer ConnectedSemitrailer { get; private set; }
    }
}
