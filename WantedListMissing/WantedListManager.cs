using LegoCollectionChecker.Common;

namespace LegoCollectionChecker.WantedListMissing;

public static class WantedListManager
{
    public static void ProcessWantedList(string outputFileName)
    {
        // Load the collection
        var pieces = CollectionLoader.LoadCollection(RepoPaths.Project("WantedListMissing", $"{outputFileName}.xml"));

        // Filter the collection to generate a new wanted list
        var remainingWantedPieces = FilterRemainingWantedPieces(pieces.Values);

        // Generate a new XML file with the filtered list
        FileGenerator.GenerateFile(remainingWantedPieces, RepoPaths.Project("WantedListMissing", $"{outputFileName}Missing.xml"));
    }

    private static IEnumerable<LegoPiece> FilterRemainingWantedPieces(IEnumerable<LegoPiece> pieces)
    {
        return pieces
            .Where(piece => piece.HaveQuantity < piece.Quantity)
            .Select(piece => new LegoPiece(piece.ItemType, piece.ItemId, piece.Color, piece.Quantity - piece.HaveQuantity))
            .ToList();
    }
}
