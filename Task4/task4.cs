using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public int Grade { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        // Create and populate list
        List<Student> students = new List<Student>
        {
            new Student { Name = "Alice", Grade = 85, Age = 20 },
            new Student { Name = "Bob", Grade = 72, Age = 21 },
            new Student { Name = "Charlie", Grade = 90, Age = 19 },
            new Student { Name = "David", Grade = 65, Age = 22 },
            new Student { Name = "Eve", Grade = 88, Age = 20 }
        };

        Console.Write("Enter minimum grade: ");
        int threshold = int.Parse(Console.ReadLine());

        // LINQ: Filter + Sort
        var filteredStudents = students
            .Where(s => s.Grade > threshold)   // Filter
            .OrderBy(s => s.Name);             // Sort by Name

        // Display results
        Console.WriteLine("\n--- Filtered & Sorted Students ---");

        foreach (var student in filteredStudents)
        {
            Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}, Age: {student.Age}");
        }
    }
}