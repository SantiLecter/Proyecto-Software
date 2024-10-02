using SecurityApp.Application.Contracts.Persistence;
using SecurityApp.Domain.Common;
using SecurityApp.Infrastructure.Persistence;

namespace SecurityApp.Infrastructure.Repositories;

public class ExamenRepository : AsyncRepository<Examen>, IExamenRepository
{
    public ExamenRepository(SecurityAppDbContext context) : base(context)
    {
    }
}