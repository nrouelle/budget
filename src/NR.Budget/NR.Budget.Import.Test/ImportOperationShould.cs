using NR.Budget.Import.Domain.Entities;
using NR.Budget.Import.Domain.Services;
using NR.Budget.Import.Infrastructure;
using NUnit.Framework.Constraints;

namespace NR.Budget.Import.Test;

public class Tests
{
    private const string ImportSampleFilePath = "./files/multiple_lines.txt";

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ImportASingleLineFromCsv()
    {
        var csvData = "2023-09-22;2023-09-22;\"CARTE 21/09/23 RESEAU MISTRAL CB*7767\";\"Non catégorisé\";\"Non catégorisé\";-10,00;;00040265284;PERSO;16310.55";

        var importService = new ImportService();
        var savedData = importService.MapFile(new List<string>() {csvData}, false);

        var expectedData = new Depense(
            new DateTime(2023, 9, 22), 
            "RESEAU MISTRAL", 
            10.0f);
        Assert.That(savedData.First(), Is.EqualTo(expectedData));
    }
    
    [Test]
    public void ImportOperationInContext()
    {
        var csvData = "2023-09-22;2023-09-22;\"CARTE 21/09/23 RESEAU MISTRAL CB*7767\";\"Non catégorisé\";\"Non catégorisé\";-10,00;;00040265284;PERSO;16310.55";

        var importService = new ImportService();
        var importedData = importService.MapFile(new List<string>() {csvData}, false);

        var context = new InMemoryContext();
        var operationRepository = new OperationPersistenceAdapter(context);
        var operationService = new OperationService(operationRepository);
        operationService.ImportOperations(importedData);

        Assert.That(context.Operations.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void ImportMultipleLineInContextWhenImportFile()
    {
        var context = new InMemoryContext();
        var importService = new ImportService();
        var fileData = File.ReadLines(ImportSampleFilePath).ToList();
        var savedData = importService.MapFile(fileData);
        
        var operationRepository = new OperationPersistenceAdapter(context);
        var operationService = new OperationService(operationRepository);
        operationService.ImportOperations(savedData);

        Assert.That(context.Operations.Count, Is.EqualTo(5));
    }
    
    [Test]
    public void SaveImportedDataToJson()
    {
        var context = new JsonContext();
        var importService = new ImportService();
        var fileData = File.ReadLines(ImportSampleFilePath).ToList();
        var savedData = importService.MapFile(fileData);
        
        var operationRepository = new OperationPersistenceAdapter(context);
        var operationService = new OperationService(operationRepository);
        operationService.ImportOperations(savedData);

        Assert.IsTrue(File.Exists("./accounts.json"));
    }

    [Test]
    public void CleanOperationDescriptionBeforeSaving()
    {
        var csvData = "2023-09-22;2023-09-22;\"CARTE 21/09/23 RESEAU MISTRAL CB*7767\";\"Non catégorisé\";\"Non catégorisé\";-10,00;;00040265284;PERSO;16310.55";

        var importService = new ImportService();
        var operations = importService.MapFile(new List<string>() {csvData}, false); 
        
        var context = new InMemoryContext();
        var operationRepository = new OperationPersistenceAdapter(context);
        var operationService = new OperationService(operationRepository);
        
        var operationsImported = operationService.ImportOperations(operations).ToList();

        Assert.That(operationsImported.Count(), Is.EqualTo(1));
        Assert.That(operationsImported[0].Description, Is.EqualTo("RESEAU MISTRAL"));
    }
}