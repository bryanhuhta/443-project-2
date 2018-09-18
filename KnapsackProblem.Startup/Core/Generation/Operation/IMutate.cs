namespace KnapsackProblem.Startup.Core.Generation.Operation
{
    public interface IMutate
    {
        Chromosome Mutate(Chromosome chromosome);
    }
}