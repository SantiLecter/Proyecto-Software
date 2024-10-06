using AutoMapper;
using MediatR;
using SecurityApp.Application.Contracts.Persistence;

namespace SecurityApp.Application.Features.Cuidador.Commands.DeleteCuidador;

public class DeleteCuidadorCommandHandler : IRequestHandler<DeleteCuidadorCommand, bool>
{
    private readonly ICuidadorRepository _cuidadorRepository;
    private readonly IMapper _mapper;

    public DeleteCuidadorCommandHandler(ICuidadorRepository cuidadorRepository, IMapper mapper)
    {
        _cuidadorRepository = cuidadorRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteCuidadorCommand request, CancellationToken cancellationToken)
    {
        var cuidadorMap = _mapper.Map<Domain.Common.Cuidador>(request);
        try
        {
            await _cuidadorRepository.DeleteAsync(cuidadorMap);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}