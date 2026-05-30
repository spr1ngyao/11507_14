namespace Events;

public class Sensor
{
    public event Action<string, DateTime> OnAlert;

    public void Trigger(string message)
    {
        OnAlert?.Invoke(message, DateTime.Now);
    }
}