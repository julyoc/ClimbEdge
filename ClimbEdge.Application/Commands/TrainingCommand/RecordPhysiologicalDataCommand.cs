using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Commands.TrainingCommand
{
    public record RecordPhysiologicalDataCommand(RecordPhysiologicalDataDTO entity) : IRequest<GetPhysiologicalDataDTO>;

    public class RecordPhysiologicalDataCommandHandler : IRequestHandler<RecordPhysiologicalDataCommand, GetPhysiologicalDataDTO>
    {
        private readonly IPhysiologicalDataRepository _physioRepository;

        public RecordPhysiologicalDataCommandHandler(IPhysiologicalDataRepository physioRepository)
        {
            _physioRepository = physioRepository;
        }

        public async Task<GetPhysiologicalDataDTO> Handle(RecordPhysiologicalDataCommand request, CancellationToken cancellationToken)
        {
            var data = Mapper.Map<RecordPhysiologicalDataDTO, PhysiologicalData>(request.entity);
            data.InitializeSlug();
            await _physioRepository.AddAsync(data);
            await _physioRepository.SaveChangesAsync();
            return Mapper.Map<PhysiologicalData, GetPhysiologicalDataDTO>(data);
        }
    }
}
