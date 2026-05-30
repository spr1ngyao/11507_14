using System.Numerics;

namespace OrderChainBuilder;

public class DiscountHandler<T> : OrderHandler<T> where T : INumber<T>
{
    private readonly T _discountAmount;
    public DiscountHandler(T discountAmount) => _discountAmount = discountAmount;

    public override void Process(Order<T> order)
    {
        order.Price -= _discountAmount;
        _next?.Process(order);
    }
}