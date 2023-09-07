using System.Text;

namespace LegoCollectionChecker;

internal static class PieceLocator
{
    public static void CheckPiece(string itemId, string colorName, bool ignoreColour = false)
    {
        var colourMap = new ColourMap();
        if (!colourMap.ContainsColour(colorName))
        {
            Console.WriteLine($"Unknown color name: {colorName}");
            return;
        }
        var colorId = colourMap.GetIdByName(colorName)!.Value;

        bool isColorInvariant = ignoreColour || ColourInvariantDictionary.InvariantIds.Contains(itemId);
        Console.WriteLine($"Piece {itemId} in {colorName}");
        Console.WriteLine();
        var completeAmount = DisplayModelAmounts(itemId, colorId, isColorInvariant, true);
        Console.WriteLine();
        var incompleteAmount = DisplayModelAmounts(itemId, colorId, isColorInvariant, false);
        Console.WriteLine();
        var collectionAmount = DisplayCompleteCollectionAmounts(itemId, colorName, colorId, isColorInvariant);

        Console.WriteLine();
        var excessAmount = collectionAmount - incompleteAmount - completeAmount;
        if (excessAmount > 0)
        {
            Console.WriteLine($"Excess: {excessAmount}");
        }
        else
        {
            if (incompleteAmount == 0)
            {
                Console.WriteLine($"None left, but no incomplete models require them ({-excessAmount} is the result)");
            }
            else
            {
                Console.WriteLine($"Missing: {-excessAmount}");
            }
        }
    }

    private static int DisplayCompleteCollectionAmounts(string itemId, string colorName, int colorId, bool isColorInvariant)
    {
        var colourMap = new ColourMap();
        // Load the complete collection
        var completeCollection = CollectionLoader.LoadCollection("../../../CompleteCollection.xml");
        // Get the total quantity in the complete collection
        var totalQuantitiesInCollection = CalculateTotalQuantity(itemId, completeCollection, isColorInvariant, colorId);
        Console.WriteLine("Complete Collection:");
        if (isColorInvariant)
        {
            foreach (var entry in totalQuantitiesInCollection)
            {
                var colorNameFromId = colourMap.GetNameById(entry.Key) ?? "Unknown color";
                Console.WriteLine($"{colorNameFromId}: {entry.Value}");
            }
            Console.WriteLine($"Collection Total: {totalQuantitiesInCollection.Values.Sum()}");
        }
        else
        {
            Console.WriteLine($"{colorName}: {(totalQuantitiesInCollection.ContainsKey(colorId) ? totalQuantitiesInCollection[colorId] : 0)}");
        }
        return totalQuantitiesInCollection.Values.Sum();
    }

    private static int DisplayModelAmounts(string itemId, int colorId, bool isColorInvariant, bool isComplete)
    {
        var colourMap = new ColourMap();
        var alternativeIds = AlternativeDictionary.GetAlternativeItemIds(itemId);
        var models = ListModelsContainingPiece(itemId, $"../../../{(isComplete ? "Completed" : "Incomplete")}Models");
        Console.WriteLine($"{(isComplete ? "Complete" : "Incomplete")}:");
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
                    var pieceColorName = colourMap.GetNameById(piece.Color) ?? "Unknown color";
                    colorQuantities.Append($"{pieceColorName}: {piece.Quantity}, ");
                    totalInModels += piece.Quantity;
                    modelQuantity += piece.Quantity;
                }
            }
            if (modelQuantity > 0)
            {
                if (isColorInvariant)
                {
                    Console.WriteLine($"{model.Key.Replace(".xml", "")}: {colorQuantities.ToString().TrimEnd(',', ' ')}");
                }
                else
                {
                    Console.WriteLine($"{model.Key.Replace(".xml", "")}: {modelQuantity}");
                }
            }
        }
        Console.WriteLine($"{(isComplete ? "Complete" : "Incomplete")} Total: {totalInModels}");
        return totalInModels;
    }

    private static Dictionary<int, int> CalculateTotalQuantity(string itemId, Dictionary<string, LegoPiece> completeCollection, bool isColorInvariant, int colorId)
    {
        var alternativeIds = AlternativeDictionary.GetAlternativeItemIds(itemId);
        var totalQuantities = new Dictionary<int, int>();

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
