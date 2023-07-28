namespace LegoCollectionChecker;

public class LegoPiece
{
    public string ItemType { get; set; }
    public string ItemId { get; set; }
    public string Color { get; set; }
    public int Quantity { get; set; }

    public LegoPiece(string itemType, string itemId, string color, int quantity)
    {
        ItemType = itemType;
        ItemId = itemId;
        Color = color;
        Quantity = quantity;
    }

    public string GetKey()
    {
        return $"{ItemType}:{ItemId}:{Color}";
    }
}
