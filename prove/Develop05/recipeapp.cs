using System;
class RecipeApp
{
    private RecipeManager manager = new RecipeManager();
    
    public void Run()
    {
        manager.LoadFromFile();
        
        while (true)
        {
            Console.WriteLine("\nRecipe Manager");
            Console.WriteLine("1. Add Recipe");
            Console.WriteLine("2. List Recipes");
            Console.WriteLine("3. Search Recipe");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    manager.AddRecipe();
                    break;
                case "2":
                    manager.ListRecipes();
                    break;
                case "3":
                    manager.SearchRecipe();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
