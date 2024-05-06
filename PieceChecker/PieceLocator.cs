using LegoCollectionChecker.Common;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace LegoCollectionChecker.PieceChecker;

public interface IPieceLocator
{
    string CheckPiece(string itemId, Colour color, bool ignoreColour = false);
    string GetExcess(string itemId, int colorId, bool ignoreColour = false);
    int GetExcess(string itemId, int colorId, StringBuilder sb, bool ignoreColour = false);
}

public class PieceLocator : IPieceLocator
{
    private readonly Dictionary<string, LegoPiece> completeCollection;
    private readonly Dictionary<string, List<LegoPiece>> completeModels;
    private readonly Dictionary<string, List<LegoPiece>> incompleteModels;
    private readonly ColourMap colourMap;

    public PieceLocator()
    {
        var stopwatch = Stopwatch.StartNew();
        completeCollection = CollectionLoader.LoadCollection("../Common/CompleteCollection.xml");
        completeModels = LoadModels("../Common/CompletedModels");
        incompleteModels = LoadModels("../Common/IncompleteModels");
        colourMap = new ColourMap();
        stopwatch.Stop();
        Console.WriteLine($"PieceLocator constructor: {stopwatch.ElapsedMilliseconds} ms");
    }

    private Dictionary<string, List<LegoPiece>> LoadModels(string directory)
    {
        var models = new Dictionary<string, List<LegoPiece>>();
        var files = Directory.GetFiles(directory, "*.xml");

        foreach (var file in files)
        {
            var modelPieces = CollectionLoader.LoadCollection(file);
            models.Add(Path.GetFileName(file), modelPieces.Values.ToList());
        }

        return models;
    }

    public string CheckPiece(string itemId, Colour color, bool ignoreColour = false)
    {
        var stopwatch = Stopwatch.StartNew();
        if (!colourMap.ContainsColour(color))
        {
            throw new InvalidOperationException($"Unknown colour name: {color}");
        }
        var colorId = colourMap.GetIdByEnum(color)!.Value;
        var result = GetExcess(itemId, colorId, ignoreColour);
        stopwatch.Stop();
        Console.WriteLine($"CheckPiece: {stopwatch.ElapsedMilliseconds} ms");
        return result;
    }

    public string GetExcess(string itemId, int colorId, bool ignoreColour = false)
    {
        var stopwatch = Stopwatch.StartNew();
        var sb = new StringBuilder();

        GetExcess(itemId, colorId, sb, ignoreColour);

        var color = colourMap.GetEnumById(colorId);
        sb.Insert(0, $"Piece {itemId} in {color}\r\n\r\n");

        stopwatch.Stop();
        Console.WriteLine($"GetExcess: {stopwatch.ElapsedMilliseconds} ms");
        return sb.ToString();
    }

    public int GetExcess(string itemId, int colorId, StringBuilder sb, bool ignoreColour = false)
    {
        var stopwatch = Stopwatch.StartNew();
        var name = colourMap.GetNameById(colorId);

        sb.AppendLine();
        var collectionAmounts = DisplayCompleteCollectionAmounts(itemId, name!, colorId, ignoreColour, sb);
        sb.AppendLine();
        var incompleteAmounts = DisplayModelAmounts(itemId, colorId, ignoreColour, false, sb);
        sb.AppendLine();
        var completeAmounts = DisplayModelAmounts(itemId, colorId, ignoreColour, true, sb);

        sb.AppendLine();
        int result;
        if (ignoreColour)
        {
            result = PrintMissingByColour(completeAmounts, incompleteAmounts, collectionAmounts, sb);
        }
        else
        {
            result = PrintMissing(colorId, completeAmounts, incompleteAmounts, collectionAmounts, sb);
        }
        stopwatch.Stop();
        Console.WriteLine($"GetExcess (inner): {stopwatch.ElapsedMilliseconds} ms");
        return result;
    }

    private int PrintMissing(
        int colorId,
        Dictionary<int, int> completeAmounts,
        Dictionary<int, int> incompleteAmounts,
        Dictionary<int, int> collectionAmounts,
        StringBuilder sb)
    {
        int incomplete = incompleteAmounts.Values.Sum();
        int complete = completeAmounts.Values.Sum();
        var excessAmount = collectionAmounts.Values.Sum() - incomplete - complete;
        if (excessAmount > 0)
        {
            sb.Insert(0, $"Excess: {excessAmount}\r\n");
        }
        else
        {
            if (!incompleteAmounts.ContainsKey(colorId) || incompleteAmounts[colorId] == 0)
            {
                sb.Insert(0, $"None left, but no incomplete models require them ({-excessAmount} is the result)\r\n");
            }
            else
            {
                sb.Insert(0, $"Missing: {Math.Min(-excessAmount, incomplete)}\r\n");
            }
        }
        return excessAmount;
    }

    private int PrintMissingByColour(
        Dictionary<int, int> completeAmounts,
        Dictionary<int, int> incompleteAmounts,
        Dictionary<int, int> collectionAmounts,
        StringBuilder sb)
    {
        var total = 0;
        var allUsedList = new List<string>();
        var excessList = new List<string>();
        var missingList = new List<string>();

        // Combine all the colour keys from the three dictionaries into one HashSet
        var allColours = new HashSet<int>(completeAmounts.Keys);
        allColours.UnionWith(incompleteAmounts.Keys);
        allColours.UnionWith(collectionAmounts.Keys);

        // Iterate over all colours to identify missing and excess pieces
        foreach (var colourId in allColours)
        {
            var colourName = colourMap.GetNameById(colourId) ?? "Unknown colour";
            var completeAmount = completeAmounts.GetValueOrDefault(colourId, 0);
            var incompleteAmount = incompleteAmounts.GetValueOrDefault(colourId, 0);
            var collectionAmount = collectionAmounts.GetValueOrDefault(colourId, 0);

            var excessAmount = collectionAmount - incompleteAmount - completeAmount;

            if (excessAmount < 0)
            {
                var requiredAmount = Math.Min(-excessAmount, incompleteAmount);
                missingList.Add($"{colourName} Missing: {requiredAmount}");
                total -= requiredAmount;
            }
            else if (excessAmount > 0)
            {
                excessList.Add($"{colourName} Excess: {excessAmount}");
                total += excessAmount;
            }
            else
            {
                allUsedList.Add($"{colourName} All Used: 0");
            }
        }

        missingList.Sort();
        excessList.Sort();
        allUsedList.Sort();

        foreach (var entry in missingList)
        {
            sb.Insert(0, entry + "\r\n");
        }
        foreach (var entry in excessList)
        {
            sb.Insert(0, entry + "\r\n");
        }
        foreach (var entry in allUsedList)
        {
            sb.Insert(0, entry + "\r\n");
        }

        if (total < 0)
        {
            sb.Insert(0, $"MISSING TOTAL: {-total}\r\n");
        }
        else
        {
            sb.Insert(0, $"EXCESS TOTAL: {total}\r\n");
        }
        return total;
    }

    private Dictionary<int, int> DisplayCompleteCollectionAmounts(
        string itemId,
        string colorName,
        int colorId,
        bool isColorInvariant,
        StringBuilder sb)
    {
        // Get the total quantity in the complete collection
        var totalQuantitiesInCollection = CalculateTotalQuantity(itemId, isColorInvariant, colorId);
        sb.AppendLine("Complete Collection:");

        if (isColorInvariant)
        {
            var sortedColours = totalQuantitiesInCollection.Keys.OrderBy(id => colourMap.GetNameById(id));

            // Iterate over sorted colours to display their quantities
            foreach (var colourId in sortedColours)
            {
                var colourName = colourMap.GetNameById(colourId) ?? "Unknown color";
                sb.AppendLine($"{colourName}: {totalQuantitiesInCollection[colourId]}");
            }

            sb.AppendLine($"Collection Total: {totalQuantitiesInCollection.Values.Sum()}");
        }
        else
        {
            sb.AppendLine($"{colorName}: {totalQuantitiesInCollection.GetValueOrDefault(colorId, 0)}");
        }

        return totalQuantitiesInCollection;
    }

    private Dictionary<int, int> DisplayModelAmounts(string itemId, int colorId, bool isColorInvariant, bool isComplete, StringBuilder sb)
    {
        var stopwatch = Stopwatch.StartNew();
        var alternativeIds = AlternativeDictionary.GetAlternativeItemIds(itemId);
        var models = isComplete ? completeModels : incompleteModels;
        sb.AppendLine($"{(isComplete ? "Complete" : "Incomplete")}:");

        int totalInModels = 0;
        Dictionary<int, int> colourTotals = new Dictionary<int, int>();

        foreach (var model in models)
        {
            int modelQuantity = 0;
            var colorQuantities = new StringBuilder();

            foreach (var piece in model.Value)
            {
                if (alternativeIds.Contains(piece.ItemId) && (piece.Color == colorId || isColorInvariant))
                {
                    var pieceColorName = colourMap.GetNameById(piece.Color) ?? "Unknown color";
                    colorQuantities.Append($"{pieceColorName}: {piece.Quantity}, ");

                    totalInModels += piece.Quantity;
                    modelQuantity += piece.Quantity;

                    colourTotals.TryGetValue(piece.Color, out int currentTotal);
                    colourTotals[piece.Color] = currentTotal + piece.Quantity;
                }
            }

            if (modelQuantity > 0)
            {
                var modelName = Path.GetFileNameWithoutExtension(model.Key);
                if (isColorInvariant)
                {
                    sb.AppendLine($"{modelName}: {colorQuantities.ToString().TrimEnd(',', ' ')}");
                }
                else
                {
                    sb.AppendLine($"{modelName}: {modelQuantity}");
                }
            }
        }

        sb.AppendLine();

        // Print individual colour totals in alphabetical order
        if (isColorInvariant)
        {
            var sortedColours = colourTotals.Keys.OrderBy(id => colourMap.GetNameById(id));

            foreach (var colourId in sortedColours)
            {
                var colourName = colourMap.GetNameById(colourId) ?? "Unknown color";
                sb.AppendLine($"{colourName}: {colourTotals[colourId]}");
            }
        }

        sb.AppendLine($"{(isComplete ? "Completed" : "Incomplete")} Total: {totalInModels}");

        stopwatch.Stop();
        Console.WriteLine($"DisplayModelAmounts: {stopwatch.ElapsedMilliseconds} ms");
        return colourTotals;
    }

    private Dictionary<int, int> CalculateTotalQuantity(
        string itemId,
        bool isColorInvariant,
        int colorId)
    {
        var alternativeIds = AlternativeDictionary.GetAlternativeItemIds(itemId);
        var totalQuantities = new Dictionary<int, int>();

        foreach (var altId in alternativeIds)
        {
            foreach (var piece in completeCollection.Values)
            {
                if (piece.ItemId == altId && (isColorInvariant || piece.Color == colorId))
                {
                    totalQuantities.TryGetValue(piece.Color, out int currentQuantity);
                    totalQuantities[piece.Color] = currentQuantity + piece.Quantity;
                }
            }
        }

        return totalQuantities;
    }
}