namespace KnapsackProblem.Startup.Core.Gene
{
    public interface IGene
    {
        IContent Content { get; }
        bool IsActive { get; set; }
    }
}