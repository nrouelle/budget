namespace NR.Budget.Import;

public class ImportService
{
    public List<BudgetLine> MapFile(List<string> csvDatas, bool headers = true)
    {
        // Remove headers
        if(headers)
            csvDatas.RemoveAt(0);

        var list = new List<BudgetLine>();
        
        foreach (var data in csvDatas)
        {
            list.Add(ParseCsvLine(data));
        }

        return list;
    }

    private BudgetLine ParseCsvLine(string line)
    {
        var parsedLine = line.Split(';');
        var budgetData = new BudgetLine(
            DateTime.Parse(parsedLine[0]), 
            parsedLine[2].Replace('"',' ').Trim(), 
            decimal.Parse(parsedLine[5]));
        return budgetData;
    }
}