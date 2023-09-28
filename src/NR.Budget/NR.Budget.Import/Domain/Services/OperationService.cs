﻿using NR.Budget.Import.Domain.Entities;
using NR.Budget.Import.Port.Output;
using NR.Budget.Import.Port.UseCase;

namespace NR.Budget.Import.Domain.Services;

public class OperationService : IImportOperations
{
    private readonly ISaveOperationsPort _saveOperationsPort;
    private readonly IGetOperationsPort _getOperationsPort;
    
    public OperationService(ISaveOperationsPort saveOperationsPort, IGetOperationsPort getOperationsPort)
    {
        _saveOperationsPort = saveOperationsPort;
        _getOperationsPort = getOperationsPort;
    }
    public IEnumerable<Operation?> ImportOperations(List<Operation?> operations)
    {
        return _saveOperationsPort.Save(operations);
    }

    public IEnumerable<Operation> GetOperations(int year, int month)
    {
        return _getOperationsPort.ExpensesFromMonth(year, month);
    }
}