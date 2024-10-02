using SecurityApp.Application.Contracts.Persistence;
using SecurityApp.Domain.Common;
using SecurityApp.Infrastructure.Persistence;

namespace SecurityApp.Infrastructure.Repositories;

public class AnimalRepository : AsyncRepository<Animal>, IAnimalRepository
{
    public AnimalRepository(SecurityAppDbContext context) : base(context)
    {
    }
}