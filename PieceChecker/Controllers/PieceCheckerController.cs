using LegoCollectionChecker.Common;
using Microsoft.AspNetCore.Mvc;

namespace LegoCollectionChecker.PieceChecker.Controllers;

[ApiController]
[Route("[controller]")]
public class PieceCheckerController : ControllerBase
{
    private readonly IPieceLocator _pieceLocator;

    public PieceCheckerController(IPieceLocator pieceLocator)
    {
        _pieceLocator = pieceLocator;
    }

    [HttpGet("checkpiece")]
    public IActionResult CheckPiece(string id, Colour colour, bool ignoreColour)
    {
        var result = _pieceLocator.CheckPiece(id, colour, ignoreColour);
        return Ok(result);
    }

    [HttpGet("colours")]
    public IActionResult GetAllColours()
    {
        var colourMap = new ColourMap();
        var commonColours = colourMap.ColourInfos.Where(e => e.IsCommon);
        return Ok(commonColours);
    }
}
