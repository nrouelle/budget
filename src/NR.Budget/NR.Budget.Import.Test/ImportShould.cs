using NR.Budget.Import.Data;

namespace NR.Budget.Import.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShouldImportASingleLineFromCsv()
    {
        var csvData = "2023-09-22;2023-09-22;\"CARTE 21/09/23 RESEAU MISTRAL CB*7767\";\"Non catégorisé\";\"Non catégorisé\";-10,00;;00040265284;PERSO;16310.55";

        var importService = new ImportService();
        var savedData = importService.MapFile(new List<string>() {csvData}, false);

        var expectedData = new BudgetLine(
            new DateTime(2023, 9, 22), 
            "CARTE 21/09/23 RESEAU MISTRAL CB*7767", 
            -10.0m);
        Assert.That(savedData.First(), Is.EqualTo(expectedData));
    }
    
    [Test]
    public void ShouldSaveLineInContext()
    {
        var csvData = "2023-09-22;2023-09-22;\"CARTE 21/09/23 RESEAU MISTRAL CB*7767\";\"Non catégorisé\";\"Non catégorisé\";-10,00;;00040265284;PERSO;16310.55";

        var importService = new ImportService();
        var savedData = importService.MapFile(new List<string>() {csvData}, false);

        var context = new InMemoryContext();
        var bankingService = new BankingService(context);
        bankingService.SaveBankingData(savedData);

        Assert.That(context.Lines.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void ShouldSaveMultipleLineInContextWhenImportFile()
    {
        var context = new InMemoryContext();
        var importService = new ImportService();
        var fileData = File.ReadLines("./files/multiple_lines.txt").ToList();
        var savedData = importService.MapFile(fileData);
        var bankingService = new BankingService(context);
        bankingService.SaveBankingData(savedData);

        Assert.That(context.Lines.Count, Is.EqualTo(5));
    }
    
    [Test]
    public void ShouldSaveImportedDataToJson()
    {
        var context = new JsonContext();
        var importService = new ImportService();
        var fileData = File.ReadLines("./files/multiple_lines.txt").ToList();
        var savedData = importService.MapFile(fileData);
        var bankingService = new BankingService(context);
        bankingService.SaveBankingData(savedData);

        Assert.IsTrue(File.Exists("./accounts.json"));
        // Assert.AreEqual(5, context.Lines.Count);
        // a file is created 
    }
}