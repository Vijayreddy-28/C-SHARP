using System;
using System.Threading.Tasks;
using System.Collections.Generic;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Starting async operations...\n");

        try
        {
            // Start multiple async tasks concurrently
            Task<string> task1 = FetchDataFromSource("Source 1", 2000);
            Task<string> task2 = FetchDataFromSource("Source 2", 3000);
            Task<string> task3 = FetchDataFromSource("Source 3", 1500);

            // Wait for all tasks to complete
            string[] results = await Task.WhenAll(task1, task2, task3);

            // Aggregate results
            Console.WriteLine("\n--- Results ---");
            foreach (string result in results)
            {
                Console.WriteLine(result);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
        }

        Console.WriteLine("\nAll operations completed.");
    }

    // Simulated async method (like API call)
    static async Task<string> FetchDataFromSource(string sourceName, int delay)
    {
        Console.WriteLine($"{sourceName} started...");

        // Simulate delay (like network/API call)
        await Task.Delay(delay);

        // Simulate an error for demonstration
        if (sourceName == "Source 2")
        {
            throw new Exception($"{sourceName} failed!");
        }

        Console.WriteLine($"{sourceName} completed.");

        return $"{sourceName}: Data fetched successfully";
    }
} 