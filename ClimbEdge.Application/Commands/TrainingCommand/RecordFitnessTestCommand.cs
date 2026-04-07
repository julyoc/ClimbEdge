using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Commands.TrainingCommand
{
    public record RecordFitnessTestCommand(RecordFitnessTestDTO entity) : IRequest<GetFitnessTestDTO>;

    public class RecordFitnessTestCommandHandler : IRequestHandler<RecordFitnessTestCommand, GetFitnessTestDTO>
    {
        private readonly IFitnessTestRepository _fitnessTestRepository;

        public RecordFitnessTestCommandHandler(IFitnessTestRepository fitnessTestRepository)
        {
            _fitnessTestRepository = fitnessTestRepository;
        }

        public async Task<GetFitnessTestDTO> Handle(RecordFitnessTestCommand request, CancellationToken cancellationToken)
        {
            var test = Mapper.Map<RecordFitnessTestDTO, FitnessTest>(request.entity);
            test.InitializeSlug();
            await _fitnessTestRepository.AddAsync(test);
            await _fitnessTestRepository.SaveChangesAsync();
            return Mapper.Map<FitnessTest, GetFitnessTestDTO>(test);
        }
    }
}
