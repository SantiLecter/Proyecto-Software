using AutoMapper;
using MediatR;
using SecurityApp.Application.Contracts.Persistence;

namespace SecurityApp.Application.Features.Examen.Queries.GetExamenByAnimal;

public class GetExamenByAnimalQueryHandler : IRequestHandler<GetExamenByAnimalQuery, ExamenVm>
{
    
    private readonly IExamenRepository _examenRepository;
    private readonly IMapper _mapper;

    public GetExamenByAnimalQueryHandler(IExamenRepository examenRepository, IMapper mapper)
    {
        _examenRepository = examenRepository;
        _mapper = mapper;
    }


    public async Task<ExamenVm> Handle(GetExamenByAnimalQuery request, CancellationToken cancellationToken)
    {
        var examen = await _examenRepository.GetByAnimal(request.Id);
        return _mapper.Map<ExamenVm>(examen);
    }
}