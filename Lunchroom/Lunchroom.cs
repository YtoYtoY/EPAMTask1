using Lunchroom.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Lunchroom
{
    /// <summary>
    /// Lunchroom class
    /// </summary>
    [Serializable]
    [DataContract]
    public static class Lunchroom<T, U> where T : FoodRecipe where U : Ingredient
    {
        /// <summary>
        /// List of cooking
        /// </summary>
        public static List<T> cookingFood = new List<T>();

        /// <summary>
        /// List of all production facilities
        /// </summary>
        [DataMember]
        public static List<MyPMTuples<ProcessingMethod, bool>> currentMethods = new List<MyPMTuples<ProcessingMethod, bool>>();


        /// <summary>
        /// Types of processing methods
        /// </summary>
        public static IEnumerable<Type> processingMethodsTypes;

        /// <summary>
        /// List of all orders in the kitchen
        /// </summary>
        public static List<T> OrderList = new List<T>();

        /// <summary>
        /// List of all ingredients in storage
        /// </summary>
        [DataMember]
        public static List<U> IngredientList = new List<U>();

        /// <summary>
        /// Storage conditions
        /// </summary>
        public static float[] AvailableTemperature = { 2, 6 };


        /// <summary>
        /// A method that creates a collection of processing method types
        /// </summary>
        public static void GeneratePMTypes()
        {
            Type baseType = typeof(ProcessingMethod);
            processingMethodsTypes = Assembly.GetAssembly(baseType).GetTypes().Where(type => type.IsSubclassOf(baseType));
        
            foreach (var item in processingMethodsTypes)
            {
                ProcessingMethod obj = (ProcessingMethod)Activator.CreateInstance(item);
                for (int i = 0; i < obj.ProcessingCapacity; i++)
                {
                    currentMethods.Add(new MyPMTuples<ProcessingMethod, bool>(obj, false));
                }
            }
        }

        /// <summary>
        /// Get ingredient by name from storage
        /// </summary>
        /// <param name="name">Ingredient name</param>
        /// <returns>Ingredient item</returns>
        public static U GetIngredient(string name, int count)
        {
            foreach (var item in IngredientList)
            {
                if (item.Name == name)
                {
                    if(item.GetCount() < count)
                        throw new Exception(Exceptions.IngredientCountException);
                    else
                        item.SetCount(count);
                    return item;
                }
            }
            throw new Exception(Exceptions.IngredientDoesNotExistException);
        }


        /// <summary>
        /// Finding ingredients according to storage conditions
        /// </summary>
        /// <param name="item">Comparison object</param>
        /// <returns>A collection of ingredients that meet this condition</returns>
        public static ICollection<U> GetIngredientsWithCondition(StorageConditions obj)
        {
            var resultCollection = new List<U>();
            foreach (var item in IngredientList)
            {
                if (item.Conditions.GetType().Name.Equals(obj.GetType().Name))
                {
                    resultCollection.Add(item);
                }
            }
            if (resultCollection.Count == 0)
                return null;
            else
                return resultCollection;
        }


        /// <summary>
        /// View of the current free production capacity
        /// </summary>
        /// <returns>List of free production facilities</returns>
        public static List<MyPMTuples<ProcessingMethod, bool>> GetFreeProductionCapacity()
        {
            var result = new List<MyPMTuples<ProcessingMethod, bool>>();
            foreach (var item in currentMethods)
            {
                if (item.Item2 == false)
                {
                    result.Add(item);
                }
            }
            return result;
        }


        /// <summary>
        /// Add a new dish to production
        /// </summary>
        /// <param name="name">Name from chef recipes</param>
        public static void AddCookingFood(string name)
        {
            foreach (var item in OrderList)
            {
                if(item.Name.Equals(name))
                {
                    foreach (var met in item.Sequence)
                    {
                        var find = new MyPMTuples<ProcessingMethod, bool>(met, false);
                        if (currentMethods.Contains(find))
                        {
                            int index = currentMethods.IndexOf(find);
                            currentMethods[index].Item2 = true;
                            // break;
                        }
                        else
                        {
                            throw new Exception(Exceptions.BusyException);
                        }
                    }
                    OrderList.Remove(item);
                    cookingFood.Add(item);
                    return;
                }
            }
            throw new Exception(Exceptions.FoodDoesNotExistInQueueException);
        }

        /// <summary>
        /// Removing a made dish from production
        /// </summary>
        /// <param name="food"></param>
        public static void RemoveCookingFood(T food)
        {
            if (cookingFood.Contains(food))
            {
                
                foreach (var met in food.Sequence)
                {
                    var find = new MyPMTuples<ProcessingMethod, bool>(met, true);
                    if (currentMethods.Contains(find))
                    {
                        int index = currentMethods.IndexOf(find);
                        currentMethods[index].Item2 = true;
                    }
                }
                cookingFood.Remove(food);
            }
            else throw new Exception(Exceptions.FoodDoseNotExistInKitchenException);
        }

        /// <summary>
        /// Search for free production facilities to check
        /// </summary>
        /// <param name="name">Name of processing method</param>
        /// <returns>true if there is such an element in the list, otherwise - false</returns>
        private static bool FindFreeMethod(string name)
        {
            foreach (var item in currentMethods)
            {
                if (item.Item1.Name == name)
                {
                    item.Item2 = true;
                    return true;
                }
            }
            return false;
        }
    }
}
