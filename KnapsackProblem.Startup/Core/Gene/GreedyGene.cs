namespace KnapsackProblem.Startup.Core.Gene
{
    public class GreedyGene : IGene
    {
        #region Properties

        /// <summary>
        /// The value of GreedyGene.
        /// </summary>
        public double Value => Profit / Weight;

        /// <summary>
        /// The weight of GreedyGene.
        /// </summary>
        public double Weight { get; }

        /// <summary>
        /// The profit of GreedyGene.
        /// </summary>
        public double Profit { get; }

        #endregion

        #region Constructors
        
        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <param name="weight">The weight of the gene (default is 1).</param>
        /// <param name="profit">The profit of the gene (default is 1).</param>
        public GreedyGene(double weight = 1, double profit = 1)
        {
            Weight = weight;
            Profit = profit;
        }

        #endregion
    }
}