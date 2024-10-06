using AutoMapper;
using MediatR;
using SecurityApp.Application.Contracts.Persistence;

namespace SecurityApp.Application.Features.Cuidador.Queries.GetListCuidadores;

public class GetListCuidadoresQueryHandler : IRequestHandler<GetListCuidadoresQuery, List<CuidadorVm>>
{
    private readonly ICuidadorRepository _cuidadorRepository;
    private readonly IMapper _mapper;

    public GetListCuidadoresQueryHandler(ICuidadorRepository cuidadorRepository, IMapper mapper)
    {
        _cuidadorRepository = cuidadorRepository;
        _mapper = mapper;
    }

    public async Task<List<CuidadorVm>> Handle(GetListCuidadoresQuery request, CancellationToken cancellationToken)
    {
        var list = await _cuidadorRepository.GetAllAsync();
        return _mapper.Map<List<CuidadorVm>>(list);
    }
}