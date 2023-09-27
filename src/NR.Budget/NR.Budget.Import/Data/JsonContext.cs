using System.Text.Json;

namespace NR.Budget.Import.Data;

public class JsonContext : IDataContext
{
    public List<Operation> Operations { get; set; } = new List<Operation>();
    public void Save(List<Operation> lines)
    {
        string path = "./accounts.json";
        string json = JsonSerializer.Serialize(lines);
        
        File.WriteAllText(path, json);
    }
}