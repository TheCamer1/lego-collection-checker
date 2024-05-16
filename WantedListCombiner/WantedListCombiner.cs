using LegoCollectionChecker.Common;

namespace LegoCollectionChecker.WantedListCombiner;

public static class WantedListCombiner
{
    public static void GenerateCombinedList()
    {
        // Get all XML files in the folder
        var files = Directory.GetFiles("../../../../Common/MissingModels", "*.xml");
        Dictionary<string, LegoPiece> masterList = CombineFiles(files);

        // Generate the combined XML file
        FileGenerator.GenerateFile(masterList.Values, "../../../AllMissing.xml");
    }

    public static void GenerateCombinedList(string[] files)
    {
        Dictionary<string, LegoPiece> masterList = CombineFiles(files);

        // Generate the combined XML file
        FileGenerator.GenerateFile(masterList.Values, "../../../CombinedFiles.xml");
    }

    private static Dictionary<string, LegoPiece> CombineFiles(string[] files)
    {
        Dictionary<string, LegoPiece> masterList = [];

        foreach (var file in files)
        {
            // Load the collection from each XML file
            var currentCollection = CollectionLoader.LoadCollection(file);

            // Merge it into the master list
            foreach (var piece in currentCollection.Values)
            {
                var key = piece.GetKey();
                if (masterList.TryGetValue(key, out LegoPiece? value))
                {
                    value.Quantity += piece.Quantity;
                }
                else
                {
                    // Otherwise, add the new piece to the master list
                    masterList[key] = piece;
                }
            }
        }

        return masterList;
    }
}
