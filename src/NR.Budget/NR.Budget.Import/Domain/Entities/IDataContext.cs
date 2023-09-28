namespace NR.Budget.Import.Domain.Entities;

public interface IDataContext
{
    List<Operation> Operations { get; set; }

    void SaveChanges();
}