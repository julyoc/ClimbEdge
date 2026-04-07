using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Organizations;
using ClimbEdge.Domain.Repositories.Organizations;
using MediatR;

namespace ClimbEdge.Application.Queries.OrganizationQuery
{
    public record GetOrganizationMembersQuery(long OrganizationId) : IRequest<IEnumerable<GetOrganizationMemberDTO>>;

    public class GetOrganizationMembersQueryHandler
        : IRequestHandler<GetOrganizationMembersQuery, IEnumerable<GetOrganizationMemberDTO>>
    {
        private readonly IOrganizationMemberRepository _memberRepository;

        public GetOrganizationMembersQueryHandler(IOrganizationMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<GetOrganizationMemberDTO>> Handle(
            GetOrganizationMembersQuery request, CancellationToken cancellationToken)
        {
            var members = await _memberRepository.GetAsync(
                criteria: m => m.OrganizationId == request.OrganizationId && !m.IsDeleted);

            return members.Select(m => Mapper.Map<OrganizationMember, GetOrganizationMemberDTO>(m));
        }
    }
}
