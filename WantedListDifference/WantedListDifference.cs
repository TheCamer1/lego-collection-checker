using LegoCollectionChecker.Common;

namespace LegoCollectionChecker.WantedListMissing;

public static class WantedListDifference
{
    public static void ProcessWantedList(string originalFileName, string subtractorFileName)
    {
        // Load the collections
        var originalPieces = CollectionLoader.LoadCollection($"../../../{originalFileName}.xml");
        var subtractorPieces = CollectionLoader.LoadCollection($"../../../{subtractorFileName}.xml");

        // Create a list to hold the keys of the pieces that will have a quantity of 0
        List<string> keysToRemove = new List<string>();

        // Process the original list by subtracting the quantities from the subtractor list
        foreach (var originalPiece in originalPieces)
        {
            if (subtractorPieces.TryGetValue(originalPiece.Key, out LegoPiece? subtractorPiece))
            {
                originalPiece.Value.Quantity -= subtractorPiece.Quantity;

                // Check if the quantity is now 0 and, if so, add the key to the list for later removal
                if (originalPiece.Value.Quantity <= 0)
                {
                    keysToRemove.Add(originalPiece.Key);
                }
            }
        }

        // Remove pieces with a quantity of 0 from the original list
        foreach (var key in keysToRemove)
        {
            originalPieces.Remove(key);
        }

        // Generate a new XML file with the filtered list
        FileGenerator.GenerateFile(originalPieces.Values, $"../../../{originalFileName}Subtracted.xml");
    }
}
