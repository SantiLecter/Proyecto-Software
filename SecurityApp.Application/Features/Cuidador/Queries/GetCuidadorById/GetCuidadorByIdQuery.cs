using MediatR;

namespace SecurityApp.Application.Features.Cuidador.Queries.GetCuidadorById;

public class GetCuidadorByIdQuery : IRequest<CuidadorVm>
{
    public string Id { get; set; } = string.Empty;

    public GetCuidadorByIdQuery(string id)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
    }
}