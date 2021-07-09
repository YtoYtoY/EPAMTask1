using CargoTransportation.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportation.Transport
{
    public abstract class Semitrailer
    {

        public Cargo.Cargo CurrentProduct { get; set; }
        public double CurrentWeight { get; set; }
        public double Value { get; private set; }

        public static double MaxWeight;

        public abstract void LoaddSemiTrailer(double weight, Cargo.Cargo obj);
        public abstract void UnloadSemitrailer(double weight, Cargo.Cargo obj);

       


    }
}
