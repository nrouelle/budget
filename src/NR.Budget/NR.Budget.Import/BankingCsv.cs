public class BankingCsv
{
    public DateTime DateOperation { get; private set; }
    public string Description { get; private set; }
    public decimal Amount { get; private set; }

    public BankingCsv(DateTime dateOperation, string description, decimal amount)
    {
        Description = description;
        DateOperation = dateOperation;
        Amount = amount;
    }
}