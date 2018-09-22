using System.Collections.Generic;
using KnapsackProblem.Startup.Genetic;

namespace KnapsackProblem.Startup.Core
{
    public class Repository
    {
        #region Properties

        public Knapsack Knapsack { get; }
        public List<Gene> Genes { get; }

        #endregion

        #region Constructor

        public Repository(IKnapsackReader reader)
        {
            Knapsack = reader.GetKnapsack();
            Genes = reader.GetGenes();
        }

        #endregion
    }
}