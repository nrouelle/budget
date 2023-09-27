namespace NR.Budget.Import.Domain.Entities;

public class Depense : Operation
{
    public Depense(DateTime dateOperation, string description, float amount) : base(dateOperation, description, amount)
    {
        OperationType = OperationType.Depense;
    }
}