using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities;
using ClimbEdge.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Application.Commands.UserProfileCommand
{
    public record CreateUserProfileCommand(CreateUserProfileDTO entity): IRequest<UserProfile>;

    public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, UserProfile>
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public CreateUserProfileCommandHandler(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }
        public async Task<UserProfile> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<CreateUserProfileDTO, UserProfile>(request.entity);
            await _userProfileRepository.AddAsync(entity);
            return entity;
        }
    }
}
