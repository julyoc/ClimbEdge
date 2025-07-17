using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities;
using ClimbEdge.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Application.Queries.UserProfileQuery
{
    public record FindUserProfileWithUserIdQuery(long UserId) : IRequest<GetUserProfileDTO?>;
    public class FindUserProfileWithUserIdQueryHandler(IUserProfileRepository userProfileRepository) : IRequestHandler<FindUserProfileWithUserIdQuery, GetUserProfileDTO?>
    {
        private readonly IUserProfileRepository _userProfileRepository = userProfileRepository;

        public async Task<GetUserProfileDTO?> Handle(FindUserProfileWithUserIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _userProfileRepository.GetUserProfileAsync(request.UserId);
            if (entity == null) return null;
            return Mapper.Map<UserProfile, GetUserProfileDTO>(entity);
        }
    }
}
