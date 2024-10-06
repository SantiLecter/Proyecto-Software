using AutoMapper;
using MediatR;
using SecurityApp.Application.Contracts.Persistence;

namespace SecurityApp.Application.Features.Vacuna.Commands.CreateVacuna;

public class CreateVacunaCommandHandler : IRequestHandler<CreateVacunaCommand, string>
{
    private readonly IVacunaRepository _vacunaRepository;
    private readonly IMapper _mapper;

    public CreateVacunaCommandHandler(IVacunaRepository vacunaRepository, IMapper mapper)
    {
        _vacunaRepository = vacunaRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(CreateVacunaCommand request, CancellationToken cancellationToken)
    {
        var vacuna = _mapper.Map<Domain.Common.Vacuna>(request);
        var newVacuna = await _vacunaRepository.AddAsync(vacuna);
        return newVacuna.Id;
    }
}