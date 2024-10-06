using MediatR;

namespace SecurityApp.Application.Features.Cuidado.Queries.GetCuidadoByIds;

public class GetCuidadoByIdsQuery : IRequest<CuidadoVm>
{
    public string AnimalId { get; set; }
    public string CuidadorId { get; set; }

    public GetCuidadoByIdsQuery(string animalId, string cuidadorId)
    {
        AnimalId = animalId ?? throw new ArgumentNullException(nameof(animalId));
        CuidadorId = cuidadorId ?? throw new ArgumentNullException(nameof(cuidadorId));
    }
}