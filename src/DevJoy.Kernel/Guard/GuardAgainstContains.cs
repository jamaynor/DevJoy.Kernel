using System.Runtime.CompilerServices;

namespace DevJoy.Guard
{
    public static class GuardAgainstContains
    {
        public static void Contains<T>(this IGuardClause guardClause,
                                            IEnumerable<T> collection,
                                            Func<T, bool> predicate,
                                            string? message = null,
                                            [CallerArgumentExpression("collection")] string? parameterName = null)
        {
            Guard.Against.Null(predicate, message);
            Guard.Against.NullOrEmpty(collection, message);

            foreach (T value in collection)
            {
                if (value is not null && predicate(value))
                {
                    throw new ElementFoundException(message ?? $"{value.ToString()} was contained in the {parameterName} collection.");
                }
            }
        }
    }
}
