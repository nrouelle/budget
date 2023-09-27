using System.Text.Json;

namespace NR.Budget.Import.Data;

public class JsonContext : IDataContext
{
    public List<Operation> Operations { get; set; } = new List<Operation>();
    public void SaveChanges()
    {
        string path = "./accounts.json";
        string json = JsonSerializer.Serialize(Operations);
        
        File.WriteAllText(path, json);
    }
}