using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Entities.Climbing;
using ClimbEdge.Domain.Repositories.Climbing;
using MediatR;

namespace ClimbEdge.Application.Commands.ClimbRouteCommand
{
    public record CreateClimbTagCommand(CreateClimbTagDTO entity) : IRequest<GetClimbTagDTO>;

    public class CreateClimbTagCommandHandler : IRequestHandler<CreateClimbTagCommand, GetClimbTagDTO>
    {
        private readonly IClimbTagRepository _climbTagRepository;

        public CreateClimbTagCommandHandler(IClimbTagRepository climbTagRepository)
        {
            _climbTagRepository = climbTagRepository;
        }

        public async Task<GetClimbTagDTO> Handle(CreateClimbTagCommand request, CancellationToken cancellationToken)
        {
            var tag = new ClimbTag
            {
                Name = request.entity.Name,
                Description = request.entity.Description
            };

            tag.InitializeSlug();
            await _climbTagRepository.AddAsync(tag);
            await _climbTagRepository.SaveChangesAsync();

            return new GetClimbTagDTO
            {
                Uid = tag.Uid,
                Slug = tag.Slug,
                Name = tag.Name,
                Description = tag.Description,
                CreatedAt = tag.CreatedAt
            };
        }
    }
}
