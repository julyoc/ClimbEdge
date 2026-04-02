using ClimbEdge.Domain.Entities.Training;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Training
{
    internal class FitnessTestConfiguration : IEntityTypeConfiguration<FitnessTest>
    {
        public void Configure(EntityTypeBuilder<FitnessTest> builder)
        {
            builder.ConfigureBaseModel();
        }
    }
}
