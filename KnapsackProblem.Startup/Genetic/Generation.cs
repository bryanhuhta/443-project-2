using System.Collections.Generic;

namespace KnapsackProblem.Startup.Genetic
{
    public class Generation
    {
        #region Properties

        public List<Chromosome> Chromosomes { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance of <see cref="Generation"/> from a list of <see cref="Chromosome"/>.
        /// </summary>
        /// <param name="chromosomes">A list of <see cref="Chromosome"/>.</param>
        public Generation(List<Chromosome> chromosomes)
        {
            Chromosomes = chromosomes;
        }

        #endregion
    }
}
