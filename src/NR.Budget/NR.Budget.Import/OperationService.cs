public class OperationService
{
    private readonly IDataContext _context;
    public OperationService(IDataContext context)
    {
        _context = context;
    }
    public bool SaveOperations(List<Operation> budgetDatas)
    {
        foreach (var data in budgetDatas)
        {
            var operation = new Operation(data.DateOperation.Date, data.Description, data.Amount);
            _context.Operations.Add(operation);
        }
        _context.Save(_context.Operations);
        return true;
    }
}