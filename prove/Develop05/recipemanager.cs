using System;
class RecipeManager
{
    private List<Recipe> recipes = new List<Recipe>();
    private const string filePath = "recipes.txt";

    public void AddRecipe()
    {
        Console.Write("Enter Recipe Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Ingredients: ");
        string ingredients = Console.ReadLine();
        Console.Write("Enter Instructions: ");
        string instructions = Console.ReadLine();
        
        Recipe recipe = new Recipe(name, ingredients, instructions);
        recipes.Add(recipe);
        SaveToFile(recipe);
        Console.WriteLine("Recipe added successfully!\n");
    }

    public void ListRecipes()
    {
        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes found.");
            return;
        }
        
        foreach (var recipe in recipes)
        {
            Console.WriteLine(recipe);
        }
    }

    public void SearchRecipe()
    {
        Console.Write("Enter Recipe Name to Search: ");
        string searchName = Console.ReadLine();
        
        foreach (var recipe in recipes)
        {
            if (recipe.Name.ToLower().Contains(searchName.ToLower()))
            {
                Console.WriteLine(recipe);
                return;
            }
        }
        
        Console.WriteLine("Recipe not found.");
    }

    private void SaveToFile(Recipe recipe)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"{recipe.Name}|{recipe.Ingredients}|{recipe.Instructions}");
        }
    }

    public void LoadFromFile()
    {
        if (!File.Exists(filePath)) return;
        
        string[] lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                recipes.Add(new Recipe(parts[0], parts[1], parts[2]));
            }
        }
    }
}
