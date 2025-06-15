using CsvHelper.Configuration.Attributes;

namespace LegoCollectionChecker.GoBricksConverter;

public class CsvRecord
{
    [Name("Part")]
    public string Part { get; set; } = "";

    [Name("Color")]
    public string Color { get; set; } = "";

    [Name("Quantity")]
    public int Quantity { get; set; }

    [Name("Gobrick Part")]
    public string GobrickPart { get; set; } = "";

    [Name("Gobrick Color")]
    public string GobrickColor { get; set; } = "";
}