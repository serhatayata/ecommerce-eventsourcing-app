using Common.Domain.Core.Events;

namespace Common.Domain.MessageBrokers;

public static class MessageBrokersHelper
{
    public static string GetTypeName(Type type)
    {
        var name = type.FullName.ToLower().Replace("+", ".");

        if (type is IEvent)
        {
            name += "_event";
        }

        return name;
    }

    public static string GetTypeName<T>()
    {
        return GetTypeName(typeof(T));
    }
}