namespace LegoCollectionChecker.GoBricksConverter;

public static class GoBrickColorMap
{
    private static readonly Dictionary<string, int> _colorMap = new Dictionary<string, int>
    {
        // Standard colors
        ["010"] = 5,    // Red
        ["011"] = 104,  // Bright Pink
        ["012"] = 47,   // Dark Pink
        ["013"] = 71,   // Magenta
        ["014"] = 59,   // Dark Red
        ["021"] = 4,    // Orange
        ["030"] = 3,    // Yellow
        ["031"] = 2,    // Tan
        ["032"] = 90,   // Light Flesh
        ["033"] = 103,  // Bright Light Yellow
        ["034"] = 69,   // Dark Tan
        ["035"] = 115,  // Pearl Gold
        ["036"] = 110,  // Bright Light Orange
        ["040"] = 6,    // Green
        ["042"] = 34,   // Lime
        ["043"] = 36,   // Bright Green
        ["044"] = 158,  // Yellowish Green
        ["045"] = 152,  // Light Aqua
        ["046"] = 156,  // Medium Azure
        ["047"] = 80,   // Dark Green
        ["048"] = 48,   // Sand Green
        ["049"] = 155,  // Olive Green
        ["050"] = 7,    // Blue
        ["051"] = 153,  // Dark Azure
        ["052"] = 42,   // Medium Blue
        ["053"] = 105,  // Bright Light Blue
        ["054"] = 55,   // Sand Blue
        ["055"] = 63,   // Dark Blue
        ["060"] = 89,   // Dark Purple
        ["062"] = 157,  // Medium Lavender
        ["063"] = 154,  // Lavender
        ["071"] = 86,   // Light Bluish Gray
        ["072"] = 85,   // Dark Bluish Gray
        ["073"] = 95,   // Flat Silver
        ["080"] = 11,   // Black
        ["081"] = 88,   // Reddish Brown
        ["082"] = 120,  // Dark Brown
        ["083"] = 68,   // Dark Orange
        ["084"] = 150,  // Medium Dark Flesh
        ["090"] = 1,    // White

        // Transparent colors
        ["110"] = 17,   // Trans-Red
        ["111"] = 50,   // Trans-Dark Pink
        ["120"] = 98,   // Trans-Orange
        ["130"] = 19,   // Trans-Yellow
        ["140"] = 20,   // Trans-Green
        ["141"] = 16,   // Trans-Neon Green
        ["150"] = 14,   // Trans-Dark Blue
        ["152"] = 15,   // Trans-Light Blue
        ["160"] = 51,   // Trans-Purple
        ["170"] = 13,   // Trans-Black
        ["180"] = 12,   // Trans-Clear
    };

    public static int? GetLDrawColor(string goBrickColor)
    {
        // Remove the ' prefix if present
        if (goBrickColor.StartsWith("'"))
        {
            goBrickColor = goBrickColor.Substring(1);
        }

        // Handle "N^" which means no color
        if (goBrickColor == "N^")
        {
            return null;
        }

        if (_colorMap.TryGetValue(goBrickColor, out int ldrawColor))
        {
            return ldrawColor;
        }

        // If color not found, return null
        return null;
    }
}