using System;

namespace KnapsackProblem.Startup.Genetic
{
    /// <summary>
    /// This class represents the contents of a knapsack.
    /// </summary>
    public class Knapsack : ILogMessage
    {
        #region Private Fields

        private static readonly log4net.ILog Logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Properties

        /// <summary>
        /// Capacity of the knapsack.
        /// </summary>
        public int Capacity { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates 
        /// </summary>
        /// <param name="capacity"></param>
        /// <exception cref="ArgumentOutOfRangeException">Capacity is negative.</exception>
        public Knapsack(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentOutOfRangeException($"{nameof(capacity)} [ {capacity} ] cannot be less than 1.");
            }

            Capacity = capacity;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return $"[ Capacity: {Capacity} ]";
        }

        public void Log()
        {
            Logger.Debug("Knapsack");
            Logger.Debug($"\t{Capacity}");
        }

        #endregion
    }
}