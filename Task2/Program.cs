using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Person> students = new List<Person>();

        Console.Write("Enter number of students: ");
        int count;
        while (!int.TryParse(Console.ReadLine(), out count))
        {
            Console.Write("Invalid input. Enter a number: ");
        }

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\nEnter details for student {i + 1}:");

            Console.Write("Name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Age: ");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.Write("Invalid age. Enter a number: ");
            }

            Person p = new Person(name, age);
            students.Add(p);
        }

        Console.WriteLine("\n--- Student List ---");
        foreach (var student in students)
        {
            student.Introduce();
        }
    }
}