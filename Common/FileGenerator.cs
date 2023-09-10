using System.Xml.Linq;

namespace LegoCollectionChecker.Common;

public static class FileGenerator
{
    public static void GenerateFile(IEnumerable<LegoPiece> pieces, string fileName)
    {
        // Generate the missing pieces XML
        var inventory = new XElement("INVENTORY",
            from piece in pieces
            select new XElement("ITEM",
                new XElement("ITEMTYPE", piece.ItemType),
                new XElement("ITEMID", piece.ItemId),
                new XElement("COLOR", piece.Color),
                new XElement("MAXPRICE", "-1.0000"),
                new XElement("MINQTY", piece.Quantity),
                new XElement("CONDITION", "X"),
                new XElement("NOTIFY", "N")));

        var doc = new XDocument(inventory);
        doc.Save(fileName);
    }
}
