using AutoMapper;
using MediatR;
using SecurityApp.Application.Contracts.Persistence;

namespace SecurityApp.Application.Features.Animal.Commands.CreateAnimal;

public class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand, string>
{
    private readonly IAnimalRepository _animalRepository;
    private readonly IMapper _mapper;

    public CreateAnimalCommandHandler(IAnimalRepository animalRepository, IMapper mapper)
    {
        _animalRepository = animalRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
    {
        var animal = _mapper.Map<Domain.Common.Animal>(request);
        animal.FechaRegistro = DateTime.Now;
        var newAnimal = await _animalRepository.AddAsync(animal);
        return newAnimal.Id;
    }
}