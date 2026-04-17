using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> items = new List<string>();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Remove Item");
            Console.WriteLine("3. Display Items");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine().Trim();

            switch (choice)
            {
                case "1":
                    AddItem(items);
                    break;

                case "2":
                    RemoveItem(items);
                    break;

                case "3":
                    DisplayItems(items);
                    break;

                case "4":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }

    static void AddItem(List<string> items)
    {
        Console.Write("Enter item to add: ");
        string input = Console.ReadLine().Trim();

        if (!string.IsNullOrEmpty(input))
        {
            input = input.ToUpper(); // Convert to uppercase
            items.Add(input);
            Console.WriteLine("Item added!");
        }
        else
        {
            Console.WriteLine("Empty input not allowed.");
        }
    }

    static void RemoveItem(List<string> items)
    {
        Console.Write("Enter item to remove: ");
        string input = Console.ReadLine().Trim().ToUpper();

        if (items.Remove(input))
        {
            Console.WriteLine("Item removed!");
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }

    static void DisplayItems(List<string> items)
    {
        Console.WriteLine("\n--- ITEMS ---");

        if (items.Count == 0)
        {
            Console.WriteLine("No items in the list.");
            return;
        }

        int index = 1;
        foreach (string item in items)
        {
            Console.WriteLine($"{index}. {item}");
            index++;
        }
    }
}