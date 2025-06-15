namespace LegoCollectionChecker.GoBricksConverter;

class Program
{
    static void Main(string[] args)
    {
        CsvToXmlConverter.ConvertCsvToXml("../../../Upsilon Missing.csv", "../../../output.xml");
    }
}