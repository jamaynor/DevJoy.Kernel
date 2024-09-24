namespace DevJoy.GuardClause;

public static class GuardAgainstNotFound
{

    public static void NotFound<T>(this IGuardClause guardClause,
                                        IEnumerable<T> enumerable,
                                        Func<T, bool> matchFunction,
                                        string? message = null) where T : IComparable, IComparable<T>
    {
        Guard.Against.Null(enumerable, message);

        foreach (T value in enumerable)
        {
            if (matchFunction(value)) return;
        }
        throw new ArgumentException(message ?? "The element was not found.");
    }

    public static void KeyNotFound<TKey, TValue>(this IGuardClause guardClause,
                                                   IDictionary<TKey, TValue> dictionary,
                                                   Func<TKey, bool> predicate,
                                                   string? message = null) where TKey : IComparable, IComparable<TKey>
    {
        Guard.Against.Null(dictionary, message);

        foreach (TKey value in dictionary.Keys)
        {
            if (predicate(value)) return;
        }
        throw new KeyNotFoundException(message ?? $"The key of was not found.");
    }


    public static void ValueNotFound<TKey, TValue>(this IGuardClause guardClause,
                                                   IDictionary<TKey, TValue> dictionary,
                                                   Func<TValue, bool> predicate,
                                                   string? message = null) where TKey : IComparable, IComparable<TKey>
    {
        Guard.Against.Null(dictionary, message);

        foreach (TValue value in dictionary.Values)
        {
            if (predicate(value)) return;
        }
        throw new ArgumentException(message ?? $"The value was not found.");
    }
}

