using System.Text.Json;

namespace NR.Budget.Import.Data;

public class JsonContext : IDataContext
{
    public List<BudgetLine> Lines { get; set; } = new List<BudgetLine>();
    public void Save(List<BudgetLine> lines)
    {
        string path = "./accounts.json";
        string json = JsonSerializer.Serialize(lines);
        
        File.WriteAllText(path, json);
    }
}