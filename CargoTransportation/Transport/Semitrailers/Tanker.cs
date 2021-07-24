using CargoTransportation.Constants;
using CargoTransportation.Transport;
using System;
using System.Collections.Generic;

namespace CargoTransportation.Trasnsport.Semitrailers
{
    public class Tanker : Semitrailer 
    {
        public Tanker(double maxWeight, double value) : base(maxWeight, value) 
        {
            specificType = new KeyValuePair<int, string>(1, this.GetType().Name);
        }


        public override void LoaddSemiTrailer(Cargo.Cargo obj)
        {

            if (CurrentWeight + obj.Weight < this.GetWeight() && obj.Weight > 0)
            {
                if(CurrentProducts == null)
                {
                    CurrentWeight += obj.Weight;
                    CurrentProducts = new List<Cargo.Cargo>
                    {
                        obj
                    };
                }
                else
                {
                    if (CurrentProducts[0].Name == obj.Name)
                    {
                        CurrentWeight += obj.Weight;
                    }
                    else
                        throw new Exception(Exceptions.CargoNameSemitrailerException);
                }
            }
            else
                throw new Exception(Exceptions.WeightSemitrailerException);

        }

        public override void UnloadSemitrailer(Cargo.Cargo obj)
        {
            if (CurrentWeight - obj.Weight > 0 && obj.Weight > 0)
            {
                if (CurrentProducts != null && CurrentProducts[0].Name == obj.Name && CurrentProducts[0].Type == obj.Type)
                {
                    CurrentWeight -= obj.Weight;
                    if (CurrentWeight == obj.Weight)
                        CurrentProducts = null;
                }
                else
                    throw new Exception(Exceptions.CargoNameSemitrailerException);
            }
            else
                throw new Exception(Exceptions.WeightSemitrailerException);
        }
    }
}
