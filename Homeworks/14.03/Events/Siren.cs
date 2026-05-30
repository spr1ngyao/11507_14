namespace Events;

public class Siren
{
    public void HandleAlert(string message, DateTime time)
    {
        Console.WriteLine("ВКЛЮЧЕНА СИРЕНА: " + message);
    }
}