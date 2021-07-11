using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportation.Transport
{
    public abstract class Semitrailer
    {
        protected KeyValuePair<int, string> specificType { get; set; }
        public Semitrailer(double maxWeight, double value)
        {
            MaxWeight = maxWeight;
            Value = value;
            CurrentProducts = null;
            CurrentWeight = 0;
        }
        public List<Cargo.Cargo> CurrentProducts { get; set; }
        public double CurrentWeight { get; set; }
        public double Value { get; set; }  

        private double MaxWeight;

        public abstract void LoaddSemiTrailer(Cargo.Cargo obj);
        public abstract void UnloadSemitrailer(Cargo.Cargo obj);


        public abstract Semitrailer Create(double weight, double value, int key);

        public virtual KeyValuePair<int, string> GetTrailerType()
        {
            return specificType;
        }

        public double GetWeight()
        {
            return MaxWeight;
        }
    }
}
