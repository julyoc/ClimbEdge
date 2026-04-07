using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Repositories.Organizations;
using MediatR;

namespace ClimbEdge.Application.Commands.OrganizationCommand
{
    public record RemoveOrganizationMemberCommand(RemoveOrganizationMemberDTO entity) : IRequest;

    public class RemoveOrganizationMemberCommandHandler : IRequestHandler<RemoveOrganizationMemberCommand>
    {
        private readonly IOrganizationMemberRepository _memberRepository;

        public RemoveOrganizationMemberCommandHandler(IOrganizationMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task Handle(RemoveOrganizationMemberCommand request, CancellationToken cancellationToken)
        {
            var members = await _memberRepository.GetAsync(
                criteria: m => m.OrganizationId == request.entity.OrganizationId
                    && m.UserId == request.entity.UserId && !m.IsDeleted);

            var member = members.FirstOrDefault()
                ?? throw new InvalidOperationException("Member not found in this organization.");

            await _memberRepository.DeleteAsync(member.Uid);
            await _memberRepository.SaveChangesAsync();
        }
    }
}
