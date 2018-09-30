using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using KnapsackProblem.Startup.Core;
using KnapsackProblem.Startup.Genetic;

namespace KnapsackProblem.Startup
{
    public class Program
    {
        private static readonly log4net.ILog Logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            
            var stopwatch = Stopwatch.StartNew();
            try
            {
                var dataFile = ConfigurationManager.AppSettings["dataFile"];
                Logger.Info($"Data file: [ {dataFile} ]");

                var repository = new Repository(new ArtemisaKnapsackReader(dataFile));
                Log(repository);

                var chromosomeGenerator = new ChromosomeGenerator();
                var generation = new Generation();

                // Add 10 chromosomes to a generation.
                for (var i = 0; i < 10; i++)
                {
                    var newChromosome = chromosomeGenerator.GenerateRandom(repository.Genes, repository.Knapsack);
                    Logger.Debug(newChromosome);

                    generation.Chromosomes.Add(newChromosome);
                }
                Log(generation);
            }
            catch (Exception e)
            {
                Logger.Fatal(e);
                return;
            }
            stopwatch.Stop();

            Logger.Info($"Elapsed time: {stopwatch.Elapsed.TotalSeconds}.");
        }

        private static void LogRepository(Repository repository)
        {
            Logger.Info("Knapsack:");
            Logger.Info($"\t{repository.Knapsack}");

            Logger.Info("Genes:");
            foreach (var gene in repository.Genes)
            {
                Logger.Info($"\t{gene}");
            }
        }

        private static void Log(ILogMessage message)
        {
            message.Log();
        }
    }
}
