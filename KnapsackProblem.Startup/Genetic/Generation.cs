using System;
using System.Collections.Generic;
using System.Linq;

namespace KnapsackProblem.Startup.Genetic
{
    /// <summary>
    /// Stores a collection of <see cref="Chromosome"/> objects.
    /// </summary>
    public class Generation : ILogMessage, IExport
    {
        #region Private Fields

        private static readonly log4net.ILog Logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Properties

        /// <summary>
        /// Collection of <see cref="Chromosome"/> objects.
        /// </summary>
        public List<Chromosome> Chromosomes { get; }
        public int Id { get; }

        public decimal AverageProfit => Chromosomes.Sum(c => c.Profit) / (decimal) Chromosomes.Count;
        public decimal AverageWeight => Chromosomes.Sum(c => c.Weight) / (decimal) Chromosomes.Count;
        public decimal AverageFitness => Chromosomes.Sum(c => c.Fitness) / Chromosomes.Count;
        public decimal MaxFitness => Chromosomes.Max(c => c.Fitness);

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance of <see cref="Generation"/>.
        /// </summary>
        public Generation(int id)
        {
            Id = id;
            Chromosomes = new List<Chromosome>();
        }

        /// <summary>
        /// Create an instance of <see cref="Generation"/>.
        /// </summary>
        /// <param name="chromosomes">Collection of <see cref="Chromosome"/> objects.</param>
        /// <exception cref="ArgumentNullException"><paramref name="chromosomes"/> is null.</exception>
        public Generation(int id, List<Chromosome> chromosomes)
        {
            Id = id;
            Chromosomes = chromosomes ?? throw new ArgumentNullException($"{nameof(chromosomes)} is null.");
        }

        #endregion

        #region Public Methods

        public void Log()
        {
            Logger.Debug($"[ Ave. Weight: {AverageWeight}, Ave. Profit: {AverageProfit}, Ave. Fitness: {AverageFitness} ]");
            foreach (var chromosome in Chromosomes)
            {
                Logger.Debug($"\t{chromosome}");
            }
        }

        public List<string> Export()
        {
            return new List<string>
            {
                Id.ToString(),
                AverageWeight.ToString(),
                AverageProfit.ToString(),
                AverageFitness.ToString(),
                MaxFitness.ToString()
            };
        }

        #endregion
    }
}
