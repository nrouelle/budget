﻿namespace NR.Budget.Import.Port.UseCase;

public interface IImportOperations
{
    IEnumerable<Operation?> ImportOperations(List<Operation?> operations);
}