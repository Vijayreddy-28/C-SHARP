using System;

// Step 1: Define delegate
public delegate void ThresholdReachedHandler(int value);

// Step 2: Counter class (Event Producer)
class Counter
{
    private int _count = 0;
    private int _threshold;

    // Step 3: Define event
    public event ThresholdReachedHandler ThresholdReached;

    public Counter(int threshold)
    {
        _threshold = threshold;
    }

    public void Increment()
    {
        _count++;

        Console.WriteLine($"Current temperature: {_count}");

        // Raise event when threshold reached
        if (_count == _threshold)
        {
            OnThresholdReached(_count);
        }
    }

    // Method to raise event
    protected virtual void OnThresholdReached(int value)
    {
        ThresholdReached?.Invoke(value);
    }
}

class Program
{
    static void Main()
    {    
        Console.Write("Enter temperature threshold: ");
        int threshold = int.Parse(Console.ReadLine());

        Counter counter = new Counter(threshold);

        // Step 4: Subscribe event handlers
        counter.ThresholdReached += ShowWarning;
        counter.ThresholdReached += ShowTime;
        counter.ThresholdReached += Notify;

        // Step 5: Main loop
        for (int i = 0; i < threshold; i++)
        {
            counter.Increment();
        }
    }


    static void ShowWarning(int value)
    {
    Console.WriteLine($"⚠️ Warning: Temperature reached {value}");
    }

    static void ShowTime(int value)
    {
    Console.WriteLine($"Reached at time: {DateTime.Now:T}");
    }

    static void Notify(int value)
    {
    Console.WriteLine("⚠️ Users, please do not use the machine. Try again after some time.");
    }
}