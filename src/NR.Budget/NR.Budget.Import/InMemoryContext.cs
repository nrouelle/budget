public class InMemoryContext : IDataContext
{
    public List<BudgetLine> Lines { get; set; } = new List<BudgetLine>();
}

public interface IDataContext
{
    List<BudgetLine> Lines { get; set; }
}