namespace KnapsackProblem.Startup.Genetic.Internal
{
    public interface IFitness
    {
        decimal GetFitness(Chromosome chromosome);
    }
}