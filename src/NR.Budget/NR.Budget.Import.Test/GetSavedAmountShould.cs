using NR.Budget.Import.Domain.Services;
using NR.Budget.Import.Infrastructure;

namespace NR.Budget.Import.Test;

public class GetSavedAmountShould
{
    [Test]
    public void ReturnSavingsForAGivenMonth()
    {
        var expenseMonthFile = "./files/expense_month.txt";
        var context = new InMemoryContext();
        var importService = new ImportService();
        var fileData = File.ReadLines(expenseMonthFile).ToList();
        var savedData = importService.MapFile(fileData);
        
        var operationRepository = new OperationPersistenceAdapter(context);
        var operationService = new OperationService(operationRepository, operationRepository);
        operationService.ImportOperations(savedData);

        var revenuesSeptember = operationService.GetRevenues(2023, 9).ToList();
        var expensesSeptember = operationService.GetSavings(2023, 9);
        Assert.IsTrue(operationService.GetSavings(2023, 9).IsEqualTo(-0.48f));
    }
}