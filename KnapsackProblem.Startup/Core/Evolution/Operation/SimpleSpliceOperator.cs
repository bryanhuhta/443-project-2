using System;
using System.Collections.Generic;
using KnapsackProblem.Startup.Core.Gene;

namespace KnapsackProblem.Startup.Core.Evolution.Operation
{
    public class SimpleSpliceOperator : ISpliceOperator
    {
        #region Public Methods
    
        /// <summary>
        /// Using two parent chromosomes, splices an offspring.
        /// </summary>
        /// <param name="parent1">The first parent.</param>
        /// <param name="parent2">The second parent.</param>
        /// <returns>The offspring chromosome.</returns>
        public Chromosome Splice(Chromosome parent1, Chromosome parent2)
        {
            var offspringGenes = new List<IGene>();

            // Generate a random breakpoint for the splice from 1 to Count-1.
            // This way there will be at least one gene from each parent chromosome present in the child.
            var breakpoint = new Random().Next(1, parent1.Genes.Count-1);

            // Copy the first parent's genes.
            offspringGenes.AddRange(parent1.Genes.GetRange(1, breakpoint));

            // Copy the second parent's genes.
            offspringGenes.AddRange(parent2.Genes.GetRange(breakpoint + 1, parent2.Genes.Count));

            return new Chromosome(offspringGenes);
        }

        #endregion
    }
}