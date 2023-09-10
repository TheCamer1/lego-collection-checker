namespace LegoCollectionChecker.Common;

public static class AlternativeDictionary
{
    public static List<HashSet<string>> AlternativeItemIds = new()
    {
        new HashSet<string> { "3794b", "15573", "3794a", "3794" },
        new HashSet<string> { "15712", "44842", "2555", "93794" },
        new HashSet<string> { "2412b", "2412", "2412a" },
        new HashSet<string> { "2436b", "2436", "28802" },
        new HashSet<string> { "3062b", "3062old", "3062oldtile", "3062a" },
        new HashSet<string> { "3068b", "3068", "3068a" },
        new HashSet<string> { "3069b", "3069", "3069a" },
        new HashSet<string> { "3070b", "3070", "3070a" },
        new HashSet<string> { "4085c", "4085", "4085d", "4085a", "4085b" },
        new HashSet<string> { "4081b", "4081a", "4081" },
        new HashSet<string> { "4151b", "4151" },
        new HashSet<string> { "44301b", "44301", "44301a" },
        new HashSet<string> { "44302b", "44302", "44302a", "54657" },
        new HashSet<string> { "44375a", "44375", "44375b" },
        new HashSet<string> { "44567a", "44567", "44567b" },
        new HashSet<string> { "4460b", "4460a", "4460" },
        new HashSet<string> { "4865b", "4865" },
        new HashSet<string> { "553b", "553", "553c", "553a", "3262" },
        new HashSet<string> { "6538b", "6538", "6538a", "6538c" },
        new HashSet<string> { "6538c", "6538", "6538a", "6538b" },
        new HashSet<string> { "4589", "4589b" }
    }; 
    
    public static HashSet<string> GetAlternativeItemIds(string itemId)
    {
        foreach (var alternativeList in AlternativeItemIds)
        {
            if (alternativeList.Contains(itemId))
            {
                return alternativeList;
            }
        }

        return new HashSet<string> { itemId }; // If the ITEMID is not part of any alternative list, return a list containing the original ITEMID
    }
}