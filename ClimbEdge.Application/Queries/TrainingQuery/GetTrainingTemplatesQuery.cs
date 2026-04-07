using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Queries.TrainingQuery
{
    public record GetTrainingTemplatesQuery() : IRequest<IEnumerable<GetTrainingTemplateDTO>>;

    public class GetTrainingTemplatesQueryHandler
        : IRequestHandler<GetTrainingTemplatesQuery, IEnumerable<GetTrainingTemplateDTO>>
    {
        private readonly ITrainingTemplateRepository _templateRepository;

        public GetTrainingTemplatesQueryHandler(ITrainingTemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }

        public async Task<IEnumerable<GetTrainingTemplateDTO>> Handle(
            GetTrainingTemplatesQuery request, CancellationToken cancellationToken)
        {
            var templates = await _templateRepository.GetAsync(
                criteria: t => (t.IsPublic || !t.IsDeleted) && !t.IsDeleted);

            return templates
                .OrderBy(t => t.Name)
                .Select(t => Mapper.Map<TrainingTemplate, GetTrainingTemplateDTO>(t));
        }
    }
}
