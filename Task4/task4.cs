using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public int Grade { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();

        Console.Write("Enter number of students: ");
        int count = int.Parse(Console.ReadLine());

        // 🔹 Dynamic input
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\nEnter details for student {i + 1}:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Grade: ");
            int grade = int.Parse(Console.ReadLine());

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Gender: ");
            string gender = Console.ReadLine();

            students.Add(new Student
            {
                Name = name,
                Grade = grade,
                Age = age,
                Gender = gender
            });
        }

        // 🔹 Threshold input
        Console.Write("\nEnter minimum grade (threshold): ");
        int threshold = int.Parse(Console.ReadLine());

        // 🔹 Filter based on threshold
        var filtered = students.Where(s => s.Grade >= threshold);

        // 🔹 Sorting choice
        Console.WriteLine("Sort by: name / grade / age");
        string choice = Console.ReadLine().ToLower();

        IEnumerable<Student> result = filtered;

        if (choice == "name")
        {
            result = filtered.OrderBy(s => s.Name);
        }
        else if (choice == "grade")
        {
            result = filtered.OrderByDescending(s => s.Grade);
        }
        else if (choice == "age")
        {
            result = filtered.OrderBy(s => s.Age);
        }

        // 🔹 Output
        Console.WriteLine("\n--- Filtered & Sorted Students ---");
        foreach (var s in result)
        {
            Console.WriteLine($"{s.Name} | Grade: {s.Grade} | Age: {s.Age} | {s.Gender}");
        }
    }
}