using Microsoft.AspNetCore.Mvc;
using LegoCollectionChecker.Common;
using static LegoCollectionChecker.Common.ColourMap;

namespace LegoCollectionChecker.PieceChecker.Controllers;

[ApiController]
[Route("[controller]")]
public class PieceCheckerController : ControllerBase
{
    private readonly PieceLocator pieceLocator;
    private readonly IEnumerable<ColourInfo> commonColours;

    public PieceCheckerController()
    {
        pieceLocator = new PieceLocator();
        var colourMap = new ColourMap();
        commonColours = colourMap.ColourInfos.Where(e => e.IsCommon);
    }

    [HttpGet("checkpiece")]
    public IActionResult CheckPiece(string id, Colour colour, bool ignoreColour)
    {
        var result = pieceLocator.CheckPiece(id, colour, ignoreColour);
        return Ok(result);
    }

    [HttpGet("colours")]
    public IActionResult GetAllColours()
    {
        return Ok(commonColours);
    }
}
