using MediatR;

namespace SecurityApp.Application.Features.Examen.Queries.GetExamenByAnimal;

public class GetExamenByAnimalQuery : IRequest<ExamenVm>
{
    public string Id { get; set; } = string.Empty;

    public GetExamenByAnimalQuery(string id)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
    }
}