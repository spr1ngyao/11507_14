using System.Numerics;

namespace OrderChainBuilder;

public class OrderBuilder<T> : IIdStep<T>, IPriceStep<T>, IFinalStep<T> where T : INumber<T>
{
    private int _id;
    private T _price;
    
    public static IIdStep<T> Create() => new OrderBuilder<T>();

    public IPriceStep<T> SetId(int id)
    {
        _id = id;
        return this;
    }

    public IFinalStep<T> SetBasePrice(T price)
    {
        _price = price;
        return this;
    }

    public Order<T> Build()
    {
        return new Order<T> { Id = _id, Price = _price };
    }
}