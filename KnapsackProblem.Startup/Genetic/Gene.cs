using System;

namespace KnapsackProblem.Startup.Genetic
{
    /// <summary>
    /// This class represents the characteristics of a gene.
    /// </summary>
    public class Gene
    {
        #region Properties

        public int Id { get; }
        public int Weight { get; }
        public int Profit { get; }
        public bool IsActive { get; set; }
        public decimal Value => decimal.Round((decimal)Profit / (decimal)Weight, 2);

        #endregion

        #region Constructors

        /// <summary>
        /// Creates an instance of a <see cref="Gene"/>.
        /// </summary>
        /// <param name="id"><see cref="Gene"/> id.</param>
        /// <param name="weight"><see cref="Gene"/> weight.</param>
        /// <param name="profit"><see cref="Gene"/> profit.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="weight"/> is less than 1.</exception>
        public Gene(int id, int weight, int profit)
        {
            if (weight < 1)
            {
                throw new ArgumentOutOfRangeException($"Parameter [ {nameof(weight)} ] cannot be less than 1.");
            }

            Id = id;
            Weight = weight;
            Profit = profit;
            IsActive = false;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return $"[ Id: {Id}, Weight: {Weight}, Profit: {Profit}, Value: {Value} ]";
        }

        #endregion
    }
}
