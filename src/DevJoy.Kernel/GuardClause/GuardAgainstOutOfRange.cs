using System.Runtime.CompilerServices;

namespace DevJoy.GuardClause;

public static class GuardAgainstOutOfRange
{
    public static void OutOfRange<T>(this IGuardClause guardClause, T input, T min, T max, string? message = null, [CallerArgumentExpression("input")] string? parameterName = null) where T : IComparable, IComparable<T>
    {
        Comparer<T> comparer = Comparer<T>.Default;
        if (comparer.Compare(input, min) < 0) throw new ArgumentOutOfRangeException(message ?? parameterName, $"The input {parameterName} lower than the lower bound of the acceptable range.");
        else if (comparer.Compare(input, max) > 0) throw new ArgumentOutOfRangeException(message ?? parameterName, $"The input {parameterName} higher than the upper bound of the acceptable range.");
    }

    public static void OutOfSQLDateRange(this IGuardClause guardClause, DateTime input, string? message = null, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        const long sqlMinDateTicks = 552877920000000000;
        const long sqlMaxDateTicks = 3155378975999970000;

        guardClause.OutOfRange(input, new DateTime(sqlMinDateTicks), new DateTime(sqlMaxDateTicks), message, parameterName);
    }
}
