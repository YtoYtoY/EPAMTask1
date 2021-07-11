using CargoTransportation.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportation.Tests
{
    public class NewSemitrailerTest : Semitrailer
    {
        public override void LoaddSemiTrailer(Cargo.Cargo obj)
        {
            throw new NotImplementedException();
        }

        public override void UnloadSemitrailer(Cargo.Cargo obj)
        {
            throw new NotImplementedException();
        }
    }
}
