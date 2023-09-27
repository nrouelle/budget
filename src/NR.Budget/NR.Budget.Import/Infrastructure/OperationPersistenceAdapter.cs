using NR.Budget.Import.Domain.Entities;
using NR.Budget.Import.Port.Output;

namespace NR.Budget.Import.Infrastructure;

public class OperationPersistenceAdapter : ISaveOperationsPort
{
    private readonly IDataContext _dataContext;

    public OperationPersistenceAdapter(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public IEnumerable<Operation?> Save(List<Operation?> operations)
    { 
        _dataContext.Operations.AddRange(operations);
        _dataContext.SaveChanges();
        
        return _dataContext.Operations;
    }
}