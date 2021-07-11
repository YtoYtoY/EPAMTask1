using CargoTransportation.Constants;
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
        public Awning(double maxWeight, double value) : base(maxWeight, value) 
        {
            specificType = new KeyValuePair<int, string>(2, this.GetType().Name);
        }

        public override Semitrailer Create(double weight, double value, int key)
        {
            if (key == specificType.Key)
                return new Awning(weight, value);
            else
                return null;
        }

        public override void LoaddSemiTrailer(Cargo.Cargo obj)
        {

            if (CurrentWeight + obj.Weight < this.GetWeight() && obj.Weight > 0)
            {
                if (CurrentProducts == null)
                {
                    CurrentWeight += obj.Weight;
                    CurrentProducts = new List<Cargo.Cargo>
                    {
                        obj
                    };
                }
                else
                {
                    if (CurrentProducts.GetType().Name.ToString() == obj.GetType().Name.ToString())
                    {
                        CurrentWeight += obj.Weight;
                        CurrentProducts.Add(obj);
                    }
                    else
                        throw new Exception(Exceptions.CargoTypeSemitrailerException);
                }
            }
            else
                throw new Exception(Exceptions.WeightSemitrailerException);

        }

        public override void UnloadSemitrailer(Cargo.Cargo obj)
        {
            if (CurrentWeight - obj.Weight > 0 && obj.Weight > 0)
            {
                if (CurrentProducts != null)
                {
                    for(int i = 0; i < CurrentProducts.Count; i++)
                    {
                        if(CurrentProducts[i].Type == obj.Type && CurrentProducts[i].Name == obj.Name)
                        {
                            CurrentWeight -= obj.Weight;
                            if(CurrentProducts[i].Weight == obj.Weight)
                            {
                                CurrentProducts.RemoveAt(i);
                                break;
                            }
                            else
                            {
                                if (CurrentProducts[i].Weight >= obj.Weight)
                                {
                                    CurrentProducts[i].Weight -= obj.Weight;
                                    break;
                                }
                                else
                                    throw new Exception(Exceptions.WeightSemitrailerException);
                            }
                        }
                    }

                }
                else
                    throw new NullReferenceException();
            }
            else
                throw new Exception(Exceptions.WeightSemitrailerException);
        }
    }
}
