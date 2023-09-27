namespace NR.Budget.Import.Data;

public class InMemoryContext : IDataContext
{
    public List<Operation?> Operations { get; set; } = new List<Operation?>();
    public void SaveChanges()
    { }
}