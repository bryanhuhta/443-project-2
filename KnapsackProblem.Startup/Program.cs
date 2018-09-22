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
                Log.Info($"Data file is: [ {dataFile} ]");

                var repository = new Repository(new ArtemisaKnapsackReader(dataFile));
                LogRepository(repository);
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

            Log.Info("Genes:");
            
        }
    }
}
