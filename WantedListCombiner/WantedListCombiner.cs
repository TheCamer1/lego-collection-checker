using LegoCollectionChecker.Common;

namespace LegoCollectionChecker.WantedListCombiner;

public static class WantedListCombiner
{
    public static void GenerateCombinedList()
    {
        Dictionary<string, LegoPiece> masterList = new Dictionary<string, LegoPiece>();

        // Get all XML files in the folder
        var files = Directory.GetFiles("../../../MissingModels", "*.xml");

        foreach (var file in files)
        {
            // Load the collection from each XML file
            var currentCollection = CollectionLoader.LoadCollection(file);

            // Merge it into the master list
            foreach (var piece in currentCollection.Values)
            {
                var key = piece.GetKey();
                if (masterList.ContainsKey(key))
                {
                    // If the item already exists, sum up the quantities
                    masterList[key].Quantity += piece.Quantity;
                }
                else
                {
                    // Otherwise, add the new piece to the master list
                    masterList[key] = piece;
                }
            }
        }

        // Generate the combined XML file
        FileGenerator.GenerateFile(masterList.Values, "AllMissing");
    }
}
