using CargoTransportation.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportation.Trasnsport.Semitrailers
{
    public class Awning : Semitrailer
    {
        public Awning(double maxWeight, Cargo.Cargo type)
        {
            MaxWeight = maxWeight;
            CurrentProduct = type;
        }

        public override void LoaddSemiTrailer(double weight, Cargo.Cargo obj)
        {
            throw new NotImplementedException();
        }

        public override void UnloadSemitrailer(double weight, Cargo.Cargo obj)
        {
            throw new NotImplementedException();
        }
    }
}
