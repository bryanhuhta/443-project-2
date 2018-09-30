using System;
using System.Collections.Generic;
using System.Linq;

namespace KnapsackProblem.Startup.Genetic
{
    public class ChromosomeGenerator
    {
        #region Private Fields

        private static Random _random;
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Construtor

        public ChromosomeGenerator()
        {
            _random = new Random();
        }

        #endregion

        #region Public Methods

        public Chromosome GenerateRandom(List<Gene> genes, Knapsack knapsack)
        {
            // Make all genes inactive.
            var newGenes = GetInactiveGenes(genes);
            foreach (var gene in newGenes)
            {
                gene.IsActive = false;
            }

            var newChromosome = new Chromosome(newGenes);
            var randomGene = GetRandomGene(newChromosome);
            
            // Make random genes active until one fails (i.e. cannot be added to the knapsack).
            while (newChromosome.Weight + randomGene.Weight <= knapsack.Capacity)
            {
                newChromosome.Genes.Find(gene => gene.Id == randomGene.Id).IsActive = true;
                randomGene = GetRandomGene(newChromosome);
            }

            return newChromosome;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets a random inactive <see cref="Gene"/> from a <see cref="Chromosome"/>.
        /// </summary>
        /// <param name="chromosome">A <see cref="Chromosome"/>.</param>
        /// <returns>A <see cref="Gene"/>.</returns>
        private static Gene GetRandomGene(Chromosome chromosome)
        {
            var inactiveGenes = chromosome.Genes.Where(gene => !gene.IsActive).ToList();
            return inactiveGenes.ElementAt(_random.Next(0, inactiveGenes.Count));
        }
        
        /// <summary>
        /// Clones <paramref name="genes"/> to a new list and sets all <see cref="Gene.IsActive"/> to false.
        /// </summary>
        /// <param name="genes"><see cref="Gene"/> list.</param>
        /// <returns>A list of <see cref="Gene"/> objects with <see cref="Gene.IsActive"/> set to false.</returns>
        private static List<Gene> GetInactiveGenes(List<Gene> genes)
        {
            var newGenes = new List<Gene>(genes.Count);

            genes.ForEach(gene =>
            {
                newGenes.Add((Gene) gene.Clone());
            });

            genes.ForEach(gene =>
            {
                gene.IsActive = false;
            });

            return newGenes;
        }

        #endregion
    }
}