using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Queries.TrainingQuery
{
    public record GetFitnessTestHistoryQuery(long UserId) : IRequest<IEnumerable<GetFitnessTestDTO>>;

    public class GetFitnessTestHistoryQueryHandler
        : IRequestHandler<GetFitnessTestHistoryQuery, IEnumerable<GetFitnessTestDTO>>
    {
        private readonly IFitnessTestRepository _fitnessTestRepository;

        public GetFitnessTestHistoryQueryHandler(IFitnessTestRepository fitnessTestRepository)
        {
            _fitnessTestRepository = fitnessTestRepository;
        }

        public async Task<IEnumerable<GetFitnessTestDTO>> Handle(
            GetFitnessTestHistoryQuery request, CancellationToken cancellationToken)
        {
            var records = await _fitnessTestRepository.GetAsync(
                criteria: t => t.UserId == request.UserId && !t.IsDeleted);

            return records
                .OrderByDescending(t => t.TestDate)
                .Select(t => Mapper.Map<FitnessTest, GetFitnessTestDTO>(t));
        }
    }
}
