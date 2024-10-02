using AutoMapper;
using MediatR;
using SecurityApp.Application.Contracts.Persistence;

namespace SecurityApp.Application.Features.Animal.Commands.DeleteAnimal;

public class DeleteAnimalCommandHandler : IRequestHandler<DeleteAnimalCommand, bool>
{
    private readonly IAnimalRepository _animalRepository;
    private readonly IMapper _mapper;

    public DeleteAnimalCommandHandler(IAnimalRepository animalRepository, IMapper mapper)
    {
        _animalRepository = animalRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
    {
        var animalMap = _mapper.Map<Domain.Common.Animal>(request);
        try
        {
            await _animalRepository.DeleteAsync(animalMap);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}