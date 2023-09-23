namespace NR.Budget.Import.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShouldImportASingleLineFromCSV()
    {
        var csvData = "2023-09-22;2023-09-22;\"CARTE 21/09/23 RESEAU MISTRAL CB*7767\";\"Non catégorisé\";\"Non catégorisé\";-10,00;;00040265284;PERSO;16310.55";

        var importService = new ImportService();
        var savedData = importService.MapFile(new List<string>() {csvData}, false);

        var expectedData = new BudgetLine(
            new DateTime(2023, 9, 22), 
            "CARTE 21/09/23 RESEAU MISTRAL CB*7767", 
            -10.0m);
        Assert.AreEqual(expectedData, savedData.First());
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

        Assert.AreEqual(1, context.Lines.Count);
    }
    
    [Test]
    public void ShouldSaveMultipleLineInContextWhenImportFile()
    {
        // je passe des données CSV
        // var csvData = "2023-09-22;2023-09-22;\"CARTE 21/09/23 RESEAU MISTRAL CB*7767\";\"Non catégorisé\";\"Non catégorisé\";-10,00;;00040265284;PERSO;16310.55\n2023-09-22;2023-09-22;\"CARTE 21/09/23 NEWREST WAGONS LI CB*7767\";\"Restaurants, bars, discothèques…\";Loisirs;-7,98;;00040265284;PERSO;16310.55\n2023-09-22;;\"E LECLERC TAMARI LA SEYNE SUR FR\";\"Autorisation paiement / retrait en cours\";\"Non catégorisé\";-4,94;;00040265284;PERSO;\n2023-09-21;2023-09-21;\"VIR SEPA HARMONIE MUTUELLE\";\"Remboursements frais de santé\";Santé;7,50;;00040265284;PERSO;16328.53\n2023-09-21;2023-09-21;\"VIR SEPA CPAM RHONE\";\"Remboursements frais de santé\";Santé;17,50;;00040265284;PERSO;16328.53\n";
        // je lance l'import
        var context = new InMemoryContext();
        var importService = new ImportService();
        var fileData = File.ReadLines("./files/multiple_lines.txt").ToList();
        var savedData = importService.MapFile(fileData);
        var bankingService = new BankingService(context);
        bankingService.SaveBankingData(savedData);

        Assert.AreEqual(5, context.Lines.Count);
    }
    
}