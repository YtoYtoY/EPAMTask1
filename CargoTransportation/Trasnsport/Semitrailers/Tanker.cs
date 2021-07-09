using CargoTransportation.Constants;
using CargoTransportation.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace CargoTransportation.Trasnsport.Semitrailers
{
    public class Tanker : Semitrailer
    {
        public Tanker(double maxWeight, Cargo.Cargo type)
        {
            MaxWeight = maxWeight;
            CurrentProduct = type;
            CurrentWeight = 0;
        }

        public override void LoaddSemiTrailer(double weight, Cargo.Cargo obj)
        {

            if (CurrentWeight + weight < MaxWeight && weight > 0)
            {
                if(CurrentProduct == null)
                {
                    CurrentWeight += weight;
                    CurrentProduct = obj;
                }
                else
                {
                    if (CurrentProduct.Name == obj.Name)
                    {
                        CurrentWeight += weight;
                        CurrentProduct = obj;
                    }
                    else
                        throw new Exception(Exceptions.CargoTypeSemitrailerException);
                }
            }
            else
                throw new Exception(Exceptions.WeightSemitrailerException);

        }

        public override void UnloadSemitrailer(double weight, Cargo.Cargo obj)
        {
            throw new NotImplementedException();
        }
    }
}
