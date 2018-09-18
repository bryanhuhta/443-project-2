namespace KnapsackProblem.Startup.Core.Evolution.Gene
{
    public interface IGene
    {
        IContent Content { get; }
        bool IsActive { get; set; }
    }
}