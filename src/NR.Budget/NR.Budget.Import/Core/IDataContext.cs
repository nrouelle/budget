public interface IDataContext
{
    List<Operation> Operations { get; set; }
    void Save(List<Operation> lines);
}