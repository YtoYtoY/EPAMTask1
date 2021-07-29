public static class Exceptions
{
    public static string IngredientDoesNotMeetConditions = "This ingredient does not satisfy the conditions of storage warehouse";
    public static string ClientDoesNotExistException = "There is no client with this number";
    public static string IngredientCountException = "The quantity of the product in stock is less than the specified number";
    public static string IngredientDoesNotExistException = "This ingredient is not in storage";
    public static string FoodDoesNotExistInQueueException = "There is no such dish in the order queue";
    public static string FoodDoseNotExistInKitchenException = "There is no such dish in the kitchen";
    public static string RecipeDoesNotExistException = "The chef doesn't have such a recipe";
    public static string BusyException = "Everyone is busy. No capacity available";
}
