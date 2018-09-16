using System.Collections.Generic;
using KnapsackProblem.Startup.Core.Gene;
using KnapsackProblem.Startup.Core.Operations;

namespace KnapsackProblem.Startup.Core.Chromosome
{
    public class Chromosome
    {
        #region Private Fields

        private IFitness _fitness;

        #endregion

        #region Properties

        /// <summary>
        /// The collection of genes associated with this chromosome.
        /// </summary>
        public List<IGene> Genes { get; }

        /// <summary>
        /// Evaluates the fitness of this chromosome.
        /// </summary>
        public double Fitness => _fitness.Evaluate(Genes);
        
        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <param name="genes">The collection of genes associated with this chromosome.</param>
        /// <param name="fitness">The fitness function.</param>
        public Chromosome(List<IGene> genes, IFitness fitness)
        {
            Genes = genes;
            _fitness = fitness;
        }

        #endregion
    }
}