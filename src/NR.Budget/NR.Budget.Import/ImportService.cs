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
            parsedOperation[2].Replace('"',' ').Trim(), 
            decimal.Parse(parsedOperation[5]));
        return operation;
    }
}