using Lunchroom.Classes;
using Lunchroom.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Chef
{
    /// <summary>
    /// The class describes the functions and methods of the chef
    /// </summary>
    public static class Chef
    {
        /// <summary>
        /// List of recipes
        /// </summary>
        private static List<FoodRecipe> Recipes = new List<FoodRecipe>();

        /// <summary>
        /// Method for creating a new recipe
        /// </summary>
        /// <param name="name">Name of the dish</param>
        /// <param name="ingredients">Ingredient list/collection</param>
        /// <param name="sequence">Cooking sequence list/collection</param>
        public static void AddNewRecipe(string name, FoodTypes type, ICollection<Ingredient> ingredients, ICollection<ProcessingMethod> sequence)
        {
            Recipes.Add(new FoodRecipe(name, type, ingredients, sequence));
        }

        /// <summary>
        /// A method for adding a new ingredient to a lunchroom storage
        /// </summary>
        /// <param name="name">Ingredient name</param>
        /// <param name="method">List of ingredient processing methods</param>
        /// <param name="temperature">Storage condition</param>
        /// <param name="cost">Price per kilogram</param>
        public static void AddNewIngredient(string name, ICollection<ProcessingMethod> method, StorageConditions conditions, float cost, int count)
        {
            if (conditions.Temperature > Lunchroom<FoodRecipe, Ingredient>.AvailableTemperature[0] &&
                conditions.Temperature < Lunchroom<FoodRecipe, Ingredient>.AvailableTemperature[1])
            {
                Lunchroom.Lunchroom<FoodRecipe, Ingredient>.IngredientList.Add(
                    new Ingredient(name, method, conditions, cost, count));
            }
            else throw new Exception(Exceptions.IngredientDoesNotMeetConditions);
        }

        /// <summary>
        /// Getting a cooking sequence from a list of ingredients
        /// </summary>
        /// <param name="recipeIngredients">List of ingredients</param>
        /// <returns>Collection of processing methods</returns>
        public static ICollection<ProcessingMethod> SetRecipeSequenceAtIngredients(ICollection<Ingredient> recipeIngredients)
        {
            var methods = new List<ProcessingMethod>();
            foreach (var item in recipeIngredients)
            {
                foreach (var met in item.ProcessingMethods)
                {
                    methods.Add(met);
                }
            }
            return methods;
        }

        /// <summary>
        /// Get recipe list
        /// </summary>
        /// <returns>Collection of recipes</returns>
        public static ICollection<FoodRecipe> GetRecipes() => Recipes;

        /// <summary>
        /// Set recipe list
        /// </summary>
        /// <param name="food">List of recipes</param>
        public static void SetRecipes(List<FoodRecipe> food) => Recipes = food;

        /// <summary>
        /// Get recipe by name
        /// </summary>
        /// <param name="name">Item name</param>
        /// <returns></returns>
        public static FoodRecipe GetRecipeByName(string name)
        {
            foreach (var item in Recipes)
            {
                if (item.Name.Equals(name)) return item;
            }
            throw new Exception(Exceptions.RecipeDoesNotExistException);

        }
    }
}
