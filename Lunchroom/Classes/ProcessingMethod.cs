using Lunchroom.Classes.ProcessingMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Classes
{
    /// <summary>
    /// Processing method abstract class
    /// </summary>
    [Serializable]
    [DataContract]
    [KnownType("GetTypes")] /// Serializing class heirs
    public abstract class ProcessingMethod
    {

        public ProcessingMethod(string name, int duration, float cost)
        {
            Name = name;
            DurationOfProcessing = duration;
            ProcessingCost = cost;
        }

        /// <summary>
        /// Processing method name
        /// </summary>
        [DataMember]
        public string Name { get; private set; }

        /// <summary>
        /// Processing method duration
        /// </summary>
        [DataMember]
        protected int DurationOfProcessing { get; private set; }

        /// <summary>
        /// Processing method cost
        /// </summary>
        [DataMember]
        protected float ProcessingCost { get; private set; }

        /// <summary>
        /// Processing method capacity
        /// </summary>
        [DataMember]
        public int ProcessingCapacity { get; set; }


        /// <summary>
        /// Get processing method cost
        /// </summary>
        /// <returns>ProcessingCost</returns>
        public float GetCost() => ProcessingCost;


        /// <summary>
        /// Duration comparison
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        /// <returns></returns>
        public static int CompareByDuration(ProcessingMethod alpha, ProcessingMethod beta)
        {
            return alpha.DurationOfProcessing.CompareTo(beta.DurationOfProcessing);
        }

        /// <summary>
        /// Cost comparison
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        /// <returns></returns>
        public static float CompareByCost(ProcessingMethod alpha, ProcessingMethod beta)
        {
            return alpha.ProcessingCost.CompareTo(beta.ProcessingCost);
        }

        /// <summary>
        /// The method returns the IEnumerable collection of descendant
        /// types for automatic serialization of these objects
        /// </summary>
        /// <returns>Type collection</returns>
        private static IEnumerable<Type> GetTypes()
        {
            Type baseType = typeof(ProcessingMethod);
            IEnumerable<Type> processingMethodsTypes = Assembly.GetAssembly(baseType).GetTypes().Where(type => type.IsSubclassOf(baseType));
            return processingMethodsTypes;
        }

        public override string ToString()
        {
            return Name + "; " + DurationOfProcessing + "; " + ProcessingCost;
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Name);
            hash.Add(DurationOfProcessing);
            hash.Add(ProcessingCost);
            return hash.ToHashCode();
            
        }

        public override bool Equals(object obj)
        {
            return obj is ProcessingMethod method &&
                   Name == method.Name &&
                   DurationOfProcessing == method.DurationOfProcessing &&
                   ProcessingCost == method.ProcessingCost;
        }
    }
}
