public interface IDataContext
{
    List<BudgetLine> Lines { get; set; }
    void Save(List<BudgetLine> lines);
}