using CargoTransportation.Constants;
using CargoTransportation.Transport;
using System;
using System.Collections.Generic;

namespace CargoTransportation.Tests
{

    /// <summary>
    /// Класс для тестирования описывающий полу-прицеп - контейнеровоз
    /// </summary>
    public class NewSemitrailerTest : Semitrailer
    {
        public NewSemitrailerTest(double maxWeight, double value) : base(maxWeight, value)
        {
            specificType = new KeyValuePair<int, string>(4, "Container");
        }

        // Условие - перевозить можно только все хрупкие или все крепкие объекты
        public override void LoaddSemiTrailer(Cargo.Cargo obj)
        {
            if (CurrentWeight + obj.Weight < this.GetWeight() && obj.Weight > 0)
            {
                if (obj.GetType().IsAssignableFrom(typeof(NewCargoTest)))
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
                        var t1 = CurrentProducts[CurrentProducts.Count - 1].GetInfo();
                        var t2 = obj.GetInfo();
                        if (t2 != null && (bool)t1 == (bool)t2)
                        {
                            CurrentWeight += obj.Weight;
                            CurrentProducts.Add(obj);
                        }
                        else
                            throw new Exception(Exceptions.CargoTypeSemitrailerException);
                    }
                }
                else
                    throw new Exception(Exceptions.NewTestProductException);
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
                        if (CurrentProducts[i].Type == obj.Type && CurrentProducts[i].Name == obj.Name)
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
