using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace DevJoy.Guard;


public static class GuardAgainstNull
{
    public static void Null<T>(this IGuardClause guardClause, T input, string? message = null, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        if (input is null)
        {
            throw new ArgumentNullException(message ?? $"Required input {parameterName} was null.");
        }
    }

    public static void NullOrEmpty(this IGuardClause guardClause, string? input, string? message = null, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        Guard.Against.Null(input, message, parameterName);
        if (input == string.Empty)
        {
            throw new ArgumentException(message ?? $"Required input {parameterName} was empty.", parameterName);
        }
    }

    public static void NullOrEmpty(this IGuardClause guardClause, Guid? input, string? message = null, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        Guard.Against.Null(input, message, parameterName);
        if (input == Guid.Empty)
        {
            throw new ArgumentException(message ?? $"Required input {parameterName} was empty.", parameterName);
        }
    }

    public static void NullOrEmpty<T>(this IGuardClause guardClause, IEnumerable<T>? input, string? message = null, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        Guard.Against.Null(input, message, parameterName);

        if (!input!.Any())
        {
            throw new ArgumentException(message ?? $"Required input {parameterName} was empty.", parameterName);
        }
    }

    public static void NullOrWhitespace(this IGuardClause guardClause, string? input, string? message = null, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        Guard.Against.NullOrEmpty(input, message, parameterName);
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException(message ?? $"Required input {parameterName} was empty.", parameterName);
        }
    }

    public static void Default<T>(this IGuardClause guardClause, T input, string? message = null, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        if (EqualityComparer<T>.Default.Equals(input, default!) || input is null)
        {
            throw new ArgumentException(message ?? $"Parameter [{parameterName}] is default value for type {typeof(T).Name}", parameterName);
        }
    }
}
