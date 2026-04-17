using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Processing customer orders...\n");

        try
        {
            Task<string> order1 = ProcessOrder("Order 101", 2000);
            Task<string> order2 = ProcessOrder("Order 102", 3000);
            Task<string> order3 = ProcessOrder("Order 103", 1500);

            string[] results = await Task.WhenAll(order1, order2, order3);

            Console.WriteLine("\n--- Order Results ---");
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\nAll orders processed.");
    }

    static async Task<string> ProcessOrder(string orderId, int delay)
    {
        Console.WriteLine($"{orderId} processing...");

        await Task.Delay(delay); // simulate DB/payment/API call

        // Simulate failure
        if (orderId == "Order 102")
        {
            throw new Exception($"{orderId} payment failed!");
        }

        Console.WriteLine($"{orderId} completed.");

        return $"{orderId}: Successfully processed";
    }
}