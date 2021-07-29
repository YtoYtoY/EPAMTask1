using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Lunchroom.Classes
{

    /// <summary>
    /// Ingredient class
    /// </summary>
    [Serializable]
    [DataContract]
    public class Ingredient
    {
        public Ingredient(string name, ICollection<ProcessingMethod> processingMethods,
            StorageConditions condition, float cost, int count)
        {
            Name = name;
            ProcessingMethods = processingMethods;

            Conditions = condition;

            Cost = cost;
            CurrentCount = count;
        }

        /// <summary>
        /// Ingredient name
        /// </summary>
        [DataMember]
        public string Name { get; private set; }

        /// <summary>
        /// Ingredient processing methods collection
        /// </summary>
        [DataMember]
        public ICollection<ProcessingMethod> ProcessingMethods { get; set; }

        /// <summary>
        /// Ingredient storage condition
        /// </summary>
        [DataMember]
        public StorageConditions Conditions { get; private set; }

        /// <summary>
        /// Ingredient cost
        /// </summary>
        [DataMember]
        private float Cost { get; set; }


        /// <summary>
        /// Ingredient current count on storage
        /// </summary>
        [DataMember]
        private int CurrentCount { get; set; }

        /// <summary>
        /// Get ingredient cost
        /// </summary>
        /// <returns>Cost</returns>
        public float GetCost() => Cost;

        /// <summary>
        /// Get ingredient storage count
        /// </summary>
        /// <returns>CurrentCount</returns>
        public int GetCount() => CurrentCount;

        /// <summary>
        /// Set ingredient storage count
        /// </summary>
        /// <param name="value">Count</param>
        public void SetCount(int value) => CurrentCount = value;


        public override string ToString()
        {
            return Name + "; "
                + Conditions + "; "
                + Cost + "; "
                + CurrentCount;
        }
        public override bool Equals(object obj)
        {
            return obj is Ingredient ing &&
                Name == ing.Name &&
                Conditions == ing.Conditions &&
                Cost == ing.Cost &&
                CurrentCount == ing.CurrentCount;
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Name);
            hash.Add(Conditions);
            hash.Add(Cost);
            hash.Add(CurrentCount);
            return hash.ToHashCode();
        }
    }
}
