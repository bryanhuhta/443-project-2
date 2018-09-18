namespace KnapsackProblem.Startup.Core.Gene
{
    public class KnapsackContent : IContent
    {
        #region Properties

        /// <summary>
        /// The content value.
        /// </summary>
        public double Value => Weight / Profit;

        /// <summary>
        /// The content weight.
        /// </summary>
        public double Weight { get; }

        /// <summary>
        /// The content profit.
        /// </summary>
        public double Profit { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a KnapsackContent instance.
        /// </summary>
        /// <param name="weight">The content weight.</param>
        /// <param name="profit">The content profit.</param>
        public KnapsackContent(double weight, double profit)
        {
            Weight = weight;
            Profit = profit;
        }

        #endregion
    }
}