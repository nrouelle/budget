using NR.Budget.Import.Domain.Entities;

namespace NR.Budget.Import.Port.Output;

public interface ISaveOperationsPort
{
    IEnumerable<Operation?> Save(List<Operation?> operations);
}