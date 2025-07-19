using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClimbEdge.Domain.Entities;

namespace ClimbEdge.Infrastructure.Persistence.Configurations
{
       /// <summary>
       /// Configuración de Entity Framework para UserProfile
       /// </summary>
       public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
       {
              public void Configure(EntityTypeBuilder<UserProfile> builder)
              {
                     // Configurar propiedades heredadas de BaseModel
                     builder.ConfigureBaseModel();

                     // Configurar propiedades específicas
                     builder.Property(e => e.AppUserId)
                            .IsRequired()
                            .HasMaxLength(450);

                     builder.Property(e => e.FirstName)
                            .HasMaxLength(100);

                     builder.Property(e => e.LastName)
                            .HasMaxLength(100);

                     builder.Property(e => e.Bio)
                            .HasMaxLength(1000);

                     builder.Property(e => e.ProfilePictureUrl)
                            .HasMaxLength(500);

                     builder.Property(e => e.Website)
                            .HasMaxLength(500);

                     builder.Property(e => e.Location)
                            .HasMaxLength(200);

                     builder.Property(e => e.Country)
                            .HasMaxLength(100);

                     builder.Property(e => e.TimeZone)
                            .HasMaxLength(100);

                     builder.Property(e => e.PreferredLanguage)
                            .HasMaxLength(10);

                     builder.OwnsOne(e => e.ClimbData, e =>
                     {
                            e.Property(e => e.EmergencyContact).HasMaxLength(25);
                            e.Property(e => e.EmergencyContactName).HasMaxLength(100);
                            e.Property(e => e.ClimbingExperienceLevel).HasMaxLength(50);
                            e.Property(e => e.PreferredClimbingStyle).HasMaxLength(50);
                     });

                     builder.Property(e => e.IsPublic)
                            .HasDefaultValue(true);

                     builder.Property(e => e.EmailNotifications)
                            .HasDefaultValue(true);

                     builder.Property(e => e.PushNotifications)
                            .HasDefaultValue(true);

                     // Índices
                     builder.HasIndex(e => e.Uid).IsUnique();
                     builder.HasIndex(e => e.Slug).IsUnique();
                     builder.HasIndex(e => e.AppUserId).IsUnique();
                     builder.HasIndex(e => e.FirstName);
                     builder.HasIndex(e => e.LastName);
                     builder.HasIndex(e => e.Country);

                     // Propiedades calculadas ignoradas
                     builder.Ignore(e => e.FullName);
                     builder.Ignore(e => e.Age);
                     builder.Ignore(e => e.Initials);

                     builder.HasOne(e => e.AppUser)
                            .WithOne(e => e.UserProfile)
                            .HasForeignKey<UserProfile>(e => e.AppUserId)
                            .OnDelete(DeleteBehavior.Cascade);
              }
       }
}
