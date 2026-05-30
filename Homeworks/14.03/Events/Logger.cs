using System.Collections.ObjectModel;


namespace Events;

public class Logger
{
    public ObservableCollection<string> Logs { get; } = new ObservableCollection<string>();

    public void HandleAlert(string message, DateTime time)
    {
        Logs.Add(message + " | " + time);
    }
}