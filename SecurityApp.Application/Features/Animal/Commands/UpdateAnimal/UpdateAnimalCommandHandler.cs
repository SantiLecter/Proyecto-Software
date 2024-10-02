using AutoMapper;
using MediatR;
using SecurityApp.Application.Contracts.Persistence;

namespace SecurityApp.Application.Features.Animal.Commands.UpdateAnimal;

public class UpdateAnimalCommandHandler : IRequestHandler<UpdateAnimalCommand>
{
    private readonly IAnimalRepository _animalRepository;
    private readonly IMapper _mapper;

    public UpdateAnimalCommandHandler(IAnimalRepository animalRepository, IMapper mapper)
    {
        _animalRepository = animalRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateAnimalCommand request, CancellationToken cancellationToken)
    {
        var animalToUpdate = await _animalRepository.GetByIdAsync(request.Id);

        if (animalToUpdate == null)
        {
            throw(new Exception($"{nameof(request.Id)} {request.Id} does not exists"));
        }
        
        _mapper.Map(request, animalToUpdate, typeof(UpdateAnimalCommand), typeof(Domain.Common.Animal));
        await _animalRepository.UpdateAsync(animalToUpdate);
        return Unit.Value;
    }
}