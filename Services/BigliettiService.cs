using System.Threading.Tasks;
using System;

public class BigliettiService : IBigliettiService
{
    private readonly ApplicationDbContext _context;

    public BigliettiService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AcquistaBiglietto(string userId, AcquistoBigliettoDto dto)
    {
        var evento = await _context.Eventi.FindAsync(dto.EventoId);
        if (evento == null) return false;

        var biglietto = new Biglietto
        {
            EventoId = dto.EventoId,
            UserId = userId,
            DataAcquisto = DateTime.UtcNow
        };

        _context.Biglietti.Add(biglietto);
        await _context.SaveChangesAsync();
        return true;
    }
}
