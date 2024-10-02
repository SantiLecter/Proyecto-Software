using SecurityApp.Application.Contracts.Persistence;
using SecurityApp.Domain.Common;
using SecurityApp.Infrastructure.Persistence;

namespace SecurityApp.Infrastructure.Repositories;

public class VacunaRepository : AsyncRepository<Vacuna>, IVacunaRepository
{
    public VacunaRepository(SecurityAppDbContext context) : base(context)
    {
    }
}