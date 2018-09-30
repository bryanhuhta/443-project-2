using System;
using System.Collections.Generic;

namespace KnapsackProblem.Startup.Genetic
{
    public class GenerationManager
    {
        #region Private Methods

        private static readonly ChromosomeGenerator Generator = new ChromosomeGenerator();

        #endregion

        #region Properties

        public int Size { get; }

        #endregion

        #region Constructor

        public GenerationManager(int generationSize)
        {
            Size = generationSize >= 1 ? generationSize : throw new ArgumentOutOfRangeException($"{nameof(generationSize)} is {generationSize}, but needs to be greater than 0.");
        }

        #endregion

        #region Public Methods

        public Generation CreateRandom(List<Gene> genes, Knapsack knapsack)
        {
            var generation = new Generation();

            for (var i = 0; i < Size; i++)
            {
                generation.Chromosomes.Add(Generator.GenerateRandom(genes, knapsack));
            }

            return generation;
        }

        #endregion
    }
}