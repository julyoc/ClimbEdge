using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Queries.TrainingQuery
{
    public record GetPhysiologicalDataHistoryQuery(long UserId) : IRequest<IEnumerable<GetPhysiologicalDataDTO>>;

    public class GetPhysiologicalDataHistoryQueryHandler
        : IRequestHandler<GetPhysiologicalDataHistoryQuery, IEnumerable<GetPhysiologicalDataDTO>>
    {
        private readonly IPhysiologicalDataRepository _physiologicalDataRepository;

        public GetPhysiologicalDataHistoryQueryHandler(IPhysiologicalDataRepository physiologicalDataRepository)
        {
            _physiologicalDataRepository = physiologicalDataRepository;
        }

        public async Task<IEnumerable<GetPhysiologicalDataDTO>> Handle(
            GetPhysiologicalDataHistoryQuery request, CancellationToken cancellationToken)
        {
            var records = await _physiologicalDataRepository.GetAsync(
                criteria: p => p.UserId == request.UserId && !p.IsDeleted);

            return records
                .OrderByDescending(p => p.MeasurementDate)
                .Select(p => Mapper.Map<PhysiologicalData, GetPhysiologicalDataDTO>(p));
        }
    }
}
