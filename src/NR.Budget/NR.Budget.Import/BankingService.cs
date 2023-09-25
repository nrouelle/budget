public class BankingService
{
    private readonly IDataContext _context;
    public BankingService(IDataContext context)
    {
        _context = context;
    }
    public bool SaveBankingData(List<BudgetLine> budgetDatas)
    {
        foreach (var data in budgetDatas)
        {
            var budgetLine = new BudgetLine(data.DateOperation.Date, data.Description, data.Amount);
            _context.Lines.Add(budgetLine);
        }
        _context.Save(_context.Lines);
        return true;
    }
}