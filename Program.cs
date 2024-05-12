using System;
using System.Collections.Generic;
using System.Xml.Linq;
using static MainCLass;
internal class MainCLass
{

    public static Dictionary<string, Recipe> recipes;

    public static double factor;
    public static int stepCount;
    public delegate void NumberHandler(int number);

    public class Caloriechecker
    {
        public event NumberHandler NumberEvent;

        public void checknumber(int number)
        {
            NumberEvent?.Invoke(number);
        }


        public void Checkcalorie(int number)
        {
            if (number > 300)
            {
                Console.WriteLine("This receipe exceeds 300 calories");
            }
            else
            {
                Console.WriteLine("Calories ae within normal range");
            }
        }
    }

    public static void GetIngredients()
    {
        string rName = default;
        string name = default;
        string UoM = default;
        double Qty = default;
        int totalCalories = 0;
        string FoodGroup = "";
        int foodchoice = 0;
        int calories;
        string calories1;
        string num1;
        int num;
        int select;

        List<Ingredient> totalIngredients = new List<Ingredient>();

        Console.WriteLine("Enter the name of the Recipe: ", "Please enter a valid Recipe name!");
        rName = Console.ReadLine().ToLower();

        while (rName == "" || rName == null)
        {
            Console.WriteLine("Please re-enter a valid recipe name");
            rName = Console.ReadLine().ToLower();
        }

        while (true)
        {
            Console.WriteLine("Hey, how many ingredients would you like to store?: ");

            num1 = Console.ReadLine();
            try
            {
                num = Convert.ToInt32(num1);
                break;
            }
            catch (Exception e)
            {

                Console.WriteLine("Please try again, Enter the number of ingredients");

            }
        }


        for (int i = 0; i < num; i++)
        {
            Console.WriteLine("Please enter the Name of ingredient: ");

            name = Console.ReadLine();

            while (name == "" || name == null)
            {
                Console.WriteLine("Please re-enter a valid recipe name");
                name = Console.ReadLine().ToLower();
            }



            while (true)
            {
                Console.WriteLine($"Please enter the quantity of {name}\n1. As Unit(Singles)\n2. As per(weight)\nEnter a valid option");


                string select1 = Console.ReadLine();
                try
                {
                    select = Convert.ToInt32(select1);
                    break;
                }
                catch (Exception e)
                {

                    Console.WriteLine($"Please enter the quantity of {name}\n1. As Unit(Singles)\n2. As per(weight)\nEnter a valid option");


                }
            }


            switch (select)
            {
                case 1:

                    while (true)
                    {
                        Console.WriteLine($"Please enter how many {name} are needed: ");

                        string Qty1 = Console.ReadLine();

                        try
                        {
                            Qty = Convert.ToInt32(Qty1);
                            break;
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine("Please try again, Enter the number of ingredients");

                        }
                    }
                    ///////////////////////////
                    Console.WriteLine("Please enter the unit of measurement: ");

                    UoM = Console.ReadLine();
                    while (UoM == "" || UoM == null)
                    {
                        Console.WriteLine("Please re-enter a valid recipe name");
                        UoM = Console.ReadLine().ToLower();
                    }

                    if (Qty >= 2 && UoM.EndsWith("s"))
                    {
                        Console.WriteLine($"{name}: {Qty} {UoM} are needed");
                    }
                    else
                    {
                        Console.WriteLine($"{name}: {Qty} {UoM} of {name} is needed");
                    }
                    // selectValid = true;
                    break;

                case 2:
                    //   Console.WriteLine($"Please enter the weight of {name} needed: ");
                    while (true)
                    {
                        Console.WriteLine($"Please enter the weight of {name}  needed: ");

                        string Qty1 = Console.ReadLine();

                        try
                        {
                            Qty = Convert.ToInt32(Qty1);
                            break;
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine("Please try again, Enter the number of ingredients");

                        }
                    }


                    Console.WriteLine("Please enter the unit of measurement: ");
                    UoM = Console.ReadLine();

                    if (Qty >= 2 && UoM.EndsWith("s"))
                    {
                        Console.WriteLine($"{name}: {Qty} {UoM} of {name} are needed");
                    }
                    else if (Qty >= 2)
                    {
                        Console.WriteLine($"{name} : {Qty} {UoM} of {name}'s are needed");
                    }
                    else
                    {
                        Console.WriteLine($"{name}: {Qty} {UoM} of {name} is needed");
                    }
                    // selectValid = true;
                    break;
            }


            while (true)
            {
                Console.WriteLine($"Please enter the number of calories of the {name}");


                calories1 = Console.ReadLine();
                try
                {
                    calories = Convert.ToInt32(calories1);
                    break;
                }
                catch (Exception e)
                {

                    Console.WriteLine("Please try again, Enter the number of ingredients");

                }
            }

            totalCalories = 0 + calories;
            bool group = false;
            do
            {
                Console.WriteLine($"Please select a food group:"
                    + "\n1.Protein" +
                    "\n2.Carbohydrates" +
                    "\n3.Fruits" +
                    "\n4.Vegetables" +
                    "\n5.Fats and Oil" +
                    "\n6.Dairy" +
                    "\n7.Grains" +
                    "\n8.Added sugar");


                string foodchoice1 = Console.ReadLine();

                try
                {
                    foodchoice = Convert.ToInt32(foodchoice1);
                    switch (foodchoice)
                    {
                        case 1:
                            FoodGroup = "Protein";
                            group = true;
                            break;
                        case 2:
                            FoodGroup = "Carbohydrates";
                            group = true;
                            break;
                        case 3:
                            FoodGroup = "Fruits";
                            group = true;
                            break;
                        case 4:
                            FoodGroup = "Vegetables";
                            group = true;
                            break;
                        case 5:
                            FoodGroup = "Fats and Oils";
                            group = true;
                            break;
                        case 6:
                            FoodGroup = "Dairy";
                            group = true;
                            break;
                        case 7:
                            FoodGroup = "Grains";
                            group = true;
                            break;
                        case 8:
                            FoodGroup = "Added sugar";
                            group = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine("Please try again, Please select a valid choice");
                }
            }
            while (group == false);


            totalIngredients.Add(new Ingredient(name, UoM, Qty, calories, FoodGroup));




            Caloriechecker c = new Caloriechecker();

            c.checknumber(totalCalories);

            c.NumberEvent += c.Checkcalorie;


            c.checknumber(totalCalories);


            Console.WriteLine("Please enter the amount of steps: ");



            while (true)
            {
                Console.WriteLine("Please enter the amount of stepsa ");
                string step1 = Console.ReadLine();
                try
                {
                    stepCount = Convert.ToInt32(step1);
                    break;
                }
                catch (Exception e)
                {

                    Console.WriteLine("Please try again, Enter the number of steps");

                }
            }


            List<string> steps = new List<string>();
            for (int j = 0; j < stepCount; j++)
            {
                Console.WriteLine($"Please enter a instruction for Step {j + 1}");
                string step = Console.ReadLine();
                steps.Add(step);
            }

            Recipe newRecipe = new Recipe(rName, totalIngredients, steps);
            recipes.Add(rName, newRecipe);
            Console.WriteLine("The recipe has successfully been stored");


            Console.WriteLine($"Receipe: {rName}");

            foreach (var j in recipes)
            {
                Console.WriteLine(j.ToString().Replace("[", "").Replace("]", ""));
                Console.WriteLine("");
            }


            menu();

        }
    }



    public static void ScaleReceipe(Recipe recipe)
    {
        int j = 1;
        //  var sortedDict = recipes.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
        var sortedList = recipes.OrderBy(kvp => kvp.Key).ToList();

        foreach (var i in sortedList)
        {
            Console.WriteLine(j + $"\n{i}");
            j++;
        }

        Console.WriteLine("Please Enter the name of the recipe you wish to scale");

        string find = Console.ReadLine();

        if (recipes.ContainsKey(find))
        {
            Recipe recipe1 = recipes[find];
            Console.WriteLine(recipe);

            while (true)
            {
                Console.WriteLine("Please enter the scale of the recipe ");
                string factor1 = Console.ReadLine();
                try
                {
                    factor = Convert.ToDouble(factor1);
                    break;
                }
                catch (Exception e)
                {

                    Console.WriteLine("Please try again, Enter a valid scale factor");
                }
            }

            foreach (var ingredient in recipe.ingredients)
            {
                ingredient.Quantity *= factor;
            }

            Console.WriteLine(recipe);
        }
        else
        {
            Console.WriteLine("The recipe you are looking for does not exist");
        }



        menu();


        // double factor = Convert.ToDouble(Console.ReadLine());



    }

    public static void printRecipe()
    {
        Console.WriteLine(
            "Please choose from the following options:" +
            "\n1. Print in alphabetical order" +
            "\n2. Search and display");

        int option = Convert.ToInt32(Console.ReadLine());
        bool order = false;

        do
        {
            if (option == 1)
            {
                var sortedList = recipes.OrderBy(kvp => kvp.Key).ToList();

                Console.WriteLine("Recipes in alphabetical order:");
                foreach (var recipe in sortedList)
                {
                    Console.WriteLine($"{recipe.Key}: {recipe.Value}");
                }

                order = true;
                break;
            }
            else if (option == 2)
            {
                Console.WriteLine("Please enter the name of the recipe:");
                string find = Console.ReadLine();

                if (recipes.ContainsKey(find))
                {
                    Console.WriteLine($"{find}: {recipes[find]}");
                }
                else
                {
                    Console.WriteLine("The recipe does not exist");
                }

                order = true;
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Please choose again.");
                option = Convert.ToInt32(Console.ReadLine());
            }
        } while (!order);
    }



    public static void menu()
    {
        Console.WriteLine
                ("Welcome to Sweet Savory" +
                "\nPlease choose from 1 of the following" +
                "\n1.Store Receipe" +
                "\n2.Scale Receipe" +
                "\n3.Reset Receipe" +
                "\n4.Clear Receipe" +
                "\n5.Print Receipe"
            );

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
                    ScaleReceipe();
                    validChoice = true;
                    break;
                case 3:
                    //   resetReceipe();
                    validChoice = true;
                    break;
                case 4:
                    //   clearReceipe();
                    validChoice = true;
                    break;
                case 5:
                    printRecipe();
                    break;
                default:
                    Console.WriteLine("Invalid Choice, Please try again");
                    break;
            }
        } while (!validChoice);
    }


    public static void launch()
    {
        Console.WriteLine("Welcome to Sweet Savoury" + "\nPress 1 to launch menu or anything else to quit");

        int start = Convert.ToInt32(Console.ReadLine());

        if (start == 1)
        {
            menu();
        }
        else
        {
            Console.WriteLine("Thank you very much for using Sweet Savoury");
            System.Environment.Exit(0);
        }

    }


    class Program
    {
        static void Main(string[] args)
        {


            recipes = new Dictionary<string, Recipe>();

            // launch();

            GetIngredients();
        }
    }
}
