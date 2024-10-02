using AutoMapper;
using MediatR;
using SecurityApp.Application.Contracts.Persistence;

namespace SecurityApp.Application.Features.Animal.Queries.GetAnimalsList;

public class GetAnimalsListQueryHandler : IRequestHandler<GetAnimalsListQuery, List<AnimalVm>>
{
    private readonly IAnimalRepository _animalRepository;
    private readonly IMapper _mapper;

    public GetAnimalsListQueryHandler(IAnimalRepository animalRepository, IMapper mapper)
    {
        _animalRepository = animalRepository;
        _mapper = mapper;
    }

    public async Task<List<AnimalVm>> Handle(GetAnimalsListQuery request, CancellationToken cancellationToken)
    {
        var list = await _animalRepository.GetAllAsync();
        return _mapper.Map<List<AnimalVm>>(list);
    }
}