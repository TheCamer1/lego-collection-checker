using LegoCollectionChecker.Common;

namespace LegoCollectionChecker.WantedListCombiner;

class Program
{
    static void Main()
    {
        //WantedListCombiner.GenerateCombinedList();
        WantedListCombiner.GenerateCombinedList([
            RepoPaths.CompleteCollection,
            RepoPaths.Project("WantedListCombiner", "Jooooy.xml")
        ]);
    }
}
