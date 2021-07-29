using Lunchroom.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Manager
{
    /// <summary>
    /// Order class
    /// </summary>
    /// <typeparam name="T">Food recipe</typeparam>
    [Serializable]
    [DataContract]
    public class Order<T> where T : FoodRecipe
    {
        public Order(int number, List<T> food)
        {
            OrderNumber = number;
            OrderList = food;
        }

        /// <summary>
        /// Order creation date
        /// </summary>
        [DataMember]
        public DateTime DateOfBeginning { get; set; }

        /// <summary>
        /// Order closing date
        /// </summary>
        [DataMember]
        public DateTime DateOfEnding { get; set; }

        /// <summary>
        /// Is this order completed?
        /// </summary>
        [DataMember]
        public bool isComplete = false;

        /// <summary>
        /// Order number
        /// </summary>
        [DataMember]
        public int OrderNumber { get; private set; }

        /// <summary>
        /// List of ordered food
        /// </summary>
        [DataMember]
        public List<T> OrderList { get; private set; }


        /// <summary>
        /// Method of adding new food to this order
        /// </summary>
        /// <param name="moreFood">List of ordered food</param>
        public void AddFoodInOrder(List<T> moreFood)
        {
            foreach (var item in moreFood)
            {
                OrderList.Add(item);
            }
        }

        /// <summary>
        /// Order completion confirmation method
        /// </summary>
        public void MakeComplete()
        {
            if (DateOfEnding != null)
                isComplete = true;
        }

        /// <summary>
        /// The method for obtaining the cost of creating an order
        /// </summary>
        /// <returns>Dictionary of food types and costs</returns>
        public IDictionary<string, float> GetCookingCosts()
        {
            var resultDictionary = new List<KeyValuePair<string, float>>();
            float generalCost = 0;
            string type = string.Empty;
            foreach (var item in OrderList)
            {
                generalCost = item.GetCostForRecipe;
                type = item.Type.ToString();
            }
            return (IDictionary<string, float>)resultDictionary;


        }

        public override string ToString()
        {
            return OrderNumber.ToString() + "; "
                + OrderList.ToList().ToString() + "; "
                + "is complete: " + isComplete.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is Order<FoodRecipe> order &&
                OrderNumber == order.OrderNumber &&
                OrderList.Equals(order.OrderList);
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(OrderNumber);
            hash.Add(OrderList);
            return hash.ToHashCode();
        }

    }
}
