using NR.Budget.Import.Domain.Entities;

namespace NR.Budget.Import.Infrastructure;

public class InMemoryContext : IDataContext
{
    public List<Operation> Operations { get; set; } = new List<Operation>();

    public void SaveChanges()
    {
    }
}