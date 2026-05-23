using System;
using System.Reflection;

public class DataTransformer
{
    public void Transform(object obj)
    {
        Type type = obj.GetType();
        PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (PropertyInfo property in properties)
        {
            if (property.PropertyType == typeof(string) &&
                property.IsDefined(typeof(TrimmedAttribute), false))
            {
                string value = (string)property.GetValue(obj);
                if (value != null)
                {
                    property.SetValue(obj, value.Trim());
                }
            }
        }
    }
}