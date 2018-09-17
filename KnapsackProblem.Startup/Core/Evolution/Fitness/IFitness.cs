using System.Collections.Generic;
using KnapsackProblem.Startup.Core.Gene;

namespace KnapsackProblem.Startup.Core.Evolution.Fitness
{
    public interface IFitness
    {
        double Evaluate(IEnumerable<IGene> genes);
    }
}