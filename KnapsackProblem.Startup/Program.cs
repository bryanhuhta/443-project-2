﻿using System;
using System.Configuration;
using System.Diagnostics;
using KnapsackProblem.Startup.Core;
using KnapsackProblem.Startup.Genetic;
using KnapsackProblem.Startup.Genetic.Internal;
using ChromosomeGenerator = KnapsackProblem.Startup.Genetic.ChromosomeGenerator;

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

                var generationSize = int.Parse(ConfigurationManager.AppSettings["generationSize"]);
                Logger.Info($"Generation size: [ {generationSize} ]");

                var repository = new Repository(new ArtemisaKnapsackReader(dataFile));
                Log(repository);

                var generationManager = new GenerationManager(generationSize);

                var generation = generationManager.CreateRandom(repository.Genes, repository.Knapsack);
                Log(generation);
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
    }
}
