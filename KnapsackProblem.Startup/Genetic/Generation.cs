using System;
using System.Collections.Generic;

namespace KnapsackProblem.Startup.Genetic
{
    /// <summary>
    /// Stores a collection of <see cref="Chromosome"/> objects.
    /// </summary>
    public class Generation : ILogMessage
    {
        #region Private Fields

        private static readonly log4net.ILog Logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Properties

        /// <summary>
        /// Collection of <see cref="Chromosome"/> objects.
        /// </summary>
        public List<Chromosome> Chromosomes { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance of <see cref="Generation"/>.
        /// </summary>
        public Generation()
        {
            Chromosomes = new List<Chromosome>();
        }

        /// <summary>
        /// Create an instance of <see cref="Generation"/>.
        /// </summary>
        /// <param name="chromosomes">Collection of <see cref="Chromosome"/> objects.</param>
        /// <exception cref="ArgumentNullException"><paramref name="chromosomes"/> is null.</exception>
        public Generation(List<Chromosome> chromosomes)
        {
            Chromosomes = chromosomes ?? throw new ArgumentNullException($"{nameof(chromosomes)} is null.");
        }

        #endregion

        #region Public Methods

        public void Log()
        {
            Logger.Debug("Generation");
            foreach (var chromosome in Chromosomes)
            {
                Logger.Debug($"\t{chromosome}");
            }
        }

        #endregion
    }
}
