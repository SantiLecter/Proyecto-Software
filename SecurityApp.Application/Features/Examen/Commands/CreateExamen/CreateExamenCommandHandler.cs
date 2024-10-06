using AutoMapper;
using MediatR;
using SecurityApp.Application.Contracts.Persistence;

namespace SecurityApp.Application.Features.Examen.Commands.CreateExamen;

public class CreateExamenCommandHandler : IRequestHandler<CreateExamenCommand, string>
{
    private readonly IExamenRepository _examenRepository;
    private readonly IMapper _mapper;

    public CreateExamenCommandHandler(IExamenRepository examenRepository, IMapper mapper)
    {
        _examenRepository = examenRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(CreateExamenCommand request, CancellationToken cancellationToken)
    {
        var examen = _mapper.Map<Domain.Common.Examen>(request);
        var newExamen = await _examenRepository.AddAsync(examen);
        return newExamen.Id;
    }
}