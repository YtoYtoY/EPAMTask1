using System;
using Lunchroom.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lunchroom.Tests
{
    [TestClass]
    public class Products_Test
    {
        [TestMethod]
        public void Types_TestMethod()
        {
            Lunchroom<FoodRecipe, Ingredient>.GeneratePMTypes();
            int count = Lunchroom<FoodRecipe, Ingredient>.currentMethods.Count;
            Assert.AreEqual(40, count);
        }
    }
}
