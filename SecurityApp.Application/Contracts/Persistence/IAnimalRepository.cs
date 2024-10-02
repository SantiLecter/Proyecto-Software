using SecurityApp.Domain.Common;

namespace SecurityApp.Application.Contracts.Persistence;

public interface IAnimalRepository : IAsyncRepository<Animal>
{
}