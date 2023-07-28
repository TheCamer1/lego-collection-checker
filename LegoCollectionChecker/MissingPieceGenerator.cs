using System.Xml.Linq;

internal static class MissingPieceGenerator
{
    public static void GenerateMissingPieces()
    {
        // Load the complete collection
        var completeCollection = CollectionLoader.LoadCollection("../../../CompleteCollection.xml");

        // Process completed models
        foreach (var file in Directory.GetFiles("../../../CompletedModels", "*.xml"))
        {
            var modelPieces = CollectionLoader.LoadCollection(file);
            foreach (var piece in modelPieces)
            {
                if (completeCollection.ContainsKey(piece.Key))
                {
                    completeCollection[piece.Key] -= piece.Value;
                    if (completeCollection[piece.Key] <= 0)
                    {
                        completeCollection.Remove(piece.Key);
                    }
                }
            }
        }

        // Process incomplete models and find missing pieces
        var missingPieces = new Dictionary<string, int>();
        foreach (var file in Directory.GetFiles("../../../IncompleteModels", "*.xml"))
        {
            var modelPieces = CollectionLoader.LoadCollection(file);
            foreach (var piece in modelPieces)
            {
                if (completeCollection.ContainsKey(piece.Key))
                {
                    var availableQty = completeCollection[piece.Key];
                    if (availableQty < piece.Value)
                    {
                        AddToMissingPieces(missingPieces, piece.Key, piece.Value - availableQty);
                    }

                    completeCollection[piece.Key] -= piece.Value;
                    if (completeCollection[piece.Key] <= 0)
                    {
                        completeCollection.Remove(piece.Key);
                    }
                }
                else
                {
                    AddToMissingPieces(missingPieces, piece.Key, piece.Value);
                }
            }
        }

        // Generate the missing pieces XML
        var inventory = new XElement("INVENTORY",
            from piece in missingPieces
            let splitKey = piece.Key.Split(':')
            select new XElement("ITEM",
                new XElement("ITEMTYPE", splitKey[0]),
                new XElement("ITEMID", splitKey[1]),
                new XElement("COLOR", splitKey[2]),
                new XElement("MAXPRICE", "-1.0000"),
                new XElement("MINQTY", piece.Value),
                new XElement("CONDITION", "X"),
                new XElement("NOTIFY", "N")));

        var doc = new XDocument(inventory);
        doc.Save("../../../MissingPieces.xml");
    }

    private static void AddToMissingPieces(Dictionary<string, int> missingPieces, string key, int amount)
    {
        if (missingPieces.ContainsKey(key))
        {
            missingPieces[key] += amount;
        }
        else
        {
            missingPieces.Add(key, amount);
        }
    }
}