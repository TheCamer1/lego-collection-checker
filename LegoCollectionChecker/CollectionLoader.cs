using System.Xml.Linq;

namespace LegoCollectionChecker;

public static class CollectionLoader
{
    public static Dictionary<string, LegoPiece> LoadCollection(string filename)
    {
        var doc = XDocument.Load(filename);

        var collection = new Dictionary<string, LegoPiece>();
        foreach (var item in doc.Root.Elements("ITEM"))
        {
            var piece = new LegoPiece(
                item.Element("ITEMTYPE")?.Value ?? "",
                item.Element("ITEMID")?.Value ?? "",
                int.Parse(item.Element("COLOR")?.Value ?? "23"),
                int.Parse(item.Element("MINQTY")?.Value ?? "0")
            );

            var key = piece.GetKey();

            if (collection.ContainsKey(key))
            {
                collection[key].Quantity += piece.Quantity;
            }
            else
            {
                collection[key] = piece;
            }
        }

        return collection;
    }
}