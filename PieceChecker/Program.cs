using LegoCollectionChecker.Common;

namespace LegoCollectionChecker.PieceChecker;

class Program
{
    static void Main()
    {
        PieceLocator.CheckPiece("30602", Colour.White, true);
    }
}
