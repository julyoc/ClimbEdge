using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;

namespace ClimbEdge.Application.Commands.MountainCommand
{
    public record UpdateMountainCommand(Guid MountainUid, UpdateMountainDTO entity) : IRequest<GetMountainDTO>;

    public class UpdateMountainCommandHandler : IRequestHandler<UpdateMountainCommand, GetMountainDTO>
    {
        private readonly IMountainRepository _mountainRepository;

        public UpdateMountainCommandHandler(IMountainRepository mountainRepository)
        {
            _mountainRepository = mountainRepository;
        }

        public async Task<GetMountainDTO> Handle(UpdateMountainCommand request, CancellationToken cancellationToken)
        {
            var mountain = await _mountainRepository.GetAsync(request.MountainUid)
                ?? throw new InvalidOperationException("Mountain not found.");

            Mapper.MapUpdate(request.entity, mountain);
            mountain.UpdateTimestamps();
            await _mountainRepository.UpdateAsync(mountain);
            await _mountainRepository.SaveChangesAsync();
            return Mapper.Map<Mountain, GetMountainDTO>(mountain);
        }
    }
}
