namespace KnapsackProblem.Startup.Core.Evolution.Operation
{
    public interface IOperation
    {
        Chromosome Splice(Chromosome parent1, Chromosome parent2);
        Chromosome Mutate(Chromosome chromosome);
    }
}