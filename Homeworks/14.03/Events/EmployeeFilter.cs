using System;
using System.Collections.Generic;

namespace Events;

public static class EmployeeFilter
{
    public static List<Employee> FilterEmployees(List<Employee> employees, Predicate<Employee> predicate)
    {
        List<Employee> result = new List<Employee>();
        foreach (Employee emp in employees)
        {
            if (predicate(emp))
            {
                result.Add(emp);
            }
        }
        return result;
    }
}