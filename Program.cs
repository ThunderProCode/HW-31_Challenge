using System;

// Enumerations for potion and ingredient types
enum PotionType
{
    Water,
    Elixir,
    Poison,
    Flying,
    Invisibility,
    NightSight,
    CloudyBrew,
    Wraith,
    Ruined
}

enum IngredientType
{
    None,
    Stardust,
    SnakeVenom,
    DragonBreath,
    ShadowGlass,
    EyeshineGem
}

public class Program
{
    static void Main()
    {
        PotionType currentPotion = PotionType.Water;

        while (true)
        {
            Console.WriteLine("Current Potion Type: " + currentPotion);

            if (currentPotion == PotionType.Ruined)
            {
                Console.WriteLine("Ruined potion. Starting over with water.");
                currentPotion = PotionType.Water;
            }

            if (currentPotion == PotionType.Wraith)
            {
                Console.WriteLine("Congratulations! You've created a Wraith Potion!");
                break;
            }

            Console.WriteLine("Ingredient Choices: ");
            Console.WriteLine("1. Stardust");
            Console.WriteLine("2. Snake Venom");
            Console.WriteLine("3. Dragon Breath");
            Console.WriteLine("4. Shadow Glass");
            Console.WriteLine("5. Eyeshine Gem");
            Console.WriteLine("6. Complete Potion");
            Console.Write("Enter your choice (1-6): ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        currentPotion = AddIngredient(currentPotion, IngredientType.Stardust);
                        break;
                    case 2:
                        currentPotion = AddIngredient(currentPotion, IngredientType.SnakeVenom);
                        break;
                    case 3:
                        currentPotion = AddIngredient(currentPotion, IngredientType.DragonBreath);
                        break;
                    case 4:
                        currentPotion = AddIngredient(currentPotion, IngredientType.ShadowGlass);
                        break;
                    case 5:
                        currentPotion = AddIngredient(currentPotion, IngredientType.EyeshineGem);
                        break;
                    case 6:
                        Console.WriteLine("You've decided to complete the potion.");
                        currentPotion = PotionType.Wraith;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
            }

            Console.WriteLine();
        }
    }

    // Method to add an ingredient to the current potion
    static PotionType AddIngredient(PotionType currentPotion, IngredientType ingredient)
    {
        switch (currentPotion)
        {
            case PotionType.Water:
                return ingredient == IngredientType.Stardust ? PotionType.Elixir : PotionType.Ruined;
            case PotionType.Elixir:
                switch (ingredient)
                {
                    case IngredientType.SnakeVenom:
                        return PotionType.Poison;
                    case IngredientType.DragonBreath:
                        return PotionType.Flying;
                    case IngredientType.ShadowGlass:
                        return PotionType.Invisibility;
                    case IngredientType.EyeshineGem:
                        return PotionType.NightSight;
                    default:
                        return PotionType.Ruined;
                }
            case PotionType.NightSight:
                return ingredient == IngredientType.ShadowGlass ? PotionType.CloudyBrew : PotionType.Ruined;
            case PotionType.Invisibility:
                return ingredient == IngredientType.EyeshineGem ? PotionType.CloudyBrew : PotionType.Ruined;
            case PotionType.CloudyBrew:
                return ingredient == IngredientType.Stardust ? PotionType.Wraith : PotionType.Ruined;
            default:
                return PotionType.Ruined;
        }
    }
}
