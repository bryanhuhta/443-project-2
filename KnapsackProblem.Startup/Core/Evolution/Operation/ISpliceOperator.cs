namespace KnapsackProblem.Startup.Core.Evolution.Operation
{
    public interface ISpliceOperator
    {
        Chromosome Splice(Chromosome parent1, Chromosome parent2);
    }
}