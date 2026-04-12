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

        Console.WriteLine($"Current Count: {_count}");

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
        Counter counter = new Counter(5);

        // Step 4: Subscribe event handlers
        counter.ThresholdReached += Alert;
        counter.ThresholdReached += Log;
        counter.ThresholdReached += Congratulate;

        // Step 5: Main loop
        for (int i = 0; i < 10; i++)
        {
            counter.Increment();
            System.Threading.Thread.Sleep(500);
        }
    }

    // Event Handlers (Consumers)

    static void Alert(int value)
    {
        Console.WriteLine($"[ALERT] Threshold reached at {value}!");
    }

    static void Log(int value)
    {
        Console.WriteLine($"[LOG] Counter hit value: {value}");
    }

    static void Congratulate(int value)
    {
        Console.WriteLine($"🎉 Congratulations! You reached {value}!");
    }
}