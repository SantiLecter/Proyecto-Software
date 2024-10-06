using SecurityApp.Application.Features.Animal.Queries.GetAnimalById;
using SecurityApp.Domain.Common;

namespace SecurityApp.Application.Contracts.Persistence;

public interface ICuidadoRepository : IAsyncRepository<Cuidado>
{
    Task<Cuidado> GetByIdsAsync(string animalId, string cuidadorId);

}