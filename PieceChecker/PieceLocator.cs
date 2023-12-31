﻿using LegoCollectionChecker.Common;
using System.Text;

namespace LegoCollectionChecker.PieceChecker;

public static class PieceLocator
{
    public static void CheckPiece(string itemId, Colour color, bool ignoreColour = false)
    {
        var completeCollection = CollectionLoader.LoadCollection("../../../../Common/CompleteCollection.xml");
        var colourMap = new ColourMap();
        if (!colourMap.ContainsColour(color))
        {
            throw new InvalidOperationException($"Unknown colour name: {color}");
        }
        var colorId = colourMap.GetIdByEnum(color)!.Value;
        GetExcess(completeCollection, itemId, colorId, ignoreColour);
    }

    public static int GetExcess(Dictionary<string, LegoPiece> completeCollection, string itemId, int colorId, bool ignoreColour = false)
    {
        var colourMap = new ColourMap();
        var name = colourMap.GetNameById(colorId);
        var color = colourMap.GetEnumById(colorId);

        Console.WriteLine($"Piece {itemId} in {color}");
        Console.WriteLine();
        var completeAmounts = DisplayModelAmounts(itemId, colorId, ignoreColour, true);
        Console.WriteLine();
        var incompleteAmounts = DisplayModelAmounts(itemId, colorId, ignoreColour, false);
        Console.WriteLine();
        var collectionAmounts = DisplayCompleteCollectionAmounts(itemId, name!, colorId, ignoreColour, completeCollection);

        Console.WriteLine();
        if (ignoreColour)
        {
            return PrintMissingByColour(colourMap, completeAmounts, incompleteAmounts, collectionAmounts);
        }
        else
        {
            return PrintMissing(colorId, completeAmounts, incompleteAmounts, collectionAmounts);
        }
    }

    private static int PrintMissing(
        int colorId,
        Dictionary<int, int> completeAmounts,
        Dictionary<int, int> incompleteAmounts,
        Dictionary<int, int> collectionAmounts)
    {
        int incomplete = incompleteAmounts.Values.Sum();
        int complete = completeAmounts.Values.Sum();
        var excessAmount = collectionAmounts.Values.Sum() - incomplete - complete;
        if (excessAmount > 0)
        {
            Console.WriteLine($"Excess: {excessAmount}");
        }
        else
        {
            if (!incompleteAmounts.ContainsKey(colorId) || incompleteAmounts[colorId] == 0)
            {
                Console.WriteLine($"None left, but no incomplete models require them ({-excessAmount} is the result)");
            }
            else
            {
                Console.WriteLine($"Missing: {Math.Min(-excessAmount, incomplete)}");
            }
        }
        return excessAmount;
    }

    private static int PrintMissingByColour(
        ColourMap colourMap,
        Dictionary<int, int> completeAmounts,
        Dictionary<int, int> incompleteAmounts,
        Dictionary<int, int> collectionAmounts)
    {
        var total = 0;
        var allUsedList = new List<string>();
        var excessList = new List<string>();
        var missingList = new List<string>();

        // Combine all the colour keys from the three dictionaries into one HashSet
        var allColours = new HashSet<int>(completeAmounts.Keys);
        allColours.UnionWith(incompleteAmounts.Keys);
        allColours.UnionWith(collectionAmounts.Keys);

        // Create a list of tuples containing the colour name and ID, and sort it
        var sortedColours = allColours
            .Select(id => (Name: colourMap.GetNameById(id) ?? "Unknown colour", Id: id))
            .OrderBy(tuple => tuple.Name)
            .ToList();

        // Iterate over sorted colours to identify missing and excess pieces
        foreach (var (colourName, colourId) in sortedColours)
        {
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

        foreach (var entry in allUsedList.OrderBy(s => s))
        {
            Console.WriteLine(entry);
        }
        foreach (var entry in excessList.OrderBy(s => s))
        {
            Console.WriteLine(entry);
        }
        foreach (var entry in missingList.OrderBy(s => s))
        {
            Console.WriteLine(entry);
        }

        if (total < 0)
        {
            Console.WriteLine($"MISSING TOTAL: {-total}");
        }
        else
        {
            Console.WriteLine($"EXCESS TOTAL: {total}");
        }
        return total;
    }

    private static Dictionary<int, int> DisplayCompleteCollectionAmounts(
        string itemId,
        string colorName,
        int colorId,
        bool isColorInvariant,
        Dictionary<string, LegoPiece> completeCollection)
    {
        var colourMap = new ColourMap();
        // Get the total quantity in the complete collection
        var totalQuantitiesInCollection = CalculateTotalQuantity(itemId, completeCollection, isColorInvariant, colorId);
        Console.WriteLine("Complete Collection:");

        if (isColorInvariant)
        {
            // Create a list of tuples containing the colour name and ID, and sort it
            var sortedColours = totalQuantitiesInCollection.Keys
                .Select(id => (Name: colourMap.GetNameById(id) ?? "Unknown color", Id: id))
                .OrderBy(tuple => tuple.Name)
                .ToList();

            // Iterate over sorted colours to display their quantities
            foreach (var (colourName, colourId) in sortedColours)
            {
                Console.WriteLine($"{colourName}: {totalQuantitiesInCollection[colourId]}");
            }

            Console.WriteLine($"Collection Total: {totalQuantitiesInCollection.Values.Sum()}");
        }
        else
        {
            Console.WriteLine($"{colorName}: {(totalQuantitiesInCollection.ContainsKey(colorId) ? totalQuantitiesInCollection[colorId] : 0)}");
        }

        return totalQuantitiesInCollection;
    }

    private static Dictionary<int, int> DisplayModelAmounts(string itemId, int colorId, bool isColorInvariant, bool isComplete)
    {
        var colourMap = new ColourMap();
        var alternativeIds = AlternativeDictionary.GetAlternativeItemIds(itemId);
        var models = ListModelsContainingPiece(itemId, $"../../../../Common/{(isComplete ? "Completed" : "Incomplete")}Models");
        Console.WriteLine($"{(isComplete ? "Complete" : "Incomplete")}:");

        int totalInModels = 0;
        Dictionary<int, int> colourTotals = new(); // To keep track of individual colour totals

        foreach (var model in models)
        {
            int modelQuantity = 0;
            StringBuilder colorQuantities = new StringBuilder();

            foreach (var piece in model.Value)
            {
                if (alternativeIds.Contains(piece.ItemId) && (piece.Color == colorId || isColorInvariant))
                {
                    var pieceColorName = colourMap.GetNameById(piece.Color) ?? "Unknown color";
                    colorQuantities.Append($"{pieceColorName}: {piece.Quantity}, ");

                    totalInModels += piece.Quantity;
                    modelQuantity += piece.Quantity;

                    // Sum up the amounts per colour
                    if (colourTotals.ContainsKey(piece.Color))
                    {
                        colourTotals[piece.Color] += piece.Quantity;
                    }
                    else
                    {
                        colourTotals[piece.Color] = piece.Quantity;
                    }
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

        Console.WriteLine();
        // Print individual colour totals in alphabetical order
        if (isColorInvariant)
        {
            var sortedColours = colourTotals.Keys
                .Select(id => (Name: colourMap.GetNameById(id) ?? "Unknown color", Id: id))
                .OrderBy(tuple => tuple.Name)
                .ToList();

            foreach (var (colourName, colourId) in sortedColours)
            {
                Console.WriteLine($"{colourName}: {colourTotals[colourId]}");
            }
        }

        Console.WriteLine($"{(isComplete ? "Completed" : "Incomplete")} Total: {totalInModels}");

        return colourTotals;
    }


    private static Dictionary<int, int> CalculateTotalQuantity(
        string itemId,
        Dictionary<string, LegoPiece> completeCollection,
        bool isColorInvariant,
        int colorId)
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
