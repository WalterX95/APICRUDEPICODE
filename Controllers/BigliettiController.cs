using System.Security.Claims;
using System.Threading.Tasks;

[Authorize]
[Route("api/biglietti")]
[ApiController]
public class BigliettiController : ControllerBase
{
    private readonly IBigliettiService _bigliettiService;

    public BigliettiController(IBigliettiService bigliettiService)
    {
        _bigliettiService = bigliettiService;
    }

    [HttpPost]
    public async Task<IActionResult> AcquistaBiglietto([FromBody] AcquistoBigliettoDto dto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (await _bigliettiService.AcquistaBiglietto(userId, dto))
            return Ok("Acquisto completato!");

        return BadRequest("Errore nell'acquisto del biglietto.");
    }
}
