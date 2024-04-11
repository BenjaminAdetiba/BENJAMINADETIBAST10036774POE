namespace BENJAMINADETIBAST10036774POE
{
    class MyRecipe
    {

        public string[] name;
        public int[] quantity;
        public string[] uOM;
        public string[] title;
        public Object[] steps;
        public int factor;

        public void storeRecipe()
        {
            int num;
            Console.WriteLine("Please enter the name of the recipe");
            string title = Console.ReadLine();

            Console.WriteLine("Hey, how many ingredients would you like to store?");
            num = Convert.ToInt32(Console.ReadLine());

            quantity = new int[num];
            name = new string[num];
            uOM = new string[num];

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Please enter the name of ingredient");
                name[i] = Console.ReadLine();


                Console.WriteLine("Please enter the quantity of " + name[i] +
                    "\n1. As Unit(Singles) " + "\n2. As per(weight)");

                int select = Convert.ToInt32(Console.ReadLine());

                if (select == 1)
                {

                    Console.WriteLine("Please enter how many " + " " + $"{name[i]}'s" + "are needed");
                    quantity[i] = Convert.ToInt32(Console.ReadLine());
                    if (quantity[i] >= 2)
                    {
                        Console.WriteLine("Please enter the unit of Measurement is");
                        uOM[i] = Console.ReadLine();
                        Console.WriteLine(name[i] + ":" + quantity[i] + " " + uOM[i] + $"{name[i]}'s" + " are needed");
                    }
                    else

                        Console.WriteLine(name[i] + ":" + quantity[i] + " " + uOM[i] + name[i] + " is needed");
                }
                else
                {
                    Console.WriteLine("Please enter the weight of the " + $"{name[i]}" + "" + "needed");
                    quantity[i] = Convert.ToInt32(Console.ReadLine());

                    if (quantity[i] >= 2)
                        Console.WriteLine("Please enter the unit of Measurement is");
                    uOM[i] = Console.ReadLine();
                    Console.WriteLine($"{name[i]}" + ":" + quantity[i] + " " + uOM[i] + " of " + $"{name[i]}s" + " are needed");
                }


            }


            Console.WriteLine("Ingredients for: " + title + " has successfully been stored");

            Console.WriteLine("Please indicate how many steps are in the recipe");
            int length = Convert.ToInt32(Console.ReadLine());

            steps = new string[length];

            for (int i = 0; i < length; i++)
            {
                int stepNumber = i + 1;
                Console.WriteLine("Step " + stepNumber);
                Console.WriteLine("Please enter the description");
                steps[i] = Console.ReadLine();
            }

            Console.WriteLine("Receipe for:" + title);
            Console.WriteLine("Ingredients used:");

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(quantity[i] + " " + uOM[i] + " of " + name[i] + " used");
            }

            Console.WriteLine("Steps:");
            for (int i = 0; i < length; i++)
            {
                int stepNumber = i + 1;
                Console.WriteLine("Step " + stepNumber + ": " + steps[i]);
            }
            menu();

        }

        public void scaleReceipe()
        {

            if (quantity.Length != null)
            {

                Console.WriteLine("Receipe for:" + title);
                Console.WriteLine("Ingredients used:");

                for (int i = 0; i < quantity.Length; i++)
                {
                    Console.WriteLine(quantity[i] + " " + uOM[i] + " of " + name[i] + " used");
                }

                Console.WriteLine("Steps:");
                for (int i = 0; i < quantity.Length; i++)
                {
                    int stepNumber = i + 1;
                    Console.WriteLine("Step " + stepNumber + ": " + steps[i]);
                }

                Console.WriteLine("Please enter the factor you wish to scale your receipe");
                factor = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Scaled Receipe: ");

                for (int i = 0; i < quantity.Length; i++)
                {
                    int answer = factor * quantity[i];
                    Console.WriteLine(answer + " " + uOM[i] + " of " + name[i] + " used");
                }

                Console.WriteLine("Steps:");
                for (int i = 0; i < quantity.Length; i++)
                {
                    int stepNumber = i + 1;
                    Console.WriteLine("Step " + stepNumber + ": " + steps[i]);
                }


            }
            else
            {
                Console.WriteLine("No receipe has been stored");
            }

            menu();

        }
        public void resetReceipe()
        {
            if (quantity.Length != null)
            {
                Console.WriteLine("Scaled Receipe: ");

                for (int i = 0; i < quantity.Length; i++)
                {
                    int answer = factor * quantity[i];
                    Console.WriteLine(answer + " " + uOM[i] + " of " + name[i] + " used");
                }

                Console.WriteLine("Would you like to reset the scale back to 1, Enter 1(Yes) or 2(No)");

                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 1)
                {
                    Console.WriteLine("Receipe for:" + title);
                    for (int i = 0; i < quantity.Length; i++)
                    {

                        Console.WriteLine(quantity[i] + " " + uOM[i] + " of " + name[i] + " used");
                    }


                }
                else

                {
                    Console.WriteLine("Receipe Still unchangesd");
                    for (int i = 0; i < quantity.Length; i++)
                    {
                        int answer = factor * quantity[i];
                        Console.WriteLine(answer + " " + uOM[i] + " of " + name[i] + " used");
                    }

                }
            }
            else
            {
                Console.WriteLine("No receipe has been stored");
            }
            menu();
        }
        public void menu()
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

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    storeRecipe();
                    break;
                case 2:
                    scaleReceipe();
                    break;
                case 3:
                    resetReceipe();
                    break;
                case 4:
                    clearReceipe();
                    break;
            }
        }


        public void clearReceipe()
        {
            Console.WriteLine("Would you like to clear all data entry" +
                "\n1. Yes" + "\n0. No");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                quantity = new int[0];
                name = new string[0];
                uOM = new string[0];
                steps = new object[0];

                Console.WriteLine("All data has been cleared");
                menu();

            }
            else
            {
                Console.WriteLine("Data unchanged");

                Console.WriteLine("Receipe for:" + title);
                for (int i = 0; i < quantity.Length; i++)
                {

                    Console.WriteLine(quantity[i] + " " + uOM[i] + " of " + name[i] + " used");
                }
                Console.WriteLine("");
                Console.WriteLine("Steps:");
                for (int i = 0; i < quantity.Length; i++)
                {
                    int stepNumber = i + 1;
                    Console.WriteLine("Step " + stepNumber + ": " + steps[i]);
                }

            }



        }

        public void launch()
        {
            Console.WriteLine("Welcome to Sweet Savoury" + "\nPress 1 to launch menu or anything else to quit");

            int start = Convert.ToInt32(Console.ReadLine());

            if (start == 1)
            {
                menu();
            }
            else
            {
                System.Environment.Exit(0);
            }

        }
        class Program
        {
            static void Main(string[] args)
            {


                MyRecipe recipe = new MyRecipe();
                recipe.launch();
            }
        }
    }
}
