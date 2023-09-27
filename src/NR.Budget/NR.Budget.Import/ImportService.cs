using System.Text.RegularExpressions;

namespace NR.Budget.Import;

public class ImportService
{
    public List<Operation> MapFile(List<string> csvLines, bool headers = true)
    {
        // Remove headers
        if(headers)
            csvLines.RemoveAt(0);

        var operations = new List<Operation>();
        
        foreach (var line in csvLines)
        {
            operations.Add(ParseOperation(line));
        }

        return operations;
    }

    private Operation ParseOperation(string line)
    {
        var parsedOperation = line.Split(';');
        var operation = new Operation(
            DateTime.Parse(parsedOperation[0]), 
            CleanDescription(parsedOperation[2]), 
            decimal.Parse(parsedOperation[5]));
        return operation;
    }

    private string CleanDescription(string description)
    {
        string cartePattern = @"CARTE \d{2}\/\d{2}\/\d{2} ";
        string cbPattern = @" CB\*\d{4}";
        description = Regex.Replace(description, cartePattern, string.Empty);
        description = Regex.Replace(description, cbPattern, string.Empty);
        return description.Replace('"',' ').Trim();
    }
}