namespace LegoCollectionChecker.WantedListMissing;

class Program
{
    static void Main()
    {
        // Computes the difference between two LEGO piece lists.
        // The first argument is the name of the original file that contains the pieces you want to subtract from.
        // The second argument is the name of the subtractor file that contains the list of pieces you are subtracting.
        // A new list will be produced with the original list's quantities subtracted by the subtractor list.
        WantedListDifference.ProcessWantedList("Missing Pieces", "Default Wanted List");
    }
}
