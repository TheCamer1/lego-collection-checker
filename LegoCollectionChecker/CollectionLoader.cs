using System.Xml.Linq;

internal static class CollectionLoader
{
    public static Dictionary<string, int> LoadCollection(string filename)
    {
        var doc = XDocument.Load(filename);

        var collection = new Dictionary<string, int>();
        foreach (var item in doc.Root.Elements("ITEM"))
        {
            var itemType = item.Element("ITEMTYPE")?.Value ?? "";
            var itemId = item.Element("ITEMID")?.Value ?? "";
            var color = item.Element("COLOR")?.Value ?? "";
            var qty = int.Parse(item.Element("MINQTY")?.Value ?? "0");

            var key = $"{itemType}:{itemId}:{color}";

            if (collection.ContainsKey(key))
            {
                collection[key] += qty;
            }
            else
            {
                collection[key] = qty;
            }
        }

        return collection;
    }
}