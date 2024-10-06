using AutoMapper;
using MediatR;
using SecurityApp.Application.Contracts.Persistence;

namespace SecurityApp.Application.Features.Examen.Commands.DeleteExamen;

public class DeleteExamenCommandHandler : IRequestHandler<DeleteExamenCommand, bool>
{
    private readonly IExamenRepository _examenRepository;
    private readonly IMapper _mapper;

    public DeleteExamenCommandHandler(IExamenRepository examenRepository, IMapper mapper)
    {
        _examenRepository = examenRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteExamenCommand request, CancellationToken cancellationToken)
    {
        var examenMap = _mapper.Map<Domain.Common.Examen>(request);
        try
        {
            await _examenRepository.DeleteAsync(examenMap);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}