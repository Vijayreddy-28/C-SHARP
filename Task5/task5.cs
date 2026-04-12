using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputFile = "Task5/sample_data1.csv";   // changed to CSV
        string outputFile = "Task5/output.txt";

        try
        {
            // Read all lines from CSV
            string[] lines = File.ReadAllLines(inputFile);

            int lineCount = lines.Length;
            int wordCount = 0;

            // Process CSV data
            foreach (string line in lines)
            {
                // Split by comma (CSV columns)
                string[] cells = line.Split(',');

                foreach (string cell in cells)
                {
                    wordCount += CountWords(cell);
                }
            }

            // Prepare result
            string result = $"Lines: {lineCount}\nWords: {wordCount}";

            // Write to output file
            File.WriteAllText(outputFile, result);

            Console.WriteLine("CSV Processing complete. Results written to output.txt");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: CSV file not found.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"I/O Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected Error: {ex.Message}");
        }
    }

    static int CountWords(string text)
    {
        char[] separators = { ' ', '\n', '\r', '\t', '.', '!', '?' };

        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        return words.Length;
    }
}