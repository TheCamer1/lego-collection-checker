namespace LegoCollectionChecker.GoBricksConverter;

class Program
{
    static void Main(string[] args)
    {
        CsvToXmlConverter.ConvertCsvToXml("../../../All Missing.csv", "../../../output.xml");
    }
}