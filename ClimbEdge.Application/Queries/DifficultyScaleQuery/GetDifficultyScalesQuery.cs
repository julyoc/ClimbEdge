using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.DifficultyScales;
using ClimbEdge.Domain.Interfaces;
using ClimbEdge.Domain.Repositories.DifficultyScales;
using MediatR;

namespace ClimbEdge.Application.Queries.DifficultyScaleQuery
{
    public record GetDifficultyScalesQuery(long? DifficultyScaleNameId = null) : IRequest<IEnumerable<GetDifficultyScaleDTO>>;

    public class GetDifficultyScalesQueryHandler : IRequestHandler<GetDifficultyScalesQuery, IEnumerable<GetDifficultyScaleDTO>>
    {
        private readonly IDifficultyScaleRepository _difficultyScaleRepository;

        public GetDifficultyScalesQueryHandler(IDifficultyScaleRepository difficultyScaleRepository)
        {
            _difficultyScaleRepository = difficultyScaleRepository;
        }

        public async Task<IEnumerable<GetDifficultyScaleDTO>> Handle(GetDifficultyScalesQuery request, CancellationToken cancellationToken)
        {
            var scales = await _difficultyScaleRepository.GetAsync(
                criteria: s => !s.IsDeleted
                    && (request.DifficultyScaleNameId == null || s.DifficultyScaleNameId == request.DifficultyScaleNameId),
                orderSelectors: new[] { new OrderSelectors("IRCRA", false) }
            );
            return scales.Select(s =>
            {
                var dto = Mapper.Map<DifficultyScale, GetDifficultyScaleDTO>(s);
                dto = dto with { DifficultyScaleName = s.DifficultyScaleName?.Name ?? string.Empty };
                return dto;
            });
        }
    }
}
