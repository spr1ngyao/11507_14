namespace OrderChainBuilder;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Тест с decimal (обычные покупки) ===");
        var orderDec = OrderBuilder<decimal>.Create()
            .SetId(101)
            .SetBasePrice(500m)
            .Build();

        Console.WriteLine($"До обработки: {orderDec.Price}");
        OrderProcessor.Process(orderDec);
        Console.WriteLine($"После обработки: {orderDec.Price}"); // (500 - 100) * 1.2 = 480
        Console.WriteLine();

        Console.WriteLine("=== Тест с double (научные расчеты) ===");
        var orderDbl = OrderBuilder<double>.Create()
            .SetId(202)
            .SetBasePrice(150.0)
            .Build();

        Console.WriteLine($"До обработки: {orderDbl.Price}");
        OrderProcessor.Process(orderDbl);
        Console.WriteLine($"После обработки: {orderDbl.Price}"); // (150 - 100) * 1.2 = 60
        Console.WriteLine();

        Console.WriteLine("=== Тест валидации (цена уйдёт в минус) ===");
        var orderFail = OrderBuilder<decimal>.Create()
            .SetId(303)
            .SetBasePrice(50m)
            .Build();

        try
        {
            OrderProcessor.Process(orderFail);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Поймано ожидаемое исключение: {ex.Message}");
        }
    }
}