using MediatR;

namespace SecurityApp.Application.Features.Vacuna.Queries.GetVacunaByAnimal;

public class GetVacunaByAnimalQuery : IRequest<VacunaVm>
{
    public string Id { get; set; } = string.Empty;

    public GetVacunaByAnimalQuery(string id)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
    }
}