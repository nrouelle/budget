namespace NR.Budget.Import.Data;

public class InMemoryContext : IDataContext
{
    public List<BudgetLine> Lines { get; set; } = new List<BudgetLine>();
    public void Save(List<BudgetLine> lines)
    {
        
    }
}