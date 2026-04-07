using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities;
using ClimbEdge.Domain.Repositories;
using MediatR;

namespace ClimbEdge.Application.Commands.UserProfileCommand
{
    public record UpdateUserProfileCommand(long UserId, UpdateUserProfileDTO entity) : IRequest<GetUserProfileDTO>;

    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, GetUserProfileDTO>
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UpdateUserProfileCommandHandler(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<GetUserProfileDTO> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = await _userProfileRepository.GetUserProfileAsync(request.UserId);
            if (profile == null) throw new InvalidOperationException("User profile not found.");
            Mapper.MapUpdate(request.entity, profile);
            profile.UpdateTimestamps();
            await _userProfileRepository.UpdateAsync(profile);
            await _userProfileRepository.SaveChangesAsync();
            return Mapper.Map<UserProfile, GetUserProfileDTO>(profile);
        }
    }
}
