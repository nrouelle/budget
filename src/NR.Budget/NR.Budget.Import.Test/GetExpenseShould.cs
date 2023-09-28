using NR.Budget.Import.Domain.Services;
using NR.Budget.Import.Infrastructure;

namespace NR.Budget.Import.Test;

public class GetExpenseShould
{
    [Test]
    public void ReturnExpenseForAGivenMonth()
    {
        var expenseMonthFile = "./files/expense_month.txt";
        var context = new InMemoryContext();
        var importService = new ImportService();
        var fileData = File.ReadLines(expenseMonthFile).ToList();
        var savedData = importService.MapFile(fileData);
        
        var operationRepository = new OperationPersistenceAdapter(context);
        var operationService = new OperationService(operationRepository, operationRepository);
        operationService.ImportOperations(savedData);

        var expensesSeptembre = operationService.GetOperations(2023, 9).ToList();
        Assert.That(expensesSeptembre.Count(), Is.EqualTo(2));
    }
}