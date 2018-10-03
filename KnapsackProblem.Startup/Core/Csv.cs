using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnapsackProblem.Startup.Core
{
    /// <summary>
    /// Writes and reads the csv format.
    /// </summary>
    public static class Csv
    {
        #region Public Methods

        /// <summary>
        /// Writes a set of items into a csv line.
        /// </summary>
        /// <param name="items">Set of items to write.</param>
        /// <returns>A single <see cref="string"/> of formatted csv.</returns>
        public static string WriteLine(string[] items)
        {
            var builder = new StringBuilder();

            builder.Append(Write(items))
                .AppendLine();

            return builder.ToString();
        }

        /// <summary>
        /// Writes a set of items into a csv format.
        /// </summary>
        /// <param name="items">Set of items to format.</param>
        /// <returns>A <see cref="string"/> of csv.</returns>
        public static string Write(string[] items)
        {
            var builder = new StringBuilder();

            for (var i = 0; i < items.Length - 1; ++i)
            {
                builder.Append($"\"{items[i]}\",");
            }
            builder.Append($"\"{items.Last()}\"");

            return builder.ToString();
        }

        #endregion
    }
}