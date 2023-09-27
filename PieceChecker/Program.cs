using LegoCollectionChecker.Common;

namespace LegoCollectionChecker.PieceChecker;

class Program
{
    static void Main()
    {
        PieceLocator.CheckPiece("13547", Colour.White, true);
    }
}
