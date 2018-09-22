using System.Collections.Generic;
using System.Linq;

namespace KnapsackProblem.Startup.Genetic
{
    public class Chromosome
    {
        #region Properties

        public List<Gene> Genes { get; }
        public int Weight => Genes.Where(gene => gene.IsActive).Sum(gene => gene.Weight);
        public int Profit => Genes.Where(gene => gene.IsActive).Sum(gene => gene.Profit);

        #endregion

        #region Constructors

        public Chromosome(List<Gene> genes)
        {
            Genes = genes;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return $"[ Total weight: {Weight}, Total profit: {Profit} ]";
        }

        #endregion
    }
}