namespace Events;

public class OrderProcessor
{
    public LogHandler Log;

    public void Process()
    {
        Log?.Invoke("Заказ принят");
        Log?.Invoke("Платеж прошел");
    }
}