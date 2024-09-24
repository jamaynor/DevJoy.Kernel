namespace DevJoy.GuardClause
{
    /// <summary>
    /// Simple interface to provide a generic mechanism to build guard clause extension methods from.
    /// </summary>
    public interface IGuardClause { }

    /// <summary>
    /// An entry point to a set of Guard Clauses defined as extension methods on IGuardClause.
    /// </summary>
    /// <remarks>Inspired by Steve Smith.</remarks>
    public class Guard : IGuardClause
    {
        /// <summary>
        /// An entry point to a set of Guard Clauses.
        /// </summary>
        public static IGuardClause Against { get; } = new Guard();

        private Guard() { }
    }
}
