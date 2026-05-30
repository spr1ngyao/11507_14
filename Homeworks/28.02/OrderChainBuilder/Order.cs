using System.Numerics;

namespace OrderChainBuilder;

public class Order<T> where T : INumber<T>
{
    public int Id { get; set; }
    public T Price { get; set; }
}