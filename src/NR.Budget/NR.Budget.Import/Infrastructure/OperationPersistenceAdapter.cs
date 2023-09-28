using NR.Budget.Import.Domain.Entities;
using NR.Budget.Import.Port.Output;

namespace NR.Budget.Import.Infrastructure;

public class OperationPersistenceAdapter : ISaveOperationsPort, IGetOperationsPort
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

    public IEnumerable<Depense> ExpensesFromMonth(int year, int month)
    {
        var lastDayOfMonth = new DateTime(year, month + 1, 1).AddDays(-1).Day;
        var operations = _dataContext.Operations.OfType<Depense>().Where(op =>
            op.DateOperation > new DateTime(year, month, 1) && op.DateOperation < new DateTime(year, month, lastDayOfMonth));

        return operations;
    }
}