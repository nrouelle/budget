namespace NR.Budget.Import.Domain.Entities;

public class Revenu : Operation
{
    public Revenu(DateTime dateOperation, string description, float amount) : base(dateOperation, description, amount)
    {
        OperationType = OperationType.Revenu;
    }
}