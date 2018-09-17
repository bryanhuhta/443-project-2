using System.Collections.Generic;
using KnapsackProblem.Startup.Core.Evolution.Fitness;
using KnapsackProblem.Startup.Core.Gene;

namespace KnapsackProblem.Startup.Core
{
    public class Chromosome
    {
        #region Private Fields

        private readonly IFitness _fitness;

        #endregion

        #region Properties

        /// <summary>
        /// The collection of genes associated with this chromosome.
        /// </summary>
        public List<IGene> Genes { get; }
        
        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <param name="genes">The collection of genes associated with this chromosome.</param>
        public Chromosome(List<IGene> genes)
        {
            Genes = genes;
        }

        #endregion
    }
}