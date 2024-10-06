using Microsoft.EntityFrameworkCore;
using SecurityApp.Application.Contracts.Persistence;
using SecurityApp.Domain.Common;
using SecurityApp.Infrastructure.Persistence;

namespace SecurityApp.Infrastructure.Repositories;

public class ExamenRepository : AsyncRepository<Examen>, IExamenRepository
{
    private IExamenRepository _examenRepositoryImplementation;

    public ExamenRepository(SecurityAppDbContext context) : base(context)
    {
    }

    public async Task<Examen> GetByAnimal(string animalId)
    {
        return await _context.Examenes.Where(e => e.AnimalId == animalId)
            .FirstOrDefaultAsync();
    }
}