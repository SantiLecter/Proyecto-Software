using Microsoft.EntityFrameworkCore;
using SecurityApp.Application.Contracts.Persistence;
using SecurityApp.Domain.Common;
using SecurityApp.Infrastructure.Persistence;

namespace SecurityApp.Infrastructure.Repositories;

public class VacunaRepository : AsyncRepository<Vacuna>, IVacunaRepository
{
    private IVacunaRepository _vacunaRepositoryImplementation;

    public VacunaRepository(SecurityAppDbContext context) : base(context)
    {
    }

    public async Task<Vacuna> GetByAnimal(string animalId)
    {
        return await _context.Vacunas.Where(e => e.AnimalId == animalId)
            .FirstOrDefaultAsync();
    }
}