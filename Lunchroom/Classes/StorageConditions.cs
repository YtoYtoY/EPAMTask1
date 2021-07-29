using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Classes
{
    /// <summary>
    /// The class describes various storage conditions
    /// </summary>
    [Serializable]
    [DataContract]
    public class StorageConditions
    {
        public StorageConditions(float temperature)
        {
            Temperature = temperature;
        }
        
        [DataMember]
        public float Temperature { get; private set; }

        public override string ToString()
        {
            return Temperature.ToString();
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Temperature);
            return hash.ToHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is StorageConditions conditions &&
                Temperature == conditions.Temperature;
        }
    }
}
