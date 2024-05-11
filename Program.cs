using System.Collections.Generic;
using static MainCLass;
internal class MainCLass
{

    private static Dictionary<string, Recipe> recipes;


    public delegate void NumberHandler(int number);

    public class Caloriechecker
    {
        public event NumberHandler NumberEvent;

        public void checknumber(int number)
        {
            if (NumberEvent != null)
            {
                NumberEvent(number);
            }
        }
    }

    static void Checkcalorie(int number)
    {
        if (number > 300)
        {
            Console.WriteLine("The total calories if this receipe exceeds 300");
        }
        else
        {
            Console.WriteLine("Calories ae within normal range");
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
                    Console.WriteLine($"Please enter how many {name} are needed: ");

                    Qty = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Please enter the unit of measurement: ");

                    UoM = Console.ReadLine();

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
                    Console.WriteLine($"Please enter the weight of {name} needed: ");
                    if (!double.TryParse(Console.ReadLine(), out Qty))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid weight.");
                        Console.ResetColor();
                        continue; // Restart the loop to prompt for input again
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

            //totalCalories = 0 + calories;

            bool group = false;
            do
            {

                Console.WriteLine($"Please select a food group of the {name}"
                    + "\n1.Protein" +
                    "\n2.Carbohydrates" +
                    "\n3.Fruits" +
                    "\n4.Vegetables" +
                    "\n5.Fats and Oil" +
                    "\n6.Dairy" +
                    "\n7.Grains" +
                    "\n8.Added sugar");


                foodchoice = Convert.ToInt32(Console.ReadLine());

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
                        FoodGroup = "Fats and Oils";
                        group = true;
                        break;
                    case 7:
                        FoodGroup = "Sweets and Sugary Foods";
                        group = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }

            }

            while (group == false);


            totalIngredients.Add(new Ingredient(name, UoM, Qty, calories, FoodGroup));



            //Caloriechecker c = new Caloriechecker();

            //  c.checknumber(totalCalories);

            Console.WriteLine("Please enter the amount of steps: ");

            int stepCount = Convert.ToInt32(Console.ReadLine());

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

        }

        menu();

    }



    public static void ScaleReceipe()
    {
        int j = 1;

        if (recipes.Count >= 1)
        {
            foreach (var key in recipes.Keys)
            {
                Console.WriteLine($"Recipe {j}, {key.ToString()}");
                j++;
            }
            Console.WriteLine("Please enter the name of the recipe you would like to modify");

            string search = Console.ReadLine().ToLower();

            if (recipes.ContainsKey(search))
            {
                Console.WriteLine("Recipe found");
                foreach (var key in recipes.Keys)
                {
                    Console.WriteLine($"Recipe {key.ToString()}");
                    j++;
                }
            }
            else
            {
                Console.WriteLine("No match found in the system");
            }

            menu();
        }
        else
        {
            Console.WriteLine("No recipes have been stored");
            menu();
        }
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
                    //  clearReceipe();
                    validChoice = true;
                    break;
                case 5:
                // StoredReceipes();
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
