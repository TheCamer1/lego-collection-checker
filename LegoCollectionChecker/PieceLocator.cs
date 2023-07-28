internal static class PieceLocator
{
    public static void CheckPiece(string itemId, string colorName)
    {
        if (!ColourDictionary.ColorNameToId.TryGetValue(colorName, out var colorId))
        {
            Console.WriteLine($"Unknown color name: {colorName}");
            return;
        }

        var models = ListIncompleteModelsContainingPiece(itemId, colorId);

        Console.WriteLine($"The piece with ITEMID={itemId} and COLOR={colorName} is in the following incomplete models:");
        foreach (var model in models)
        {
            Console.WriteLine($"Model file: {model.Key}, Quantity: {model.Value}");
        }
    }

    public static Dictionary<string, int> ListIncompleteModelsContainingPiece(string itemId, string color)
    {
        var modelsContainingPiece = new Dictionary<string, int>();
        var alternativeIds = AlternativeDictionary.GetAlternativeItemIds(itemId);

        foreach (var file in Directory.GetFiles("../../../IncompleteModels", "*.xml"))
        {
            var modelPieces = CollectionLoader.LoadCollection(file);
            foreach (var altId in alternativeIds)
            {
                var keyToFind = $"P:{altId}:{color}";

                if (modelPieces.ContainsKey(keyToFind))
                {
                    var filename = Path.GetFileName(file);
                    if (modelsContainingPiece.ContainsKey(filename))
                    {
                        modelsContainingPiece[filename] += modelPieces[keyToFind];
                    }
                    else
                    {
                        modelsContainingPiece.Add(filename, modelPieces[keyToFind]);
                    }
                }
            }
        }

        return modelsContainingPiece;
    }
}