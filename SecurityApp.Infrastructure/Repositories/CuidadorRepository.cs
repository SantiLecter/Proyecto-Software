using SecurityApp.Application.Contracts.Persistence;
using SecurityApp.Domain.Common;
using SecurityApp.Infrastructure.Persistence;

namespace SecurityApp.Infrastructure.Repositories;

public class CuidadorRepository : AsyncRepository<Cuidador>, ICuidadorRepository
{
    public CuidadorRepository(SecurityAppDbContext context) : base(context)
    {
    }
}