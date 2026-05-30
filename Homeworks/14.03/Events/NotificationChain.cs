using System;

namespace Events;

public static class NotificationChain
{
    public static void SendEmail(User user)
    {
        Console.WriteLine("Email sent: " + user.Name);
    }

    public static void SaveToDb(User user)
    {
        Console.WriteLine("DB save: " + user.Name);
        throw new Exception("DB error");
    }

    public static void UpdateStats(User user)
    {
        Console.WriteLine("Stats updated: " + user.Name);
    }

    public static void RunChain(User user)
    {
        Action<User> chain = SendEmail;
        chain += SaveToDb;
        chain += UpdateStats;

        Delegate[] handlers = chain.GetInvocationList();
        foreach (Action<User> handler in handlers)
        {
            try
            {
                handler(user);
            }
            catch
            {
            }
        }
    }
}