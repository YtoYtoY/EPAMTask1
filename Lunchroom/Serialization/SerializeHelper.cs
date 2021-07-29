using Lunchroom.Classes;
using Lunchroom.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Serialization
{
    /// <summary>
    /// Class to help with serialization and deserialization
    /// </summary>
    /// <typeparam name="T">Recipe</typeparam>
    public static class SerializeHelper<T> where T : FoodRecipe
    {
        /// <summary>
        /// Method for saving all data
        /// </summary>
        public static void SetData()
        {
            JsonSerialization json = new JsonSerialization();
            /// Saving recipes
            json.Save(Chef.Chef.GetRecipes(), Constants.RecipesSerializationTestPath);
            /// Saving ingredients
            json.Save(Lunchroom<T, Ingredient>.IngredientList, Constants.StorageSerializationTestPath);
            /// Saving rders
            json.Save(Manager.Manager<Order<FoodRecipe>>.orders, Constants.OrdersSerializationTestPath);
            /// Saving operations
            json.Save(Lunchroom<T, Ingredient>.currentMethods, Constants.OperationSerializationTestPath);
        }

        /// <summary>
        /// Method for getting all data
        /// </summary>
        public static void GetDate()
        {
            JsonSerialization json = new JsonSerialization();
            /// Getting recipes
            Chef.Chef.SetRecipes((List<FoodRecipe>)json.Restore<T>(Constants.RecipesSerializationTestPath));
            /// Getting ingredirnts
            Lunchroom<T, Ingredient>.IngredientList = 
                (List<Ingredient>)json.Restore<Ingredient>(Constants.StorageSerializationTestPath);
            /// Getting orders
            Manager.Manager<Order<FoodRecipe>>.orders =
                (List<Order<FoodRecipe>>)json.Restore<Order<FoodRecipe>>(Constants.OrdersSerializationTestPath);
            /// Getting operations
            Lunchroom<T, Ingredient>.currentMethods =
                (List<MyPMTuples<ProcessingMethod, Boolean>>)json.Restore<MyPMTuples<ProcessingMethod, Boolean>>(Constants.OperationSerializationTestPath);
        }
    }
}
