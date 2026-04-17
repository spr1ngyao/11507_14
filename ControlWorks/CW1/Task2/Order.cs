namespace Task2;

public class Order
{
    public string Id { get; set; }
    
    private string _status = "New";
    public string Status 
    { 
        get => _status; 
    }
        
    public event EventHandler<OrderEventArgs> StatusChanged;

    public Order(string id)
    {
        Id = id;
    }

    public void UpdateStatus(string nextStatus)
    {
        if (_status == nextStatus) return;

        string oldStatus = _status;
        _status = nextStatus;

        OnStatusChanged(oldStatus, nextStatus);
    }

    protected virtual void OnStatusChanged(string oldStatus, string newStatus)
    {
        if (StatusChanged != null)
        {
            StatusChanged(this, new OrderEventArgs
            {
                OldStatus = oldStatus,
                NewStatus = newStatus
            });
        }
    }
}