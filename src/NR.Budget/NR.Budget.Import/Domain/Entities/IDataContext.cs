public interface IDataContext
{
    List<Operation?> Operations { get; set; }
    void SaveChanges();
}