﻿using System.Collections.Generic;
using KnapsackProblem.Startup.Genetic;

namespace KnapsackProblem.Startup.Core
{
    /// <summary>
    /// This class interfaces with <see cref="Genetic.Knapsack"/> and <see cref="Gene"/> data found on disk.
    /// </summary>
    public class Repository : ILogMessage
    {
        #region Private Methods

        private static readonly log4net.ILog Logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Properties

        /// <summary>
        /// <see cref="Knapsack"/> data.
        /// </summary>
        public Knapsack Knapsack { get; }

        /// <summary>
        /// <see cref="Gene"/> data.
        /// </summary>
        public List<Gene> Genes { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance of <see cref="Repository"/>.
        /// </summary>
        /// <param name="reader">The <see cref="IKnapsackReader"/> used to populate the <see cref="Repository"/>.</param>
        public Repository(IKnapsackReader reader)
        {
            Knapsack = reader.GetKnapsack();
            Genes = reader.GetGenes();
        }

        #endregion

        #region Public Methods

        public void Log()
        {
            Knapsack.Log();

            Logger.Debug("Genes:");
            foreach (var gene in Genes)
            {
                Logger.Debug($"\t{gene}");
            }
        }

        #endregion
    }
}