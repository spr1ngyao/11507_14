using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ParallelProcessor
{
    private DataTransformer transformer = new DataTransformer();
    private object locker = new object();

    public void Process(List<object> items)
    {
        Parallel.ForEach(items, new ParallelOptions { MaxDegreeOfParallelism = 4 }, item =>
        {
            lock (locker)
            {
                transformer.Transform(item);
            }

            Console.WriteLine(item.GetType().Name);
        });
    }
}