using LegoCollectionChecker.Common;

namespace LegoCollectionChecker.MissingPiecesGenerator
{
    public static class PieceExclusionDictionary
    {
        public readonly static HashSet<string> ExclusionIds = new()
        {
            "P:90498:Black",
            "P:96874:Orange",
            "P:14719:LightBluishGray",
            "P:14719:DarkBluishGray"
        };

        public readonly static HashSet<string> ExclusionCodes = new()
        {
            "11212",
            "14716"
        };
    }
}
