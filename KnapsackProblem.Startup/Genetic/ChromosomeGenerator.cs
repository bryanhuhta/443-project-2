using System;
using System.Collections.Generic;
using System.Linq;
using KnapsackProblem.Startup.Core;

namespace KnapsackProblem.Startup.Genetic
{
    public class ChromosomeGenerator
    {
        #region Private Fields
        
        private readonly Random _random;
        private readonly Repository _repository;

        #endregion
        
        #region Constructors

        /// <summary>
        /// Creates an instance of <see cref="ChromosomeGenerator"/>.
        /// </summary>
        /// <param name="repository">A <see cref="Repository"/>.</param>
        public ChromosomeGenerator(Repository repository)
        {
            _random = new Random();
            _repository = repository;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Builds a <see cref="Chromosome"/> with randomized genes.
        /// </summary>
        /// <returns>A <see cref="Chromosome"/> with random genes.</returns>
        public Chromosome GenerateRandomChromosome()
        {
            var genes = _repository.Genes;

            // Select random genes to turn on until one fails (i.e. is too big to fit into the bag).
            var index = RandomInactive(genes);
            while (CanAddGene(genes[index], genes, _repository.Knapsack))
            {
                genes[index].IsActive = true;
                index = RandomInactive(genes);
            }

            return new Chromosome(genes);
        }

        #endregion

        #region Private Methods

        private int RandomInactive(List<Gene> genes)
        {
            // Continuing selecting random genes until one that isn't active is selected.
            var index = _random.Next() % _repository.Knapsack.Capacity;
            while (genes[index].IsActive)
            {
                index = _random.Next() % _repository.Knapsack.Capacity;
            }

            return index;
        }
        
        private bool CanAddGene(Gene gene, List<Gene> genes, Knapsack knapsack)
        {
            return genes.Sum(g => g.Weight) + gene.Weight <= knapsack.Capacity;
        }

        #endregion
    }
}