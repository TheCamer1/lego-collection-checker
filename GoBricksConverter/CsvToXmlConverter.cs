using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using LegoCollectionChecker.Common;
using LegoCollectionChecker.IOConverter;

namespace LegoCollectionChecker.GoBricksConverter;

public static class CsvToXmlConverter
{
    public static void ConvertCsvToXml(string csvFilePath, string xmlFilePath)
    {
        try
        {
            var pieces = ReadCsvFile(csvFilePath);
            GenerateXmlFile(pieces, xmlFilePath);
            Console.WriteLine($"Successfully converted {csvFilePath} to {xmlFilePath}");
            Console.WriteLine($"Total pieces: {pieces.Count}");
            Console.WriteLine($"Total quantity: {pieces.Sum(p => p.Quantity)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error converting file: {ex.Message}");
        }
    }

    private static List<LegoPiece> ReadCsvFile(string csvFilePath)
    {
        var pieces = new Dictionary<string, LegoPiece>();
        var lines = File.ReadAllLines(csvFilePath);
        int processedLines = 0;
        int skippedLines = 0;

        // Skip header line
        for (int i = 1; i < lines.Length; i++)
        {
            var line = lines[i].Trim();
            if (string.IsNullOrEmpty(line))
                continue;

            var parts = line.Split(',');
            if (parts.Length < 6)
            {
                Console.WriteLine($"Skipping invalid line {i + 1}: {line}");
                skippedLines++;
                continue;
            }

            try
            {
                var partId = parts[0].Trim();
                var colorString = parts[1].Trim().Replace("\'", "");
                var quantity = int.Parse(parts[2].Trim());
                // parts[3] is empty
                var goBrickPart = parts[4].Trim();
                var goBrickColor = parts[5].Trim();

                // Get LDraw color from GoBrick color
                int? colorCode = null;
                if (colorString != "N^")
                {
                    colorCode = IOColorMap.GetLDrawColor(colorString);
                    if (colorCode == null)
                    {
                        Console.WriteLine($"Warning: Unknown GoBrick color '{colorString}' on line {i + 1}, part {partId}");
                    }
                }

                // If we couldn't map from GoBrick color, try to use the color from column 2
                if (colorCode == null && colorString.StartsWith("'"))
                {
                    var colorFromColumn2 = colorString.Substring(1);
                    if (int.TryParse(colorFromColumn2, out int parsedColor))
                    {
                        colorCode = parsedColor;
                    }
                }

                // If still no color, default to 0 (no color)
                if (!colorCode.HasValue)
                {
                    colorCode = 0;
                }

                // Create or update piece
                var key = $"P:{partId}:{colorCode}";
                if (pieces.ContainsKey(key))
                {
                    pieces[key].Quantity += quantity;
                }
                else
                {
                    pieces[key] = new LegoPiece("P", partId, colorCode.Value, quantity);
                }
                processedLines++;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing line {i + 1}: {line}");
                Console.WriteLine($"  Error: {ex.Message}");
                skippedLines++;
            }
        }

        Console.WriteLine($"Processed {processedLines} lines, skipped {skippedLines} lines");
        return pieces.Values.OrderBy(p => p.ItemId).ThenBy(p => p.Color).ToList();
    }

    private static void GenerateXmlFile(List<LegoPiece> pieces, string xmlFilePath)
    {
        var inventory = new XElement("INVENTORY",
            from piece in pieces
            select new XElement("ITEM",
                new XElement("ITEMTYPE", piece.ItemType),
                new XElement("ITEMID", piece.ItemId),
                new XElement("COLOR", piece.Color),
                new XElement("MAXPRICE", "-1.0000"),
                new XElement("MINQTY", piece.Quantity),
                new XElement("CONDITION", "X"),
                new XElement("NOTIFY", "N")));

        var doc = new XDocument(inventory);
        doc.Save(xmlFilePath);
    }
}
