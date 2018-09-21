using System;

namespace KnapsackProblem.Startup.Core
{
    public class Gene
    {
        #region Properties

        public int Weight { get; }
        public int Profit { get; }
        public bool IsActive { get; set; }
        public double Value => Profit / Weight;

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates a gene.
        /// </summary>
        /// <param name="weight">Gene weight.</param>
        /// <param name="profit">Gene profit.</param>
        /// <exception cref="ArgumentOutOfRangeException">Weight is less than 1.</exception>
        public Gene(int weight, int profit)
        {
            if (weight < 1)
            {
                throw new ArgumentOutOfRangeException($"Parameter [ {nameof(weight)} ] cannot be less than 1.");
            }

            Weight = weight;
            Profit = profit;
            IsActive = false;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return $"[ {Weight} {Profit} => {Value}";
        }

        #endregion
    }
}
