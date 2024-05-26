using System;
using System.Collections.Generic;

public delegate void CalorieMessageDelegate(string recipeName);


public class Ingredient
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string UOM { get; set; }
    public double Calories { get; set; }
    public string FoodGroup { get; set; }
}

public class Step
{
    public string Description { get; set; }
}


public class Recipe
{
    public string Name { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public List<Step> Steps { get; set; }
    public double TotalCalories { get; private set; }

    // Constructor
    public Recipe()
    {
        Ingredients = new List<Ingredient>();
        Steps = new List<Step>();
    }

    // Calculate total calories for the recipe
    public void CalculateTotalCalories()
    {
        TotalCalories = 0;
        foreach (var ingredient in Ingredients)
        {
            TotalCalories += ingredient.Calories;
        }
    }

    public void ScaleRecipe(double scaleFactor)
    {
        foreach (var ingredient in Ingredients)
        {
            ingredient.Quantity *= scaleFactor;
            // Update calories after scaling quantity
            ingredient.Calories *= scaleFactor;
        }

        // Recalculate total calories after scaling
        CalculateTotalCalories();
    }

}