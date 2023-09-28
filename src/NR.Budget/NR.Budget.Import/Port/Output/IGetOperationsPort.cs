using NR.Budget.Import.Domain.Entities;

namespace NR.Budget.Import.Port.Output;

public interface IGetOperationsPort
{
    IEnumerable<Depense> ExpensesFromMonth(int year, int month);
    IEnumerable<Revenu> RevenuesFromMonth(int year, int month);
    float GetSavings(int year, int month);
}