using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
            
            var totalTime = Stopwatch.StartNew();
            try
            {
                var dataFile = ConfigurationManager.AppSettings["dataFile"];
                Logger.Info($"Data file: [ {dataFile} ]");

                var exportFile = ConfigurationManager.AppSettings["exportFile"];
                Logger.Info($"Export file: [ {exportFile} ]");

                var generationSize = int.Parse(ConfigurationManager.AppSettings["generationSize"]);
                Logger.Info($"Generation size: [ {generationSize} ]");

                var generationCount = int.Parse(ConfigurationManager.AppSettings["generationCount"]);
                Logger.Info($"Generation count: [ {generationCount} ]");

                var repository = new Repository(new ArtemisaKnapsackReader(dataFile));
                Log(repository);

                var generationManager = new GenerationManager(generationSize);
                var generations = new List<Generation>
                {
                    generationManager.CreateRandom(0, repository.Genes, repository.Knapsack)
                };

                for (var i = 1; i < 1000; ++i)
                {
                    // Evolve.
                }

                ExportHeader(exportFile);
                var rows = Export(exportFile, generations);
                Logger.Info($"Exported [ {rows} ] rows.");
            }
            catch (Exception e)
            {
                Logger.Fatal(e);
                return;
            }
            totalTime.Stop();

            Logger.Info($"Elapsed time: {totalTime.Elapsed.TotalSeconds}.");
        }
        
        private static void Log(ILogMessage message)
        {
            message.Log();
        }

        private static void ExportHeader(string path)
        {
            using (var writer = new StreamWriter(path, append: false))
            {
                writer.WriteLine(Csv.Write(new []
                {
                    "Generation",
                    "Average Weight",
                    "Average Value",
                    "Average Fitness",
                    "Maximum Fitness"
                }));
            }
        }

        private static int Export(string path, IReadOnlyList<Generation> generations)
        {
            var rows = 0;

            using (var writer = new StreamWriter(path, append: true))
            {
                foreach (var generation in generations)
                {
                    writer.WriteLine(Csv.Write(generation.Export().ToArray()));
                    ++rows;
                }
            }

            return rows;
        }
    }
}
