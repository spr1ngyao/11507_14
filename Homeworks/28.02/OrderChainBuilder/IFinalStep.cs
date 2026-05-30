using System.Numerics;

namespace OrderChainBuilder;

public interface IFinalStep<T> where T : INumber<T>
{
    Order<T> Build();
}