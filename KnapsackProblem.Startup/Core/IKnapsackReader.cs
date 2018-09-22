using System.Collections.Generic;
using KnapsackProblem.Startup.Genetic;

namespace KnapsackProblem.Startup.Core
{
    public interface IKnapsackReader
    {
        List<Gene> GetGenes();
        Knapsack GetKnapsack();
    }
}