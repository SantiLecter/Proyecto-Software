using SecurityApp.Domain.Common;

namespace SecurityApp.Application.Contracts.Persistence;

public interface IExamenRepository : IAsyncRepository<Examen>
{
    Task<Examen> GetByAnimal(string animalId);

}