using Lunchroom.Classes;
using Lunchroom.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Manager
{
    /// <summary>
    /// The class describes the methods and functions of the manager
    /// </summary>
    /// <typeparam name="T">Order type</typeparam>
    public static class Manager<T> where T : Order<FoodRecipe>
    {
        /// <summary>
        /// List of all orders
        /// </summary>
        public static List<T> orders = new List<T>();

        /// <summary>
        /// Method for adding a new order
        /// </summary>
        /// <param name="food">list of ordered food</param>
        public static void CommitNewOrder(List<FoodRecipe> food)
        {
            int commitNewNumber;

            if (orders.Last() != null)
                commitNewNumber = orders.Last().OrderNumber + 1;
            else
                commitNewNumber = 0;

            
            var newOrder = new Order<FoodRecipe>(commitNewNumber, food);
            newOrder.DateOfBeginning = DateTime.Now;
            orders.Add((T)newOrder);

        }

        /// <summary>
        /// Method for adding a new ordered food to an existing order
        /// </summary>
        /// <param name="number">Number of client/order</param>
        /// <param name="food">List of ordered food</param>
        public static void CommitNewFoodInOrder(int number, List<FoodRecipe> food)
        {
            foreach(var item in orders)
            {
                if(item.OrderNumber == number)
                {
                    item.AddFoodInOrder(food);
                    return;
                }
            }
            throw new Exception(Exceptions.ClientDoesNotExistException);
        }


        /// <summary>
        /// The method returns a collection of completed orders
        /// </summary>
        /// <returns>Return List if there are elements, otherwise - null</returns>
        private static ICollection<T> GetCompletedOrders()
        {
            var resultCollection = new List<T>();
            foreach (var item in orders)
            {
                if (item.isComplete)
                    resultCollection.Add(item);
            }
            if (resultCollection.Count != 0)
                return resultCollection;
            else return null;
        }

        /// <summary>
        /// Method to complete the order
        /// </summary>
        /// <param name="number">Number of client/order</param>
        public static void CompleteOrder(int number)
        {
            foreach (var item in orders)
            {
                if (item.OrderNumber == number)
                {
                    item.DateOfEnding = DateTime.Now;
                    item.MakeComplete();
                    return;
                }
            }
            throw new Exception(Exceptions.ClientDoesNotExistException);
        }


        /// <summary>
        /// Viewing orders made for the specified period
        /// </summary>
        /// <param name="beginningDate">Period start</param>
        /// <param name="endDate">Period end</param>
        /// <returns>List of orders</returns>
        public static ICollection<T> GetCompletedOrders(DateTime beginningDate, DateTime endDate)
        {
            var resultCollection = new List<T>();
            foreach (var item in orders)
            {
                if (item.DateOfBeginning >= beginningDate &&
                    item.DateOfEnding <= endDate)
                {
                    resultCollection.Add(item);
                }
            }
            return resultCollection;

        }

        /// <summary>
        /// Finding the most popular and unpopular ingredients
        /// </summary>
        /// <param name="dimension">if TRUE - find maximum (popular), else - fimd minimum (unpopular)</param>
        /// <returns>Dictionary where string - ingredient name, int - number of matches</returns>
        public static IDictionary<string, int> GetMostPopularIngredients(bool dimension)
        {
            var result = new Dictionary<string, int>();
            var completedOrders = GetCompletedOrders();
            var completedIngredientList = new List<Ingredient>();
            if (completedOrders != null)
            {
                foreach (var item in completedOrders)
                {
                    foreach (var ord in item.OrderList)
                    {
                        foreach (var ing in ord.Ingredients)
                        {
                            completedIngredientList.Add(ing);
                        }
                    }
                }

                completedIngredientList.ToList().Sort();

                var resultCollection = completedIngredientList.GroupBy(Name => Name);

                if (!dimension)
                    resultCollection.Reverse();

                completedIngredientList.Distinct().Count();

                int index = 0;
                foreach (var item in resultCollection)
                {
                    if(index < Constants.IngredientSearchLimit)
                    {
                        result.Add(item.Key.Name, item.Count());
                        index++;
                    }
                }
                return result;
            }
            else return null;

        }


        /// <summary>
        /// View cooking costs for a specified period
        /// </summary>
        /// <param name="beginningDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static IDictionary<string, float> GetOrdersCostByDate(DateTime beginningDate, DateTime endDate)
        {
            var resultDictionary = new List<KeyValuePair<string, float>>();
            var completedOrders = GetCompletedOrders();
            foreach (var type in Enum.GetNames(typeof(FoodTypes)))
            {
                float cost = 0; 

                foreach (var item in completedOrders)
                {
                    var pairs = item.GetCookingCosts();
                    foreach (var pair in pairs)
                    {
                        cost += pair.Value;
                    }
                }
                resultDictionary.Add(new KeyValuePair<string, float> (type.ToString(), cost));
            }
            return (IDictionary<string, float>)resultDictionary;
        }
    }
}
