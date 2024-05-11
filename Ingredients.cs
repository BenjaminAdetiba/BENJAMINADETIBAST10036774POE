using System;
using System.Collections.Generic;

public class Ingredient
{
    public string Name
    {
        get; set;
    }

    public string UoM
    {
        get; set;
    }

    public double Quantity
    {
        get; set;
    }

    public int Calories
    {
        get; set;
    }

    public string FoodGroup
    {
        get; set;
    }

    //   public int totalCalories {
    //     get; set;
    // }

    public Ingredient(string name, string uoM, double quantity, int calories, string foodGroup)
    {
        this.Name = name;
        this.UoM = uoM;
        this.Quantity = quantity;
        this.Calories = calories;
        this.FoodGroup = foodGroup;
        // this.totalCalories = totalCalories;
    }

    public override string ToString()
    {
        return $"{this.Quantity} {this.UoM} of {this.Name} ({this.Calories} Calories) ({this.FoodGroup})";
    }


}


public class Recipe
{
    public string name;
    public List<Ingredient> ingredients = new List<Ingredient>();
    public List<string> steps;

    // public string foodGroup;
    private string rName;
    private List<Ingredient> totalIngredients;



    public Recipe(string rName, List<Ingredient> totalIngredients, List<string> steps)
    {
        this.rName = rName;
        this.totalIngredients = totalIngredients;
        this.steps = steps;

    }



    public override string ToString()
    {
        string asString = $"{name}\n\n---Ingredients---\n";
        for (int i = 0; i != totalIngredients.Count; i++)
        {
            asString += $"{i + 1}: {totalIngredients[i]}\n";
        }
        asString += "\n---Steps---\n";
        for (int i = 0; i < steps.Count; i++)
        {
            asString += $"{i + 1}: {steps[i]}\n";
        }
        return asString;
    }


}
