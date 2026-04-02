using ClimbEdge.Domain.Entities.Training;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Training
{
    internal class PhysiologicalDataConfiguration : IEntityTypeConfiguration<PhysiologicalData>
    {
        public void Configure(EntityTypeBuilder<PhysiologicalData> builder)
        {
            builder.ConfigureBaseModel();
        }
    }
}
