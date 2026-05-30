using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Events;

class Program
{
    static void Main(string[] args)
    {
        RunLevel1();
        RunLevel2();
        RunLevel3();
        RunLevel4();
        RunWarehouseSystem();
    }
    
    private static void RunLevel1()
    {
        OrderProcessor processor = new OrderProcessor();
        processor.Log += LogNormal;
        processor.Log += LogRed;
        processor.Process();
    }

    private static void LogNormal(string msg)
    {
        Console.WriteLine(msg);
    }

    private static void LogRed(string msg)
    {
        ConsoleColor old = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(msg);
        Console.ForegroundColor = old;
    }

    private static void RunLevel2()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "Danil", Salary = 60000, Experience = 3 },
            new Employee { Name = "Artem", Salary = 40000, Experience = 6 },
            new Employee { Name = "Emir", Salary = 80000, Experience = 7 }
        };

        List<Employee> highSalary = EmployeeFilter.FilterEmployees(employees, e => e.Salary > 50000);
        foreach (Employee e in highSalary) Console.WriteLine(e.Name + " - Salary: " + e.Salary);

        List<Employee> highExp = EmployeeFilter.FilterEmployees(employees, e => e.Experience > 5);
        foreach (Employee e in highExp) Console.WriteLine(e.Name + " - Exp: " + e.Experience);
    }

    private static void RunLevel3()
    {
        User user = new User { Name = "TestUser" };
        NotificationChain.RunChain(user);
    }

    private static void RunLevel4()
    {
        List<string> names = new List<string> { "Данил", "Артем", "Эмир" };
        names.ForEachWithIndex((name, index) =>
        {
            Console.WriteLine((index + 1) + ". " + name);
        });
    }

    private static void RunWarehouseSystem()
    {
        Sensor sensor = new Sensor();
        Siren siren = new Siren();
        Logger logger = new Logger();

        sensor.OnAlert += siren.HandleAlert;
        sensor.OnAlert += logger.HandleAlert;

        logger.Logs.CollectionChanged += (s, e) =>
        {
            Console.WriteLine("Запись добавлена в БД");
        };

        sensor.Trigger("Движение в зоне А");
        sensor.Trigger("Критично: открыта дверь");

        LogAnalyzer.AnalyzeLog(logger.Logs, log => log.ToString().Contains("Критично"));
    }
}