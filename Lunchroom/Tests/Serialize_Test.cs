using System;
using System.Collections.Generic;
using Lunchroom.Classes;
using Lunchroom.Classes.ProcessingMethods;
using Lunchroom.Enums;
using Lunchroom.Manager;
using Lunchroom.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lunchroom.Tests
{
    /// <summary>
    /// Serialization and Deserialization Testing
    /// </summary>
    [TestClass]
    public class Serialize_Test
    {
        [TestMethod]
        public void Serialize_TestMethod()
        {
            Lunchroom<FoodRecipe, Ingredient>.GeneratePMTypes();
            /// processing methods for tomatoes, cucumbers and onions
            var saladProcessingMethods = new List<ProcessingMethod>() { new Shredding() };

            /// processing methods for sauce
            var sauceProcessingMethod = new List<ProcessingMethod>() { new SaladMixing() };

            /// add ingredients to lunchroom storage
            Chef.Chef.AddNewIngredient("Tomato", saladProcessingMethods, new StorageConditions(5), 4, 10);
            Chef.Chef.AddNewIngredient("Cucumber", saladProcessingMethods, new StorageConditions(5), 3, 10);
            Chef.Chef.AddNewIngredient("Onion", saladProcessingMethods, new StorageConditions(5), 4, 10);
            Chef.Chef.AddNewIngredient("Sauce", sauceProcessingMethod, new StorageConditions(3), 10, 2);


            /// add ingredients in to food recipe list
            var saladIngredients = new List<Ingredient>()
            {
                Lunchroom<FoodRecipe, Ingredient>.GetIngredient("Tomato", 5),
                Lunchroom<FoodRecipe, Ingredient>.GetIngredient("Cucumber", 5),
                Lunchroom<FoodRecipe, Ingredient>.GetIngredient("Onion", 2),
                Lunchroom<FoodRecipe, Ingredient>.GetIngredient("Sauce", 1)

            };

            /// add cooking sequence in to food recipe list
            var saladCookingSequence = Chef.Chef.SetRecipeSequenceAtIngredients(saladIngredients);

            /// make a new recipe
            Chef.Chef.AddNewRecipe("Salad", FoodTypes.Dish, saladIngredients, saladCookingSequence);


            /// Adding a new dish to the order table
            Lunchroom<FoodRecipe, Ingredient>.OrderList.Add(Chef.Chef.GetRecipeByName("Salad"));

            /// Fulfillment of an order...
            Lunchroom<FoodRecipe, Ingredient>.AddCookingFood("Salad");



            /// save all data
            SerializeHelper<FoodRecipe>.SetData();


        }

        [TestMethod]
        public void Deserialize_TestMethod()
        {
            /// get all data
            SerializeHelper<FoodRecipe>.GetDate();

        }
    }
}
