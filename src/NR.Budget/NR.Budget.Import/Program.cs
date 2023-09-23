// See https://aka.ms/new-console-template for more information

using System.Xml.Serialization;

var fileContent = File.ReadAllLines(args[0]);
var datas = new List<BankingCsv>();
foreach (var line in fileContent)
{
    var bkData = ImportBudgetLine(line);
    datas.Add(bkData);
    
    BankingCsv ImportBudgetLine(string budgetLine)
    {
        var parsedLine = budgetLine.Split(';');
        var bankingData = new BankingCsv(
            DateTime.Parse(parsedLine[0]), 
            parsedLine[2].Replace('"',' ').Trim(), 
            decimal.Parse(parsedLine[5]));
        return bankingData;
    }
}