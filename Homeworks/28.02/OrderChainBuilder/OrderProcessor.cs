using System.Numerics;

namespace OrderChainBuilder;

public static class OrderProcessor
{
    public static void Process<T>(Order<T> order) where T : INumber<T>
    {
        // Создаем звенья
        var discount = new DiscountHandler<T>(T.CreateChecked(100));
        var tax = new TaxHandler<T>(T.CreateChecked(1.2));
        var validation = new ValidationHandler<T>();

        // Выстраиваем цепь
        discount.SetNext(tax);
        tax.SetNext(validation);

        // Запускаем обработку с первого звена
        discount.Process(order);
    }
}