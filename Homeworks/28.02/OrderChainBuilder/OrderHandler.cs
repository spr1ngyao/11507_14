using System.Numerics;

namespace OrderChainBuilder;

public abstract class OrderHandler<T> where T : INumber<T>
{
    protected OrderHandler<T>? _next;

    public void SetNext(OrderHandler<T> next) => _next = next;
    public abstract void Process(Order<T> order);
}