using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Entities.Organizations;
using ClimbEdge.Domain.Enums.Organizations;
using ClimbEdge.Domain.Repositories.Organizations;
using MediatR;

namespace ClimbEdge.Application.Commands.OrganizationCommand
{
    public record AddOrganizationMemberCommand(AddOrganizationMemberDTO entity) : IRequest;

    public class AddOrganizationMemberCommandHandler : IRequestHandler<AddOrganizationMemberCommand>
    {
        private readonly IOrganizationMemberRepository _memberRepository;
        private readonly IOrganizationRepository _organizationRepository;

        public AddOrganizationMemberCommandHandler(
            IOrganizationMemberRepository memberRepository,
            IOrganizationRepository organizationRepository)
        {
            _memberRepository = memberRepository;
            _organizationRepository = organizationRepository;
        }

        public async Task Handle(AddOrganizationMemberCommand request, CancellationToken cancellationToken)
        {
            var orgExists = await _organizationRepository.ExistsAsync(request.entity.OrganizationId.ToString());
            if (!orgExists) throw new InvalidOperationException("Organization not found.");

            var existing = await _memberRepository.GetAsync(
                criteria: m => m.OrganizationId == request.entity.OrganizationId
                    && m.UserId == request.entity.UserId && !m.IsDeleted);
            if (existing.Any()) throw new InvalidOperationException("User is already a member of this organization.");

            var member = new OrganizationMember
            {
                OrganizationId = request.entity.OrganizationId,
                UserId = request.entity.UserId,
                MembershipType = request.entity.MembershipType,
                Status = MembershipStatus.Active,
                JoinedAt = DateTime.UtcNow
            };
            await _memberRepository.AddAsync(member);
            await _memberRepository.SaveChangesAsync();
        }
    }
}
