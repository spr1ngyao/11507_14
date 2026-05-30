using System.Numerics;

namespace OrderChainBuilder;

public interface IIdStep<T> where T : INumber<T>
{
    IPriceStep<T> SetId(int id);
}