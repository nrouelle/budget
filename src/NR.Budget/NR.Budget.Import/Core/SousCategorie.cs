public class SousCategorie: IEquatable<SousCategorie>
{
    public string Libelle { get; set; }
    public Categorie Categorie { get; set; } = new Categorie();

    public bool Equals(SousCategorie? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Libelle == other.Libelle && Categorie.Equals(other.Categorie);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SousCategorie)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Libelle, Categorie);
    }
}