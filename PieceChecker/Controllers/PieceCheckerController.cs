using Microsoft.AspNetCore.Mvc;
using LegoCollectionChecker.Common;

namespace LegoCollectionChecker.PieceChecker.Controllers;

[ApiController]
[Route("[controller]")]
public class PieceCheckerController : ControllerBase
{
    private readonly PieceLocator pieceLocator;

    public PieceCheckerController()
    {
        pieceLocator = new PieceLocator();
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
        var colourMap = new ColourMap();
        return Ok(colourMap.ColourInfos.Where(e => e.IsCommon));
    }
}
