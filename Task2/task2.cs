using System;

class Person
{
    // Properties
    public string Name { get; set; }
    public int Age { get; set; }

    // Method
    public void Introduce()
    {
        Console.WriteLine($"Hi, my name is {Name} and I am {Age} years old.");
    }
}

class Program
{
    static void Main()
    {
        // Creating objects
        Person person1 = new Person();
        person1.Name = "Alice";
        person1.Age = 25;

        Person person2 = new Person();
        person2.Name = "Bob";
        person2.Age = 30;

        Person person3 = new Person();
        person3.Name = "Charlie";
        person3.Age = 20;

        // Calling method
        person1.Introduce();
        person2.Introduce();
        person3.Introduce();
    }
}