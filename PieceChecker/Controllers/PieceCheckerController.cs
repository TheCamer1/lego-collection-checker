using Microsoft.AspNetCore.Mvc;
using LegoCollectionChecker.Common;

namespace LegoCollectionChecker.PieceChecker.Controllers;

[ApiController]
[Route("[controller]")]
public class PieceCheckerController : ControllerBase
{
    [HttpGet("checkpiece")]
    public IActionResult CheckPiece(string id, Colour colour, bool ignoreColour)
    {
        var result = PieceLocator.CheckPiece(id, colour, ignoreColour);
        return Ok(result);
    }

    [HttpGet("colours")]
    public IActionResult GetAllColours()
    {
        var colourMap = new ColourMap();
        return Ok(colourMap.ColourInfos.Where(e => e.IsCommon));
    }
}
