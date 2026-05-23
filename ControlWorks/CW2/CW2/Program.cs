using System;
using System.Collections.Generic;

class Test
{
    [Trimmed]
    public string Name { get; set; }

    [Trimmed]
    public string Description { get; set; }

    public int Id { get; set; }
}

class Program
{
    static void Main()
    {
        List<object> items = new List<object>();

        items.Add(new Test
        {
            Name = "Andrew",
            Description = "Developer",
            Id = 1
        });

        items.Add(new Test
        {
            Name = "Daniel",
            Description = "Designer",
            Id = 2
        });
        
        items.Add(new Test
        {
            Name = "Emir",
            Description = "Developer",
            Id = 3
        });

        ParallelProcessor processor = new ParallelProcessor();
        processor.Process(items);

        Console.WriteLine();
        Console.WriteLine("After transformation: ");
        foreach (Test entity in items)
        {
            Console.WriteLine($"Name: '{entity.Name}', Description: '{entity.Description}', Id: {entity.Id}");
        }
    }
}