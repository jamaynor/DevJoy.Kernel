using System.Runtime.CompilerServices;

namespace DevJoy.Guard;

public static class GuardAgainstTrue
{

    public static void True(this IGuardClause guardClause, Func<bool> predicate, string? message = null)
    {
        Guard.Against.Null(predicate, message);

        if (predicate())
        {
            throw new ApplicationException(message ?? "The input matched an exclusion case in the requirements.");
        }
    }



    public static void False(this IGuardClause guardClause, Func<bool> predicate, string? message = null)
    {
        Guard.Against.Null(predicate, message);

        if (!predicate())
        {
            throw new ApplicationException(message ?? "The input did not satisfy the requirements.");
        }
    }

}
