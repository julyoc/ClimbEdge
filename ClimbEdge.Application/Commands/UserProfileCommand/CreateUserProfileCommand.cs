using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Constants;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities;
using ClimbEdge.Domain.Repositories;
using ClimbEdge.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Application.Commands.UserProfileCommand
{
    public record CreateUserProfileCommand(CreateUserProfileDTO entity): IRequest<GetUserProfileDTO>;

    public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, GetUserProfileDTO>
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public CreateUserProfileCommandHandler(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }
        public async Task<GetUserProfileDTO> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<CreateUserProfileDTO, UserProfile>(request.entity);
            entity.Address = new AddressData(request.entity.Location, null, null, null, null, request.entity.Country ?? Constants.DefaultCountry);
            await _userProfileRepository.AddAsync(entity);
            var e = Mapper.Map<UserProfile, GetUserProfileDTO>(entity);
            return e;
        }
    }
}
