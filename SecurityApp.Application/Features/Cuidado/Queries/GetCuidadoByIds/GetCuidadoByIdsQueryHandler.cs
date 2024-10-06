using AutoMapper;
using MediatR;
using SecurityApp.Application.Contracts.Persistence;

namespace SecurityApp.Application.Features.Cuidado.Queries.GetCuidadoByIds;

public class GetCuidadoByIdsQueryHandler : IRequestHandler<GetCuidadoByIdsQuery, CuidadoVm>
{
    private readonly ICuidadoRepository _cuidadoRepository;
    private readonly IMapper _mapper;

    public GetCuidadoByIdsQueryHandler(ICuidadoRepository cuidadoRepository, IMapper mapper)
    {
        _cuidadoRepository = cuidadoRepository;
        _mapper = mapper;
    }

    public async Task<CuidadoVm> Handle(GetCuidadoByIdsQuery request, CancellationToken cancellationToken)
    {
        var cuidado = await _cuidadoRepository.GetByIdsAsync(request.AnimalId, request.CuidadorId);
        return _mapper.Map<CuidadoVm>(cuidado);
    }
}