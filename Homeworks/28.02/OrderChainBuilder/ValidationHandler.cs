using System.Numerics;

namespace OrderChainBuilder;

public class ValidationHandler<T> : OrderHandler<T> where T : INumber<T>
{
    public override void Process(Order<T> order)
    {
        if (order.Price < T.Zero)
        {
            throw new InvalidOperationException(
                $"Ошибка валидации: цена заказа №{order.Id} стала отрицательной ({order.Price}).");
        }
        _next?.Process(order);
    }
}