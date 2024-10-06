using MediatR;

namespace SecurityApp.Application.Features.Cuidador.Queries.GetListCuidadores;

public class GetListCuidadoresQuery : IRequest<List<CuidadorVm>>
{
}