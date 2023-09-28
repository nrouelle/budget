using System.Text.Json;
using NR.Budget.Import.Domain.Entities;

namespace NR.Budget.Import.Infrastructure;

public class JsonContext : IDataContext
{
    public List<Operation?> Operations { get; set; } = new List<Operation?>();

    public void SaveChanges()
    {
        string path = "./accounts.json";
        string json = JsonSerializer.Serialize(Operations);
        
        File.WriteAllText(path, json);
    }
}