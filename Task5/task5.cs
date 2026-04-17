using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Enter file path: ");
        string inputFile = Console.ReadLine();

        try
        {
            string[] lines = File.ReadAllLines(inputFile);

            int lineCount = lines.Length;
            int wordCount = 0;

            foreach (string line in lines)
            {
                wordCount += CountWords(line);
            }

            // 🔹 Simple path (no complex logic)
            string outputFolder = "Task5";
            Directory.CreateDirectory(outputFolder); // ensure folder exists

            string fileName = Path.GetFileNameWithoutExtension(inputFile);
            string outputFile = Path.Combine(outputFolder, fileName + "_output.txt");

            string result = $"Lines: {lineCount}\nWords: {wordCount}";
            File.WriteAllText(outputFile, result);

            Console.WriteLine($"Lines: {lineCount}");
            Console.WriteLine($"Words: {wordCount}");
        }
         catch (FileNotFoundException)
        {
            Console.WriteLine("Error: File not found.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"I/O Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static int CountWords(string text)
    {
        char[] separators = { ' ', '\n', '\r', '\t', '.', ',', '!', '?' };
        return text.Split(separators, StringSplitOptions.RemoveEmptyEntries).Length;
    }
}