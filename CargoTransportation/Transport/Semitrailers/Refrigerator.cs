﻿using CargoTransportation.Constants;
using CargoTransportation.Transport;
using System;
using System.Collections.Generic;

namespace CargoTransportation.Trasnsport.Semitrailers
{
    public class Refrigerator : Semitrailer
    {
        public Refrigerator(double maxWeight, double value) : base(maxWeight, value) 
        {
            specificType = new KeyValuePair<int, string>(3, this.GetType().Name);
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
                    if (CurrentProducts[CurrentProducts.Count - 1].MinTemperature == obj.MinTemperature 
                        && CurrentProducts[CurrentProducts.Count - 1].MaxTemperature == obj.MaxTemperature)
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
                    for (int i = 0; i < CurrentProducts.Count; i++)
                    {
                        if (CurrentProducts[i].Type == obj.Type && CurrentProducts[i].Name == obj.Name
                            && CurrentProducts[i].MinTemperature == obj.MinTemperature && CurrentProducts[i].MaxTemperature == obj.MaxTemperature)
                        {
                            CurrentWeight -= obj.Weight;
                            if (CurrentProducts[i].Weight == obj.Weight)
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
