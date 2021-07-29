using Lunchroom.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Lunchroom.Classes
{
    /// <summary>
    /// Food recipe class
    /// </summary>
    [Serializable]
    [DataContract]
    public class FoodRecipe
    {
        public FoodRecipe(string name, FoodTypes type, ICollection<Ingredient> ingredients, ICollection<ProcessingMethod> sequence)
        {
            Name = name;
            Ingredients = ingredients;
            Sequence = sequence;
            Type = type;
        }
        /// <summary>
        /// Food name
        /// </summary>
        [DataMember]
        public string Name { get; private set; }

        /// <summary>
        /// Food type
        /// </summary>
        [DataMember]
        public FoodTypes Type { get; private set; }

        /// <summary>
        /// Food composition
        /// </summary> 
        [DataMember]
        public ICollection<Ingredient> Ingredients { get; private set; }

        /// <summary>
        /// Food cooking sequence
        /// </summary>
        [DataMember]
        public ICollection<ProcessingMethod> Sequence { get; private set; }

        /// <summary>
        /// Property for calculating the total cost of a dish
        /// </summary>
        public float GetCostForRecipe
        {
            get
            {
                float price = 0;
                foreach (var item in Ingredients)
                    price += item.GetCost() * item.GetCount();
                foreach(var item in Sequence)
                    price += item.GetCost();
                return price;
            }
        }

        public override string ToString()
        {
            return Name + "; "
                + Type + ";/n"
                + Ingredients.ToString() + ";/n"
                + Sequence.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is FoodRecipe food &&
                Name == food.Name &&
                Type == food.Type &&
                Ingredients.Equals(food.Ingredients);
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Name);
            hash.Add(Type);
            return hash.ToHashCode();
        }
    }
}
