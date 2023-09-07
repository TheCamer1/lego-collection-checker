﻿namespace LegoCollectionChecker;

public class LegoPiece
{
    public string ItemType { get; set; }
    public string ItemId { get; set; }
    public int Color { get; set; }
    public int Quantity { get; set; }

    public LegoPiece(string itemType, string itemId, int color, int quantity)
    {
        ItemType = itemType;
        ItemId = itemId;
        Color = color;
        Quantity = quantity;
    }

    public LegoPiece(string itemId, int color, int quantity)
    {
        ItemType = "P";
        ItemId = itemId;
        Color = color;
        Quantity = quantity;
    }

    public LegoPiece(string itemType, string itemId, string color, int quantity)
    {
        var colourMap = new ColourMap();
        ItemType = itemType;
        ItemId = itemId;
        Color = colourMap.GetIdByName(color)!.Value;
        Quantity = quantity;
    }

    public LegoPiece(string itemId, string color, int quantity)
    {
        var colourMap = new ColourMap();
        ItemType = "P";
        ItemId = itemId;
        Color = colourMap.GetIdByName(color)!.Value;
        Quantity = quantity;
    }

    public LegoPiece(string itemType, string itemId, string color)
    {
        var colourMap = new ColourMap();
        ItemType = itemType;
        ItemId = itemId;
        Color = colourMap.GetIdByName(color)!.Value;
        Quantity = 1;
    }

    public LegoPiece(string itemId, string color)
    {
        var colourMap = new ColourMap();
        ItemType = "P";
        ItemId = itemId;
        Color = colourMap.GetIdByName(color)!.Value;
        Quantity = 1;
    }

    public string GetKey()
    {
        return $"{ItemType}:{ItemId}:{Color}";
    }
}
