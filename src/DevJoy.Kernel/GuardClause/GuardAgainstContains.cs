using System.Runtime.CompilerServices;

namespace DevJoy.GuardClause
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
                    throw new ItemFoundException(message ?? $"{value.ToString()} was contained in the {parameterName} collection.");
                }
            }
        }

        public static void Contains(this IGuardClause guardClause,
                                            string sourceString,
                                            string subString,
                                            string? message = null,
                                            [CallerArgumentExpression("sourceString")] string? parameterName = null)
        {
            Guard.Against.Null(sourceString, message);
            Guard.Against.NullOrEmpty(subString, message);
            
            if (sourceString.Contains(subString))
            {
                throw new ItemFoundException(message ?? $"{subString} was contained in the {parameterName} string.");
            }
        }
        public static void DoesNotContain(this IGuardClause guardClause,
                                            string sourceString,
                                            string subString,
                                            string? message = null,
                                            [CallerArgumentExpression("sourceString")] string? parameterName = null)
        {
            Guard.Against.Null(sourceString, message);
            Guard.Against.NullOrEmpty(subString, message);

            if (!sourceString.Contains(subString))
            {
                throw new ItemNotFoundException(message ?? $"{subString} was not contained in the {parameterName} string.");
            }
        }

    }
}
