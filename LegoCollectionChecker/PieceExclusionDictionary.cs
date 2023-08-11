namespace LegoCollectionChecker
{
    public class PieceExclusionDictionary
    {
        public static HashSet<string> ExclusionIds = new()
        {
            new LegoPiece("90498", "Black").GetKey(),
            new LegoPiece("96874", "Orange").GetKey(),
        };
    }
}
