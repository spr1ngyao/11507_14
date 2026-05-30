using System.Numerics;

namespace OrderChainBuilder;

public class TaxHandler<T> : OrderHandler<T> where T : INumber<T>
{
    private readonly T _taxMultiplier;
    public TaxHandler(T taxMultiplier) => _taxMultiplier = taxMultiplier;

    public override void Process(Order<T> order)
    {
        order.Price *= _taxMultiplier;
        _next?.Process(order);
    }
}