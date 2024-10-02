using AutoMapper;
using MediatR;
using SecurityApp.Application.Contracts.Persistence;

namespace SecurityApp.Application.Features.Animal.Queries.GetAnimalById;

public class GetAnimalByIdQueryHandler : IRequestHandler<GetAnimalByIdQuery, AnimalVm>
{
    private readonly IAnimalRepository _animalRepository;
    private readonly IMapper _mapper;

    public GetAnimalByIdQueryHandler(IAnimalRepository animalRepository, IMapper mapper)
    {
        _animalRepository = animalRepository;
        _mapper = mapper;
    }

    public async Task<AnimalVm> Handle(GetAnimalByIdQuery request, CancellationToken cancellationToken)
    {
        var animal = await _animalRepository.GetByIdAsync(request.Id);
        return _mapper.Map<AnimalVm>(animal);
    }
}