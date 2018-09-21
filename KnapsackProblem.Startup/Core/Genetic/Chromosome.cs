using System.Collections.Generic;

namespace KnapsackProblem.Startup.Core.Genetic
{
    public class Chromosome
    {
        #region Properties

        public List<Gene> Genes { get; }

        #endregion

        #region Constructors

        public Chromosome(List<Gene> genes)
        {
            Genes = genes;
        }

        #endregion
    }
}