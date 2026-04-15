using System;
using System.Collections.Generic;
using System.Linq;

// Step 1: Entity Interface (for Id)
public interface IEntity
{
    int Id { get; set; }
}

// Step 2: Sample Entity
public class Product : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}

// Step 3: Generic Repository Interface
public interface IRepository<T> where T : class, IEntity
{
    void Add(T item);
    List<T> GetAll();
    T GetById(int id);
    void Update(T item);
    void Delete(int id);
}

// Step 4: Generic Repository Implementation
public class Repository<T> : IRepository<T> where T : class, IEntity
{
    private List<T> _items = new List<T>();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public List<T> GetAll()
    {
        return _items;
    }

    public T GetById(int id)
    {
        return _items.FirstOrDefault(x => x.Id == id);
    }

    public void Update(T item)
    {
        var existing = GetById(item.Id);
        if (existing != null)
        {
            _items.Remove(existing);
            _items.Add(item);
        }
    }

    public void Delete(int id)
    {
        var item = GetById(id);
        if (item != null)
        {
            _items.Remove(item);
        }
    }
}

// Step 5: Console UI
class Program
{
    static void Main()
    {
        IRepository<Product> repo = new Repository<Product>();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n1. Add Product");
            Console.WriteLine("2. View All");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Exit");

            Console.Write("Choose option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Id: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Price: ");
                    double price = double.Parse(Console.ReadLine());

                    repo.Add(new Product { Id = id, Name = name, Price = price });
                    break;

                case "2":
                    var products = repo.GetAll();
                    foreach (var p in products)
                    {
                        Console.WriteLine($"{p.Id} - {p.Name} - {p.Price}");
                    }
                    break;

                case "3":
                    Console.Write("Enter Id to update: ");
                    int uid = int.Parse(Console.ReadLine());

                    Console.Write("Enter new Name: ");
                    string newName = Console.ReadLine();

                    Console.Write("Enter new Price: ");
                    double newPrice = double.Parse(Console.ReadLine());

                    repo.Update(new Product { Id = uid, Name = newName, Price = newPrice });
                    break;

                case "4":
                    Console.Write("Enter Id to delete: ");
                    int did = int.Parse(Console.ReadLine());

                    repo.Delete(did);
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}