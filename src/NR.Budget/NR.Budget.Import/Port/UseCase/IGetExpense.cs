using NR.Budget.Import.Domain.Entities;

namespace NR.Budget.Import.Port.UseCase;

public interface IGetExpense
{
    List<Depense> GetExpensesForMonth(int year, int month);
}