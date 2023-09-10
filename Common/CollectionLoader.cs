using System.Xml.Linq;

namespace LegoCollectionChecker.Common;

public static class CollectionLoader
{
    public static Dictionary<string, LegoPiece> LoadCollection(string filename)
    {
        var doc = XDocument.Load(filename);

        var collection = new Dictionary<string, LegoPiece>();
        foreach (var item in doc.Root!.Elements("ITEM"))
        {
            var haveQuantity = item.Element("QTYFILLED") != null ? 
                int.Parse(item.Element("QTYFILLED")?.Value!) : (int?)null;
            var piece = new LegoPiece(
                item.Element("ITEMTYPE")?.Value ?? "",
                item.Element("ITEMID")?.Value ?? "",
                int.Parse(item.Element("COLOR")?.Value ?? "23"),
                int.Parse(item.Element("MINQTY")?.Value ?? "0"),
                haveQuantity
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