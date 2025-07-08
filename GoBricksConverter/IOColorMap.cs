namespace LegoCollectionChecker.IOConverter;

public static class IOColorMap
{
    private static readonly Dictionary<string, int> _colorMap = new Dictionary<string, int>
    {
        // Standard colors
        ["4"] = 5,    // Red
        ["29"] = 104,  // Bright Pink
        ["5"] = 47,   // Dark Pink
        ["26"] = 71,   // Magenta
        ["320"] = 59,  // Dark Red
        ["25"] = 4,    // Orange
        ["14"] = 3,    // Yellow
        ["19"] = 2,    // Tan
        ["78"] = 90,   // Light Flesh
        ["226"] = 103, // Bright Light Yellow
        ["28"] = 69,   // Dark Tan
        ["297"] = 115, // Pearl Gold
        ["191"] = 110, // Bright Light Orange
        ["2"] = 6,    // Green
        ["27"] = 34,   // Lime
        ["10"] = 36,   // Bright Green
        ["323"] = 152, // Light Aqua
        ["322"] = 156, // Medium Azure
        ["288"] = 80,  // Dark Green
        ["378"] = 48,  // Sand Green
        ["330"] = 155, // Olive Green
        ["1"] = 7,    // Blue
        ["321"] = 153, // Dark Azure
        ["73"] = 42,   // Medium Blue
        ["212"] = 105, // Bright Light Blue
        ["379"] = 55,  // Sand Blue
        ["272"] = 63,  // Dark Blue
        ["85"] = 89,   // Dark Purple
        ["30"] = 157,  // Medium Lavender
        ["31"] = 154,  // Lavender
        ["71"] = 86,   // Light Bluish Gray
        ["72"] = 85,   // Dark Bluish Gray
        ["179"] = 95,  // Flat Silver
        ["0"] = 11,   // Black
        ["70"] = 88,   // Reddish Brown
        ["308"] = 120, // Dark Brown
        ["484"] = 68,  // Dark Orange
        ["84"] = 150,  // Medium Dark Flesh
        ["15"] = 1,    // White
        ["65"] = 65,    // Metallic Gold

        // Transparent colors
        ["36"] = 17,   // Trans-Red
        ["37"] = 50,   // Trans-Dark Pink
        ["57"] = 98,   // Trans-Orange
        ["46"] = 19,   // Trans-Yellow
        ["34"] = 20,   // Trans-Green
        ["42"] = 16,   // Trans-Neon Green
        ["33"] = 14,   // Trans-Dark Blue
        ["43"] = 15,   // Trans-Light Blue
        ["52"] = 51,   // Trans-Purple
        ["40"] = 13,   // Trans-Black
        ["47"] = 12,   // Trans-Clear
    };

    public static int? GetLDrawColor(string ioColor)
    {
        if (_colorMap.TryGetValue(ioColor, out int ldrawColor))
        {
            return ldrawColor;
        }

        // If color not found, return null
        return null;
    }
}