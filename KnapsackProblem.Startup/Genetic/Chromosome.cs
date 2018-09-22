using System.Collections.Generic;
using System.Linq;

namespace KnapsackProblem.Startup.Genetic
{
    /// <summary>
    /// This class encapsulates active and inactive <see cref="Gene"/> instances and the data associated with them.
    /// </summary>
    public class Chromosome
    {
        #region Properties

        /// <summary>
        /// <see cref="Gene"/> instances for this <see cref="Chromosome"/>.
        /// </summary>
        public List<Gene> Genes { get; }
        
        /// <summary>
        /// The total weight of this <see cref="Chromosome"/>.
        /// </summary>
        public int Weight => Genes.Where(gene => gene.IsActive).Sum(gene => gene.Weight);

        /// <summary>
        /// The total profit of this <see cref="Chromosome"/>.
        /// </summary>
        public int Profit => Genes.Where(gene => gene.IsActive).Sum(gene => gene.Profit);

        #endregion

        #region Constructors

        /// <summary>
        /// Creates an instance of <see cref="Chromosome"/>.
        /// </summary>
        /// <param name="genes">A list of <see cref="Gene"/> instances.</param>
        public Chromosome(List<Gene> genes)
        {
            Genes = genes;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return $"[ Total weight: {Weight}, Total profit: {Profit} ]";
        }

        #endregion
    }
}