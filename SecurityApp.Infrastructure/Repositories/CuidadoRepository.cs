using SecurityApp.Application.Contracts.Persistence;
using SecurityApp.Domain.Common;
using SecurityApp.Infrastructure.Persistence;

namespace SecurityApp.Infrastructure.Repositories;

public class CuidadoRepository : AsyncRepository<Cuidado>, ICuidadoRepository
{
    public CuidadoRepository(SecurityAppDbContext context) : base(context)
    {
    }
}