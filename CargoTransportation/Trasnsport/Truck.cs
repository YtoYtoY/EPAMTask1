using CargoTransportation.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportation.Transport

{
    public abstract class Truck
    {
        public Truck(double weight)
        {
            PermissibleWeight = weight;
            ValueConsumption = 0.1;
            ConnectedSemitrailer = null;
        }
        public double FuelConsumption { get; private set; }
        public double ValueConsumption { get; set; }
        public static double PermissibleWeight { get; set; }

        public void AddSemitrailer(Semitrailer semitrailer)
        {
            if (ConnectedSemitrailer == null)
                ConnectedSemitrailer = semitrailer;
            else throw new Exception(Exceptions.TruckConnectionException);
        }
        public void RemoveSemitrailer(Semitrailer semitrailer)
        {
            ConnectedSemitrailer = null;
        }

        public Semitrailer ConnectedSemitrailer { get; set; }

        public void CalculateFuelConsumption()
        {
            // ? \\
            FuelConsumption = ValueConsumption / Constats.DistanceTraveled * Constats.Kilometers;
        }

        public abstract Truck Create(double weight);
    }
}
