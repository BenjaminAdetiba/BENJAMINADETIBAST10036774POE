using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Linq;

// Delegate for calorie notifications


// Class representing an ingredient

// Class representing a recipe


// Method to scale the recipe



// Class to manage recipes
public class RecipeManager
{
    public static string input;
    private List<Recipe> recipes = new List<Recipe>();
    public event CalorieMessageDelegate CalorieNotificationEvent;

    // Method to add a recipe
    public void GetIngredients()
    {
        Recipe recipe = new Recipe();
        Console.WriteLine("Enter recipe name:");
        recipe.Name = Console.ReadLine();
        while (recipe.Name == "" || recipe.Name == null)
        {
            Console.WriteLine("Please re-enter a valid recipe name");
            recipe.Name = Console.ReadLine().ToLower();
        }

        // Input ingredients
        double quantity;



        //int getlen = Convert.ToInt32(Console.ReadLine());
        bool alen = false;
        int len = 0;
        do
        {
            Console.WriteLine("Enter number of ingredients in the receipe:");
            string getlen = Console.ReadLine();
            if (getlen == string.Empty)
            {
                // handle
            }

            try
            {
                len = Convert.ToInt32(getlen);
                alen = true;

            }
            catch
            {
                Console.WriteLine("Invalid choice, please try again");
            }
        }
        while (!alen);



        for (int i = 0; i < len; i++)
        {
            Console.WriteLine("");


            Ingredient ingredient = new Ingredient();
            Console.WriteLine("Please enter name of ingredient");

            ingredient.Name = Console.ReadLine().ToLower();

            while (ingredient.Name == "" || ingredient.Name == null)
            {
                Console.WriteLine("Please re-enter name of ingredient");
                ingredient.Name = Console.ReadLine().ToLower();
            }
            bool selectValid = false;
            do
            {
                Console.WriteLine($"Please enter the quantity of {ingredient.Name}\n1. As Unit(Singles)\n2. As per(weight)\nEnter a valid option");

                int select = Convert.ToInt32(Console.ReadLine());

                while (select != 1 && select != 2 || select == null)
                {
                    Console.WriteLine("Invalid choice");
                    Console.WriteLine($"Please enter the quantity of {ingredient.Name}\n1. As Unit(Singles)\n2. As per(weight)\nEnter a valid option");

                    select = Convert.ToInt32(Console.ReadLine());
                }

                switch (select)
                {
                    case 1:
                        Console.WriteLine($"Please enter how much {ingredient.Name} will be needed : ");

                        ingredient.Quantity = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Please enter the unit of measurement: ");

                        ingredient.UOM = Console.ReadLine();

                        if (ingredient.Quantity >= 2 && ingredient.UOM.EndsWith("s"))
                        {
                            Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.UOM} are needed");
                        }
                        else
                        {
                            Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.UOM} of {ingredient.Name} is needed");
                        }
                        selectValid = true;
                        break;

                    case 2:
                        Console.WriteLine($"Please enter the weight of {ingredient.Name} that is needed: ");

                        ingredient.Quantity = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Please enter the unit of measurement: ");

                        ingredient.UOM = Console.ReadLine();

                        if (ingredient.Quantity >= 2 && ingredient.UOM.EndsWith("s"))
                        {
                            Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity}   {ingredient.UOM}  of  {ingredient.Name} are needed");
                        }
                        else if (ingredient.Quantity >= 2)
                        {
                            Console.WriteLine($"{ingredient.Name} : {ingredient.Quantity} {ingredient.UOM} of {ingredient.Name}'s are needed");
                        }
                        else
                        {
                            Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.UOM} of {ingredient.Name} is needed");
                        }
                        selectValid = true;
                        break;

                }
            }
            while (!selectValid);


            while (ingredient.UOM == "" || ingredient.UOM == null)
            {

                Console.WriteLine("Please enter a Unit of Measure:");
                ingredient.UOM = Console.ReadLine();
            }

            Console.WriteLine("Calories:");
            ingredient.Calories = Convert.ToDouble(Console.ReadLine());


            Console.WriteLine($"Please select a food group of the {ingredient.Name}"
                     + "\n1.Protein" +
                     "\n2.Carbohydrates" +
                     "\n3.Fruits" +
                     "\n4.Vegetables" +
                     "\n5.Fats and Oil" +
                     "\n6.Dairy" +
                     "\n7.Grains" +
                     "\n8.Added sugar");
            bool group = false;
            do
            {

                string foodchoice = Console.ReadLine() ?? "";
                if (foodchoice == string.Empty)
                {
                }
                int fchoice = 0;

                try
                {
                    fchoice = Convert.ToInt32(foodchoice);
                }
                catch
                {
                    Console.WriteLine("Invalid choice, try again");

                }
                switch (fchoice)
                {
                    case 1:
                        ingredient.FoodGroup = "Protein";
                        group = true;
                        break;
                    case 2:
                        ingredient.FoodGroup = "Carbohydrates";
                        group = true;
                        break;
                    case 3:
                        ingredient.FoodGroup = "Fruits";
                        group = true;
                        break;
                    case 4:
                        ingredient.FoodGroup = "Vegetables";
                        group = true;
                        break;
                    case 5:
                        ingredient.FoodGroup = "Fats and Oils";
                        group = true;
                        break;
                    case 6:
                        ingredient.FoodGroup = "Sweets and Sugary Foods";
                        group = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
                recipe.Ingredients.Add(ingredient);
            } while (!group);
        }



        // Input steps
        Console.WriteLine("Enter number of steps for the recipe");

        int length = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < length; i++)
        {

            Step step = new Step();
            Console.WriteLine("Step description:");
            step.Description = Console.ReadLine();
            recipe.Steps.Add(step);
        }

        recipes.Add(recipe);
        Console.WriteLine("Recipe Successfully Captured!");


        // Check total calories and raise event if exceeds 300
        recipe.CalculateTotalCalories();
        if (recipe.TotalCalories > 300 && CalorieNotificationEvent != null)
        {
            CalorieNotificationEvent(recipe.Name);
        }
        menu();
    }

    // Method to display all recipes in alphabetical order
    public void DisplayRecipesInOrder()
    {
        List<string> recipeNames = new List<string>();
        foreach (var recipe in recipes)
        {
            recipeNames.Add(recipe.Name);
        }
        recipeNames.Sort();

        if (recipeNames.Count > 0)
        {
            Console.WriteLine("List of Recipes:");
            foreach (var name in recipeNames)
            {
                Console.WriteLine(name);
            }
            menu();
        }
        else
        {
            Console.WriteLine("No receipe has been logged in the system");
            menu();
        }
    }

    // Method to display details of a specific recipe
    public void SearchandDisplay()
    {
        List<string> recipeNames = new List<string>();

        Console.WriteLine("Enter the name of the recipe to display its details:");
        string recipeName = Console.ReadLine();

        Recipe recipe = recipes.Find(r => r.Name == recipeName);
        if (recipe != null || recipes.Count != 0)
        {
            Console.WriteLine($"Recipe Name: {recipe.Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.UOM} {ingredient.Name}");
            }
            Console.WriteLine("Steps:");
            foreach (var step in recipe.Steps)
            {
                Console.WriteLine($"{step.Description}");
            }
            Console.WriteLine($"Total Calories: {recipe.TotalCalories}");
        }
        else
        {
            Console.WriteLine("Recipe not found.");
        }
        menu();
    }
    public void ScaleRecipe()
    {
        Console.WriteLine("Enter the name of the recipe you want to scale:");
        string recipeName = Console.ReadLine();
        Recipe recipe = recipes.Find(r => r.Name == recipeName);
        if (recipe != null)
        {
            Console.WriteLine("Enter the factor you wish to scale your recipe (e.g., 0.5 for half, 2 for double):");
            double scaleFactor = Convert.ToDouble(Console.ReadLine());
            recipe.ScaleRecipe(scaleFactor);
            Console.WriteLine($"Recipe '{recipe.Name}' scaled successfully!");
        }
        else
        {
            Console.WriteLine("Recipe not found.");
        }
        menu();
    }

    // Method to reset the recipe
    public void ResetRecipe()
    {
        SearchandDisplay();
        menu();
    }

    // Method to clear all recipes
    public void ClearRecipes()
    {
        recipes.Clear();
        Console.WriteLine("All recipes cleared!");
        menu();
    }


    public void launch()
    {
        Console.WriteLine("Welcome to Sweet Savoury" + "\nPress 1 to launch menu or anything else to quit");

        int start = Convert.ToInt32(Console.ReadLine());

        if (start == 1)
        {
            RecipeManager r = new RecipeManager();
            r.menu();

        }
        else
        {
            Console.WriteLine("Thank you very much for using Sweet Savoury");
            System.Environment.Exit(0);
        }

    }

    public void menu()
    {
        Console.WriteLine("Welcome to Sweet Savory" +
                "\nPlease choose from 1 of the following" +
            "\n1. Add Recipe" +
            "\n2. Display recipes" +
            "\n3. Scale recipe" +
            "\n4. Reset recipe" +
            "\n5. Clear recipe" +
            "\n6. Exit");
        bool validChoice = false;
        do
        {
            string choice = Console.ReadLine() ?? "";
            if (choice == string.Empty)
            {
                // handle
            }
            int ichoice = 0;
            try
            {
                ichoice = Convert.ToInt32(choice);

            }
            catch
            {
                Console.WriteLine("");
            }




            switch (ichoice)
            {
                case 1:
                    GetIngredients();
                    validChoice = true;
                    break;
                case 2:

                    bool DisplayChoice = false;
                    do
                    {
                        Console.WriteLine("How would you like to display the recipes" +
                            "\n1. Display in Order" +
                            "\n2. Search and Display");

                        int rchoice = Convert.ToInt32(Console.ReadLine());

                        switch (rchoice)
                        {
                            case 1:
                                DisplayRecipesInOrder();
                                DisplayChoice = true;
                                break;
                            case 2:
                                SearchandDisplay();
                                DisplayChoice = true;
                                break;
                            default:
                                Console.WriteLine("Please select a valid choice");
                                break;
                        }
                    } while (!DisplayChoice);

                    validChoice = true;
                    break;
                case 3:
                    ScaleRecipe();
                    validChoice = true;
                    break;
                case 4:
                    ResetRecipe();
                    validChoice = true;
                    break;
                case 5:
                    ClearRecipes();
                    validChoice = true;
                    break;
                default:
                    Console.WriteLine("Invalid Choice, Please try again");
                    break;
            }
        } while (!validChoice);
    }
}


class Program
{
    static void Main(string[] args)
    {
        RecipeManager recipeManager = new RecipeManager();
        recipeManager.CalorieNotificationEvent += RecipeCalorieNotification;
        recipeManager.GetIngredients();
    }

    // Method to handle calorie notifications
    static void RecipeCalorieNotification(string recipeName)
    {
        Console.WriteLine($"Warning: {recipeName} has exceeded 300 calories.");
    }
}


