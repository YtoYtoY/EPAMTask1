using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Classes
{
    /// <summary>
    /// My Collection of couples non readonly values
    /// </summary>
    /// <typeparam name="T">ProcessingMethod object</typeparam>
    /// <typeparam name="U"></typeparam>
    [Serializable]
    [DataContract]
    public class MyPMTuples<T, U> where T : ProcessingMethod
    {

        public MyPMTuples(T _Item1, U _Item2)
        {
            Item1 = _Item1;
            Item2 = _Item2;
        }
        [DataMember]
        public T Item1 { get; set; }

        [DataMember]
        public U Item2 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is MyPMTuples<T, U> storage)
            {
                return Item1.Name.Equals(storage.Item1.Name) && Item2.Equals(storage.Item2);
            }
            return false;
        }
    }
}
