using MediatR;

namespace SecurityApp.Application.Features.Animal.Queries.GetAnimalById;

public class GetAnimalByIdQuery : IRequest<AnimalVm>
{
    public string Id { get; set; } = string.Empty;

    public GetAnimalByIdQuery(string id)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
    }
    
}