namespace NR.Budget.Import.Domain.Entities;

public abstract class Operation : IEquatable<Operation>
{
    public DateTime DateOperation { get; private set; }
    public string Description { get; private set; }
    public float Amount { get; private set; }
    public Categorie Categorie { get; private set; }
    public SousCategorie SousCategorie { get; private set; }
    
    public OperationType OperationType { get; protected set; }

    public Operation(DateTime dateOperation, string description, float amount)
    {
        DateOperation = dateOperation;
        Description = description;
        Amount = amount;
        Categorie = new Categorie();
        SousCategorie = new SousCategorie();
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Operation)obj);
    }

    public bool Equals(Operation? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return DateOperation.Equals(other.DateOperation) 
               && Description == other.Description 
               && Amount == other.Amount 
               && Categorie.Equals(other.Categorie) 
               && SousCategorie.Equals(other.SousCategorie);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(DateOperation, Description, Amount);
    }
}