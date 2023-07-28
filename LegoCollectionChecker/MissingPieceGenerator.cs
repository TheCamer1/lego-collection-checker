using System.Xml.Linq;

namespace LegoCollectionChecker;

public static class MissingPieceGenerator
{
    public static readonly List<string> _disallowedColours = new()
    {
        "Red",
        "Blue",
        "Yellow",
        "Lime",
        "Dark Purple",
        "Lavendar"
    };

    public static void GenerateMissingPieces()
    {
        var completeCollection = CollectionLoader.LoadCollection("../../../CompleteCollection.xml");

        // process completed models
        foreach (var file in Directory.GetFiles("../../../CompletedModels", "*.xml"))
        {
            var modelPieces = CollectionLoader.LoadCollection(file);
            foreach (var piece in modelPieces.Values)
            {
                UsePieceInCollection(piece, completeCollection);
            }
        }

        // Process incomplete models and find missing pieces
        var missingPieces = new Dictionary<string, LegoPiece>();
        foreach (var file in Directory.GetFiles("../../../IncompleteModels", "*.xml"))
        {
            var modelPieces = CollectionLoader.LoadCollection(file);
            foreach (var piece in modelPieces.Values)
            {
                var availableQty = GetTotalAvailableQty(piece, completeCollection);

                if (availableQty < piece.Quantity)
                {
                    AddToMissingPieces(missingPieces, piece, piece.Quantity - availableQty);
                }

                UsePieceInCollection(piece, completeCollection);
            }
        }

        // Generate the missing pieces XML
        var inventory = new XElement("INVENTORY",
            from piece in missingPieces.Values
            where !ShouldExcludePiece(piece)
            select new XElement("ITEM",
                new XElement("ITEMTYPE", piece.ItemType),
                new XElement("ITEMID", piece.ItemId),
                new XElement("COLOR", piece.Color),
                new XElement("MAXPRICE", "-1.0000"),
                new XElement("MINQTY", piece.Quantity),
                new XElement("CONDITION", "X"),
                new XElement("NOTIFY", "N")));

        var doc = new XDocument(inventory);
        doc.Save("../../../MissingPieces.xml");
    }

    private static bool ShouldExcludePiece(LegoPiece piece)
    {
        var colorDict = ColourDictionary.ColorNameToId;
        
        if (ColourExclusionDictionary.ExclusionIds.Contains(piece.ItemId)
            && (_disallowedColours.Select(e => ColourDictionary.ColorNameToId[e]).Contains(piece.Color)))
        {
            return true;
        }
        return false;
    }

    private static void UsePieceInCollection(LegoPiece piece, Dictionary<string, LegoPiece> collection)
    {
        var alternativeIds = AlternativeDictionary.GetAlternativeItemIds(piece.ItemId);

        foreach (var altId in alternativeIds)
        {
            var keyToFind = new LegoPiece("P", altId, piece.Color, 0).GetKey();

            if (collection.ContainsKey(keyToFind))
            {
                var usageQty = Math.Min(collection[keyToFind].Quantity, piece.Quantity);

                collection[keyToFind].Quantity -= usageQty;
                piece.Quantity -= usageQty;

                if (collection[keyToFind].Quantity <= 0)
                {
                    collection.Remove(keyToFind);
                }

                if (piece.Quantity <= 0)
                {
                    break;
                }
            }
        }
    }

    private static int GetTotalAvailableQty(LegoPiece piece, Dictionary<string, LegoPiece> collection)
    {
        var alternativeIds = AlternativeDictionary.GetAlternativeItemIds(piece.ItemId);
        int availableQty = 0;

        if (ColourInvariantDictionary.InvariantIds.Contains(piece.ItemId))
        {
            foreach (var key in collection.Keys)
            {
                var currentPiece = collection[key];
                if (alternativeIds.Contains(currentPiece.ItemId))
                {
                    availableQty += currentPiece.Quantity;
                }
            }
        }
        else
        {
            foreach (var altId in alternativeIds)
            {
                var keyToFind = new LegoPiece("P", altId, piece.Color, 0).GetKey();

                if (collection.ContainsKey(keyToFind))
                {
                    availableQty += collection[keyToFind].Quantity;
                }
            }
        }

        return availableQty;
    }

    private static void AddToMissingPieces(Dictionary<string, LegoPiece> missingPieces, LegoPiece piece, int amount)
    {
        var key = piece.GetKey();
        if (ColourInvariantDictionary.InvariantIds.Contains(piece.ItemId))
        {
            key = $"P:{piece.ItemId}";
        }

        if (missingPieces.ContainsKey(key))
        {
            missingPieces[key].Quantity += amount;
        }
        else
        {
            missingPieces[key] = new LegoPiece(piece.ItemType, piece.ItemId, piece.Color, amount);
        }
    }
}