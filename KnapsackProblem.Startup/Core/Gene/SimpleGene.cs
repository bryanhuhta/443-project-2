namespace KnapsackProblem.Startup.Core.Gene
{
    public class SimpleGene : IGene
    {
        #region Properties

        /// <summary>
        /// The content of this gene represents.
        /// </summary>
        public IContent Content { get; }

        /// <summary>
        /// Indicates whether the gene is active.
        /// </summary>
        public bool IsActive { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates an instance of SimpleGene.
        /// </summary>
        /// <param name="content">The content of the gene.</param>
        public SimpleGene(IContent content)
        {
            Content = content;
        }

        #endregion
    }
}