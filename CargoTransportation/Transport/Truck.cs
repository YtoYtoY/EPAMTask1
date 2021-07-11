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
        protected KeyValuePair<int, string> specificType { get; set; }
        public Truck(double weight)
        {
            PermissibleWeight = weight;
            ConnectedSemitrailer = null;
        }
        public double FuelConsumption { get; private set; }
        public double ValueConsumption { get; set; }
        private double PermissibleWeight { get; set; }

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
            // How to count it ? \\
            FuelConsumption = ValueConsumption / Constants.Constants.DistanceTraveled * Constants.Constants.Kilometers;
        }

        public abstract Truck Create(double weight, int type);

        public virtual KeyValuePair<int, string> GetModel()
        {
            return specificType;
        }
        public double GetWeight()
        {
            return PermissibleWeight;
        }
    }
}
