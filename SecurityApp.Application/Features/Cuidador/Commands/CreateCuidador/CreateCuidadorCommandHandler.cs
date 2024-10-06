using AutoMapper;
using MediatR;
using SecurityApp.Application.Contracts.Persistence;

namespace SecurityApp.Application.Features.Cuidador.Commands.CreateCuidador;

public class CreateCuidadorCommandHandler : IRequestHandler<CreateCuidadorCommand, string>
{
    private readonly ICuidadorRepository _cuidadorRepository;
    private readonly IMapper _mapper;
    private IRequestHandler<CreateCuidadorCommand, string> _requestHandlerImplementation;

    public CreateCuidadorCommandHandler(ICuidadorRepository cuidadorRepository, IMapper mapper)
    {
        _cuidadorRepository = cuidadorRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(CreateCuidadorCommand request, CancellationToken cancellationToken)
    {
        var cuidador = _mapper.Map<Domain.Common.Cuidador>(request);
        var newCuidador = await _cuidadorRepository.AddAsync(cuidador);
        return newCuidador.Id;
    }
}