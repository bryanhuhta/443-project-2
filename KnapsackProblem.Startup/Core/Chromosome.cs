using System.Collections.Generic;
using KnapsackProblem.Startup.Core.Evolution.Gene;

namespace KnapsackProblem.Startup.Core
{
    public class Chromosome
    {
        #region Properties

        /// <summary>
        /// The gene string.
        /// </summary>
        public IEnumerable<IGene> Genes { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates an instance of Chromosome.
        /// </summary>
        /// <param name="genes">The gene string.</param>
        public Chromosome(IEnumerable<IGene> genes)
        {
            Genes = genes;
        }

        #endregion
    }
}