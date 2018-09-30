using System;
using System.Configuration;
using System.Diagnostics;
using KnapsackProblem.Startup.Core;

namespace KnapsackProblem.Startup
{
    public class Program
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            
            var stopwatch = Stopwatch.StartNew();
            try
            {
                var dataFile = ConfigurationManager.AppSettings["dataFile"];
                Log.Info($"Data file: [ {dataFile} ]");

                var repository = new Repository(new ArtemisaKnapsackReader(dataFile));
                LogRepository(repository);

                // TODO: Create a generation generator
                // TODO:    1st gen 100% random
                // TODO:    2nd gen is produced from previous
            }
            catch (Exception e)
            {
                Log.Fatal(e);
                return;
            }
            stopwatch.Stop();

            Log.Info($"Elapsed time: {stopwatch.Elapsed.TotalSeconds}.");
        }

        private static void LogRepository(Repository repository)
        {
            Log.Info("Knapsack:");
            Log.Info($"\t{repository.Knapsack}");

            Log.Info("Genes:");
            foreach (var gene in repository.Genes)
            {
                Log.Info($"\t{gene}");
            }
        }
    }
}
