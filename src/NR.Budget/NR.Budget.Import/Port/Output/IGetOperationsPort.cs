using NR.Budget.Import.Domain.Entities;

namespace NR.Budget.Import.Port.Output;

public interface IGetOperationsPort
{
    IEnumerable<Depense> ExpensesFromMonth(int year, int month);
}