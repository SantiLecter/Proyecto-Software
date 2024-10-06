using SecurityApp.Domain.Common;

namespace SecurityApp.Application.Contracts.Persistence;

public interface IVacunaRepository : IAsyncRepository<Vacuna>
{
    Task<Vacuna> GetByAnimal(string animalId);

}