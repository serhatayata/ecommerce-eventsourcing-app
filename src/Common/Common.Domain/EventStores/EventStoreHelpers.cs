using System.Reflection;

namespace Common.Domain.EventStores;

public static class ReflectionInvoker
{
    public static object InvokeIfExists<T>(this T item, string methodName, object param)
    {
        var methods = item.GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        var method = item.GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(m =>
                {
                    var parameters = m.GetParameters();

                    return
                    m.Name == methodName
                    && parameters.Length == 1
                    && parameters.Single()?.ParameterType == param.GetType();
                })
                .SingleOrDefault();

        return method?.Invoke(item, new[] { param });
    }

    public static void SetIfExists<T>(this T item, string propertyName, object value)
    {
        item.GetType()
            .GetProperty(propertyName)?
            .SetValue(item, value);
    }
}