using System.Linq;

namespace KnapsackProblem.Startup.Genetic.Internal
{
    /// <summary>
    /// Implements a simple fitness calculation for <see cref="Chromosome"/>.
    /// </summary>
    internal class SimpleFitness : IFitness
    {
        #region Public Methods

        /// <summary>
        /// Calculates the fitness of a <see cref="Chromosome"/>.
        /// </summary>
        /// <param name="chromosome"><see cref="Chromosome"/> used in calculation.</param>
        /// <returns>The fitness of <paramref name="chromosome"/>.</returns>
        public decimal GetFitness(Chromosome chromosome)
        {
            return chromosome.Genes.Sum(gene => gene.Value);
        }

        #endregion
    }
}