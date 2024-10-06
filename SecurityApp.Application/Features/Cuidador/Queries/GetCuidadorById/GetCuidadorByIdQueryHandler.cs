using AutoMapper;
using MediatR;
using SecurityApp.Application.Contracts.Persistence;

namespace SecurityApp.Application.Features.Cuidador.Queries.GetCuidadorById;

public class GetCuidadorByIdQueryHandler : IRequestHandler<GetCuidadorByIdQuery, CuidadorVm>
{
    private readonly ICuidadorRepository _cuidadorRepository;
    private readonly IMapper _mapper;
    private IRequestHandler<GetCuidadorByIdQuery, CuidadorVm> _requestHandlerImplementation;

    public GetCuidadorByIdQueryHandler(ICuidadorRepository cuidadorRepository, IMapper mapper)
    {
        _cuidadorRepository = cuidadorRepository;
        _mapper = mapper;
    }

    public async Task<CuidadorVm> Handle(GetCuidadorByIdQuery request, CancellationToken cancellationToken)
    {
        var cuidador = await _cuidadorRepository.GetByIdAsync(request.Id);
        return _mapper.Map<CuidadorVm>(cuidador);
    }
}