using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;

namespace ClimbEdge.Application.Commands.MountainCommand
{
    public record CreateMountainCommand(CreateMountainDTO entity) : IRequest<GetMountainDTO>;

    public class CreateMountainCommandHandler : IRequestHandler<CreateMountainCommand, GetMountainDTO>
    {
        private readonly IMountainRepository _mountainRepository;

        public CreateMountainCommandHandler(IMountainRepository mountainRepository)
        {
            _mountainRepository = mountainRepository;
        }

        public async Task<GetMountainDTO> Handle(CreateMountainCommand request, CancellationToken cancellationToken)
        {
            var mountain = Mapper.Map<CreateMountainDTO, Mountain>(request.entity);
            mountain.InitializeSlug();
            await _mountainRepository.AddAsync(mountain);
            await _mountainRepository.SaveChangesAsync();
            return Mapper.Map<Mountain, GetMountainDTO>(mountain);
        }
    }
}
