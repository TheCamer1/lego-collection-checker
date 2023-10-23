using LegoCollectionChecker.Common;
using LegoCollectionChecker.PieceChecker;

namespace LegoCollectionChecker.WantedListMissing;

public static class WantedListDeterminer
{
    public static void ProcessWantedList(string outputFileName)
    {
        // Load the collection
        var pieces = CollectionLoader.LoadCollection($"../../../{outputFileName}.xml");
        var completeCollection = CollectionLoader.LoadCollection("../../../../Common/CompleteCollection.xml");

        var results = pieces
            .Select(e => new { Piece = e.Value, Excess = PieceLocator.GetExcess(completeCollection, e.Value.ItemId, e.Value.Color) })
            .Where(e => e.Excess < 0);

        var missingPieces = new List<LegoPiece>();

        foreach ( var result in results)
        {
            var piece = result.Piece;
            piece.Quantity = Math.Min(-result.Excess, piece.Quantity);
            missingPieces.Add(piece);
        }

        // Generate a new XML file with the filtered list
        FileGenerator.GenerateFile(missingPieces, $"../../../{outputFileName}Missing.xml");
    }
}
