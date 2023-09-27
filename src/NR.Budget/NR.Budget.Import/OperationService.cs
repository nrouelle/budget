using NR.Budget.Import.Port.Output;
using NR.Budget.Import.Port.UseCase;

namespace NR.Budget.Import;

public class OperationService : IImportOperations
{
    private readonly ISaveOperationsPort _saveOperationsPort;
    
    public OperationService(ISaveOperationsPort saveOperationsPort)
    {
        _saveOperationsPort = saveOperationsPort;
    }
    public IEnumerable<Operation> ImportOperations(List<Operation> operations)
    {
        return _saveOperationsPort.Save(operations);
    }
}