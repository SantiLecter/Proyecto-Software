using AutoMapper;
using MediatR;
using SecurityApp.Application.Contracts.Persistence;

namespace SecurityApp.Application.Features.Vacuna.Queries.GetVacunaByAnimal;

public class GetVacunaByAnimalQueryHandler : IRequestHandler<GetVacunaByAnimalQuery, VacunaVm>
{
    private readonly IVacunaRepository _vacunaRepository;
    private readonly IMapper _mapper;

    public GetVacunaByAnimalQueryHandler(IVacunaRepository vacunaRepository, IMapper mapper)
    {
        _vacunaRepository = vacunaRepository;
        _mapper = mapper;
    }


    public async Task<VacunaVm> Handle(GetVacunaByAnimalQuery request, CancellationToken cancellationToken)
    {
        var vacuna = await _vacunaRepository.GetByAnimal(request.Id);
        return _mapper.Map<VacunaVm>(vacuna);
    }
}