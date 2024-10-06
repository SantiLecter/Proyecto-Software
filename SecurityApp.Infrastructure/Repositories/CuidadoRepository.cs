using Microsoft.EntityFrameworkCore;
using SecurityApp.Application.Contracts.Persistence;
using SecurityApp.Domain.Common;
using SecurityApp.Infrastructure.Persistence;

namespace SecurityApp.Infrastructure.Repositories;

public class CuidadoRepository : AsyncRepository<Cuidado>, ICuidadoRepository
{

    public CuidadoRepository(SecurityAppDbContext context) : base(context)
    {
    }

    public async Task<Cuidado> GetByIdsAsync(string animalId, string cuidadorId)
    {
        return await _context.Cuidados
            .Where(c => c.AnimalId == animalId && c.CuidadorId == cuidadorId)
            .FirstOrDefaultAsync();
    }
}