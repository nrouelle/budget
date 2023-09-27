namespace NR.Budget.Import.Domain.Entities;

public class Categorie : IEquatable<Categorie>
{
    public string Libelle { get; set; }

    public bool Equals(Categorie? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Libelle == other.Libelle;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Categorie)obj);
    }

    public override int GetHashCode()
    {
        return Libelle.GetHashCode();
    }
}