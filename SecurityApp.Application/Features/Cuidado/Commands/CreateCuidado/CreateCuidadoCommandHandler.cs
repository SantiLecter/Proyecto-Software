using AutoMapper;
using MediatR;
using SecurityApp.Application.Contracts.Persistence;

namespace SecurityApp.Application.Features.Cuidado.Commands.CreateCuidado;

public class CreateCuidadoCommandHandler : IRequestHandler<CreateCuidadoCommand, string>
{
    private readonly ICuidadoRepository _cuidadoRepository;
    private readonly IMapper _mapper;

    public CreateCuidadoCommandHandler(ICuidadoRepository cuidadoRepository, IMapper mapper)
    {
        _cuidadoRepository = cuidadoRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(CreateCuidadoCommand request, CancellationToken cancellationToken)
    {
        var cuidado = _mapper.Map<Domain.Common.Cuidado>(request);
        var newCuidado = await _cuidadoRepository.AddAsync(cuidado);
        return newCuidado.Id;
    }
}