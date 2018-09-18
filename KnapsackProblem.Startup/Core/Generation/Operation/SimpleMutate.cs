using System;
using System.Linq;

namespace KnapsackProblem.Startup.Core.Generation.Operation
{
    public class SimpleMutate : IMutate
    {
        #region Properties



        #endregion

        #region Constructors



        #endregion

        #region Public Methods

        public Chromosome Mutate(Chromosome chromosome)
        {
            // Copy chromosome.Genes to local variable.

            // Pick a random gene to turn off.

            // Pick another random gene that can turn on (and still be valid).

            // Return new chromosome.
        }

        #endregion
    }
}