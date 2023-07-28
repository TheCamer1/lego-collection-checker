using System.Text;

namespace LegoCollectionChecker;

internal static class PieceLocator
{
    public static void CheckPiece(string itemId, string colorName)
    {
        if (!ColourDictionary.ColorNameToId.TryGetValue(colorName, out var colorId))
        {
            Console.WriteLine($"Unknown color name: {colorName}");
            return;
        }

        bool isColorInvariant = ColourInvariantDictionary.InvariantIds.Contains(itemId);

        DisplayModelAmounts(itemId, colorName, colorId, isColorInvariant, true);
        Console.WriteLine();
        DisplayModelAmounts(itemId, colorName, colorId, isColorInvariant, false);
        Console.WriteLine();
        DisplayCompleteCollectionAmounts(itemId, colorName, colorId, isColorInvariant);
    }

    private static void DisplayCompleteCollectionAmounts(string itemId, string colorName, string colorId, bool isColorInvariant)
    {
        // Load the complete collection
        var completeCollection = CollectionLoader.LoadCollection("../../../CompleteCollection.xml");
        // Get the total quantity in the complete collection
        var totalQuantitiesInCollection = CalculateTotalQuantity(itemId, completeCollection, isColorInvariant, colorId);
        Console.WriteLine("Total quantities in complete collection:");
        if (isColorInvariant)
        {
            foreach (var entry in totalQuantitiesInCollection)
            {
                var colorNameFromId = ColourDictionary.ColorIdToName.ContainsKey(entry.Key) ? ColourDictionary.ColorIdToName[entry.Key] : "Unknown color";
                Console.WriteLine($"{colorNameFromId}: {entry.Value}");
            }
        }
        else
        {
            Console.WriteLine($"{colorName}: {(totalQuantitiesInCollection.ContainsKey(colorId) ? totalQuantitiesInCollection[colorId] : 0)}");
        }
    }

    private static void DisplayModelAmounts(string itemId, string colorName, string colorId, bool isColorInvariant, bool isComplete)
    {
        var alternativeIds = AlternativeDictionary.GetAlternativeItemIds(itemId);
        var models = ListModelsContainingPiece(itemId, $"../../../{(isComplete ? "Completed" : "Incomplete")}Models");
        Console.WriteLine($"The piece with ITEMID={itemId} and COLOR={colorName} is in the following {(isComplete ? "complete" : "incomplete")} models:");
        int totalInModels = 0;
        foreach (var model in models)
        {
            int modelQuantity = 0;
            StringBuilder colorQuantities = new();
            foreach (var piece in model.Value)
            {
                // Check whether the ItemId of the current piece matches the original ItemId or any of its alternative Ids
                if (alternativeIds.Contains(piece.ItemId) && (piece.Color == colorId || isColorInvariant))
                {
                    var pieceColorName = ColourDictionary.ColorIdToName.ContainsKey(piece.Color)
                        ? ColourDictionary.ColorIdToName[piece.Color]
                        : "Unknown color";
                    colorQuantities.Append($"{pieceColorName}: {piece.Quantity}, ");
                    totalInModels += piece.Quantity;
                    modelQuantity += piece.Quantity;
                }
            }
            if (modelQuantity > 0)
            {
                if (isColorInvariant)
                {
                    Console.WriteLine($"{model.Key}: {colorQuantities.ToString().TrimEnd(',', ' ')}");
                }
                else
                {
                    Console.WriteLine($"{model.Key}: {modelQuantity}");
                }
            }
        }
        Console.WriteLine($"Total quantity in {(isComplete ? "complete" : "incomplete")} models: {totalInModels}");
    }

    private static Dictionary<string, int> CalculateTotalQuantity(string itemId, Dictionary<string, LegoPiece> completeCollection, bool isColorInvariant, string colorId)
    {
        var alternativeIds = AlternativeDictionary.GetAlternativeItemIds(itemId);
        var totalQuantities = new Dictionary<string, int>();

        foreach (var altId in alternativeIds)
        {
            foreach (var pair in completeCollection)
            {
                var piece = pair.Value;
                if (piece.ItemId != altId)
                {
                    continue;
                }
                if (!isColorInvariant && piece.Color != colorId)
                {
                    continue;
                }
                if (totalQuantities.ContainsKey(piece.Color))
                {
                    totalQuantities[piece.Color] += piece.Quantity;
                }
                else
                {
                    totalQuantities[piece.Color] = piece.Quantity;
                }
            }
        }

        return totalQuantities;
    }


    public static Dictionary<string, List<LegoPiece>> ListModelsContainingPiece(string itemId, string location)
    {
        var modelsContainingPiece = new Dictionary<string, List<LegoPiece>>();
        var alternativeIds = AlternativeDictionary.GetAlternativeItemIds(itemId);

        foreach (var file in Directory.GetFiles(location, "*.xml"))
        {
            var modelPieces = CollectionLoader.LoadCollection(file);
            foreach (var altId in alternativeIds)
            {
                var matchingPieces = modelPieces.Values.Where(piece => piece.ItemId == altId).ToList();

                if (matchingPieces.Count > 0)
                {
                    var filename = Path.GetFileName(file);
                    if (modelsContainingPiece.ContainsKey(filename))
                    {
                        modelsContainingPiece[filename].AddRange(matchingPieces);
                    }
                    else
                    {
                        modelsContainingPiece.Add(filename, matchingPieces);
                    }
                }
            }
        }

        return modelsContainingPiece;
    }
}
