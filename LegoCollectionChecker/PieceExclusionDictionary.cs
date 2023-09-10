using LegoCollectionChecker.Common;

namespace LegoCollectionChecker.MissingPiecesGenerator
{
    public class PieceExclusionDictionary
    {
        public static HashSet<string> ExclusionIds = new()
        {
            new LegoPiece("90498", "Black").GetKey(),
            new LegoPiece("96874", "Orange").GetKey(),
            new LegoPiece("14719", "LightBluishGray").GetKey(),
            new LegoPiece("14719", "DarkBluishGray").GetKey()
        };

        public static HashSet<string> ExclusionCodes = new()
        {
            "11212",
            "14716"
        };
    }
}
