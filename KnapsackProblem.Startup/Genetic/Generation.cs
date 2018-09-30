using System;
using System.Collections.Generic;

namespace KnapsackProblem.Startup.Genetic
{
    /// <summary>
    /// Stores a collection of <see cref="Chromosome"/> objects.
    /// </summary>
    public class Generation
    {
        #region Properties

        /// <summary>
        /// Collection of <see cref="Chromosome"/> objects.
        /// </summary>
        public List<Chromosome> Chromosomes { get; }

        #endregion

        #region Constructor

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
    }
}
