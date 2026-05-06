using LegoCollectionChecker.Common;

namespace LegoCollectionChecker.GoBricksConverter;

class Program
{
    static void Main(string[] args)
    {
        CsvToXmlConverter.ConvertCsvToXml(
            RepoPaths.Project("GoBricksConverter", "Parts 2025-01-08.csv"),
            RepoPaths.Project("GoBricksConverter", "output.xml"));
    }
}