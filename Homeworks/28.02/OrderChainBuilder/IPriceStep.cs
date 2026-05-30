using System.Numerics;

namespace OrderChainBuilder;

public interface IPriceStep<T> where T : INumber<T>
{
    IFinalStep<T> SetBasePrice(T price);
}