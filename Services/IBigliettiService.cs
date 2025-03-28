using System.Threading.Tasks;

public interface IBigliettiService
{
    Task<bool> AcquistaBiglietto(string userId, AcquistoBigliettoDto dto);
}
