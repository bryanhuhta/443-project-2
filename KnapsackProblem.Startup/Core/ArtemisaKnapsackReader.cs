using System;
using System.Collections.Generic;
using System.IO;
using KnapsackProblem.Startup.Genetic;

namespace KnapsackProblem.Startup.Core
{
    /// <summary>
    /// This class implements <see cref="IKnapsackReader"/>.
    /// </summary>
    public class ArtemisaKnapsackReader : IKnapsackReader
    {
        #region Private Fields

        private readonly string _file;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance of <see cref="ArtemisaKnapsackReader"/>.
        /// </summary>
        /// <param name="file">The file from which to read.</param>
        /// <exception cref="ArgumentException"><paramref name="file"/> is null.</exception>
        public ArtemisaKnapsackReader(string file)
        {
            _file = file ?? throw new ArgumentException($"{nameof(file)} cannot be null.");
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Reads a list of genes from a file.
        /// </summary>
        /// <returns>The list of <see cref="Gene"/>.</returns>
        public List<Gene> GetGenes()
        {
            var genes = new List<Gene>();

            using (var stream = new StreamReader(_file))
            {
                // Check how many rows to read.
                var count = ReadTuple(stream.ReadLine()).Item1;
                var id = 0;

                while (!stream.EndOfStream)
                {
                    var tokens = stream.ReadLine()
                        .Split(' ');

                    if (tokens.Length != 2)
                    {
                        throw new IOException($"Found {tokens.Length} tokens, expected 2.");
                    }

                    // Add the gene.
                    genes.Add(new Gene(id, int.Parse(tokens[1]), int.Parse(tokens[0])));
                    ++id;
                }

                // Verify appropriate number of rows were read.
                if (genes.Count != count)
                {
                    throw new IOException($"Found {genes.Count} genes, expected {count}.");
                }
            }

            return genes;
        }

        /// <summary>
        /// Reads the <see cref="Knapsack"/> configuration from a file.
        /// </summary>
        /// <returns>The <see cref="Knapsack"/> configuration.</returns>
        public Knapsack GetKnapsack()
        {
            using (var stream = new StreamReader(_file))
            {
                var line = stream.ReadLine();
                return new Knapsack(ReadTuple(line).Item2);
            }
        }

        #endregion

        #region Private Methods

        private Tuple<int, int> ReadTuple(string line)
        {
            var tokens = line.Split(' ');

            if (tokens.Length != 2)
            {
                throw new IOException($"Found {tokens.Length} tokens, expected 2.");
            }

            return new Tuple<int, int>(int.Parse(tokens[0]), int.Parse(tokens[1]));
        }

        #endregion
    }
}