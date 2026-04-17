namespace Task2;

public class OrderEventArgs : EventArgs
{
    public string OldStatus { get; set; }
    public string NewStatus { get; set; }
}