namespace Events;

public class LogAnalyzer
{
    public static void AnalyzeLog<T>(IEnumerable<T> logs, Predicate<T> filter)
    {
        foreach (T log in logs)
        {
            if (filter(log))
            {
                Console.WriteLine(log);
            }
        }
    }
}