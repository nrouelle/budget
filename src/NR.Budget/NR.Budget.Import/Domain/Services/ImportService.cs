using System.Text.RegularExpressions;
using NR.Budget.Import.Domain.Entities;

namespace NR.Budget.Import.Domain.Services;

public class ImportService
{
    public List<Operation?> MapFile(List<string> csvLines, bool headers = true)
    {
        // Remove headers
        if (headers)
            csvLines.RemoveAt(0);

        var operations = new List<Operation?>();

        foreach (var line in csvLines)
        {
            operations.Add(ParseOperation(line));
        }

        return operations;
    }

    private Operation? ParseOperation(string line)
    {
        var parsedOperation = line.Split(';');
        var operationDate = DateTime.Parse(parsedOperation[0]);
        var amount = float.Parse(parsedOperation[5]);
        return amount switch
        {
            > 0 => new Revenu(operationDate, CleanDescription(parsedOperation[2]), Math.Abs(amount)),
            < 0 => new Depense(operationDate, CleanDescription(parsedOperation[2]), Math.Abs(amount)),
            _ => null
        };
    }

    private string CleanDescription(string description)
    {
        const string cartePattern = @"CARTE \d{2}\/\d{2}\/\d{2} ";
        const string cbPattern = @" CB\*\d{4}";
        const string virementSepaPattern = @"VIR SEPA ";
        description = Regex.Replace(description, cartePattern, string.Empty);
        description = Regex.Replace(description, cbPattern, string.Empty);
        description = Regex.Replace(description, virementSepaPattern, string.Empty);
        return description.Replace('"', ' ').Trim();
    }
}