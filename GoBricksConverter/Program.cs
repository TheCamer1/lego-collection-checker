namespace LegoCollectionChecker.GoBricksConverter;

class Program
{
    static void Main(string[] args)
    {
        CsvToXmlConverter.ConvertCsvToXml("../../../Parts 2025-01-08.csv", "../../../output.xml");
    }
}