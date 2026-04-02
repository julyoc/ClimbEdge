using ClimbEdge.Domain.Entities;
using ClimbEdge.Domain.Entities.DifficultyScales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.DifficultyScales
{
    internal class DifficultyScaleConfiguration : IEntityTypeConfiguration<DifficultyScale>
    {
        public void Configure(EntityTypeBuilder<DifficultyScale> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(e => e.Value).IsRequired().HasMaxLength(50);
            builder.Property(e => e.IRCRA).IsRequired();

            builder.HasOne(e => e.DifficultyGroup).WithMany(e => e.DifficultyScales)
                   .HasForeignKey(e => e.DifficultyGroupId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.DifficultyScaleName).WithMany(e => e.DifficultyScales)
                   .HasForeignKey(e => e.DifficultyScaleNameId).IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Users).WithMany(e => e.DifficultyScales)
                   .UsingEntity<UserExperienceLevelScale>();

            builder.HasData(
            #region YDS
                new DifficultyScale { Id = 1, Slug = "5.0-1-1", DifficultyScaleNameId = 1, DifficultyGroupId = 1, IRCRA = 1, Value = "5.0" },
                new DifficultyScale { Id = 2, Slug = "5.1-2-1", DifficultyScaleNameId = 1, DifficultyGroupId = 1, IRCRA = 2, Value = "5.1" },
                new DifficultyScale { Id = 3, Slug = "5.2-3-1", DifficultyScaleNameId = 1, DifficultyGroupId = 1, IRCRA = 3, Value = "5.2" },
                new DifficultyScale { Id = 4, Slug = "5.3-4-1", DifficultyScaleNameId = 1, DifficultyGroupId = 1, IRCRA = 4, Value = "5.3" },
                new DifficultyScale { Id = 5, Slug = "5.4-5-1", DifficultyScaleNameId = 1, DifficultyGroupId = 1, IRCRA = 5, Value = "5.4" },
                new DifficultyScale { Id = 6, Slug = "5.5-6-1", DifficultyScaleNameId = 1, DifficultyGroupId = 1, IRCRA = 6, Value = "5.5" },
                new DifficultyScale { Id = 7, Slug = "5.6-7-1", DifficultyScaleNameId = 1, DifficultyGroupId = 1, IRCRA = 7, Value = "5.6" },
                new DifficultyScale { Id = 8, Slug = "5.7-8-1", DifficultyScaleNameId = 1, DifficultyGroupId = 1, IRCRA = 8, Value = "5.7" },
                new DifficultyScale { Id = 9, Slug = "5.8-9-1", DifficultyScaleNameId = 1, DifficultyGroupId = 1, IRCRA = 9, Value = "5.8" },
                new DifficultyScale { Id = 10, Slug = "5.9-10-1", DifficultyScaleNameId = 1, DifficultyGroupId = 1, IRCRA = 10, Value = "5.9" },
                new DifficultyScale { Id = 11, Slug = "5.10a-11-1", DifficultyScaleNameId = 1, DifficultyGroupId = 1, IRCRA = 11, Value = "5.10a" },
                new DifficultyScale { Id = 12, Slug = "5.10b-12-1", DifficultyScaleNameId = 1, DifficultyGroupId = 2, IRCRA = 12, Value = "5.10b" },
                new DifficultyScale { Id = 13, Slug = "5.10c-13-1", DifficultyScaleNameId = 1, DifficultyGroupId = 2, IRCRA = 13, Value = "5.10c" },
                new DifficultyScale { Id = 14, Slug = "5.10d-14-1", DifficultyScaleNameId = 1, DifficultyGroupId = 2, IRCRA = 14, Value = "5.10d" },
                new DifficultyScale { Id = 15, Slug = "5.11a-15-1", DifficultyScaleNameId = 1, DifficultyGroupId = 2, IRCRA = 15, Value = "5.11a" },
                new DifficultyScale { Id = 16, Slug = "5.11b-16-1", DifficultyScaleNameId = 1, DifficultyGroupId = 2, IRCRA = 16, Value = "5.11b" },
                new DifficultyScale { Id = 17, Slug = "5.11c-17-1", DifficultyScaleNameId = 1, DifficultyGroupId = 2, IRCRA = 17, Value = "5.11c" },
                new DifficultyScale { Id = 18, Slug = "5.11d-18-1", DifficultyScaleNameId = 1, DifficultyGroupId = 2, IRCRA = 18, Value = "5.11d" },
                new DifficultyScale { Id = 19, Slug = "5.12a-19-1", DifficultyScaleNameId = 1, DifficultyGroupId = 3, IRCRA = 19, Value = "5.12a" },
                new DifficultyScale { Id = 20, Slug = "5.12b-20-1", DifficultyScaleNameId = 1, DifficultyGroupId = 3, IRCRA = 20, Value = "5.12b" },
                new DifficultyScale { Id = 21, Slug = "5.12c-21-1", DifficultyScaleNameId = 1, DifficultyGroupId = 3, IRCRA = 21, Value = "5.12c" },
                new DifficultyScale { Id = 22, Slug = "5.12d-22-1", DifficultyScaleNameId = 1, DifficultyGroupId = 3, IRCRA = 22, Value = "5.12d" },
                new DifficultyScale { Id = 23, Slug = "5.13a-23-1", DifficultyScaleNameId = 1, DifficultyGroupId = 4, IRCRA = 23, Value = "5.13a" },
                new DifficultyScale { Id = 24, Slug = "5.13b-24-1", DifficultyScaleNameId = 1, DifficultyGroupId = 4, IRCRA = 24, Value = "5.13b" },
                new DifficultyScale { Id = 25, Slug = "5.13c-25-1", DifficultyScaleNameId = 1, DifficultyGroupId = 4, IRCRA = 25, Value = "5.13c" },
                new DifficultyScale { Id = 26, Slug = "5.13d-26-1", DifficultyScaleNameId = 1, DifficultyGroupId = 4, IRCRA = 26, Value = "5.13d" },
                new DifficultyScale { Id = 27, Slug = "5.14a-27-1", DifficultyScaleNameId = 1, DifficultyGroupId = 4, IRCRA = 27, Value = "5.14a" },
                new DifficultyScale { Id = 28, Slug = "5.14b-28-1", DifficultyScaleNameId = 1, DifficultyGroupId = 5, IRCRA = 28, Value = "5.14b" },
                new DifficultyScale { Id = 29, Slug = "5.14c-29-1", DifficultyScaleNameId = 1, DifficultyGroupId = 5, IRCRA = 29, Value = "5.14c" },
                new DifficultyScale { Id = 30, Slug = "5.14d-30-1", DifficultyScaleNameId = 1, DifficultyGroupId = 5, IRCRA = 30, Value = "5.14d" },
                new DifficultyScale { Id = 31, Slug = "5.15a-31-1", DifficultyScaleNameId = 1, DifficultyGroupId = 5, IRCRA = 31, Value = "5.15a" },
                new DifficultyScale { Id = 32, Slug = "5.15b-d-32-1", DifficultyScaleNameId = 1, DifficultyGroupId = 5, IRCRA = 32, Value = "5.15b-d" },
            #endregion
            #region francesa
                new DifficultyScale { Id = 33, Slug = "3-1-2", DifficultyScaleNameId = 2, DifficultyGroupId = 1, IRCRA = 1, Value = "3" },
                new DifficultyScale { Id = 34, Slug = "3+-2-2", DifficultyScaleNameId = 2, DifficultyGroupId = 1, IRCRA = 2, Value = "3+" },
                new DifficultyScale { Id = 35, Slug = "4a-3-2", DifficultyScaleNameId = 2, DifficultyGroupId = 1, IRCRA = 3, Value = "4a" },
                new DifficultyScale { Id = 36, Slug = "4b-4-2", DifficultyScaleNameId = 2, DifficultyGroupId = 1, IRCRA = 4, Value = "4b" },
                new DifficultyScale { Id = 37, Slug = "4c-5-2", DifficultyScaleNameId = 2, DifficultyGroupId = 1, IRCRA = 5, Value = "4c" },
                new DifficultyScale { Id = 38, Slug = "5a-6-2", DifficultyScaleNameId = 2, DifficultyGroupId = 1, IRCRA = 6, Value = "5a" },
                new DifficultyScale { Id = 39, Slug = "5b-7-2", DifficultyScaleNameId = 2, DifficultyGroupId = 1, IRCRA = 7, Value = "5b" },
                new DifficultyScale { Id = 40, Slug = "5c-8-2", DifficultyScaleNameId = 2, DifficultyGroupId = 1, IRCRA = 8, Value = "5c" },
                new DifficultyScale { Id = 41, Slug = "6a-9-2", DifficultyScaleNameId = 2, DifficultyGroupId = 1, IRCRA = 9, Value = "6a" },
                new DifficultyScale { Id = 42, Slug = "6a+-10-2", DifficultyScaleNameId = 2, DifficultyGroupId = 2, IRCRA = 10, Value = "6a+" },
                new DifficultyScale { Id = 43, Slug = "6b-11-2", DifficultyScaleNameId = 2, DifficultyGroupId = 2, IRCRA = 11, Value = "6b" },
                new DifficultyScale { Id = 44, Slug = "6b+-12-2", DifficultyScaleNameId = 2, DifficultyGroupId = 2, IRCRA = 12, Value = "6b+" },
                new DifficultyScale { Id = 45, Slug = "6c-13-2", DifficultyScaleNameId = 2, DifficultyGroupId = 2, IRCRA = 13, Value = "6c" },
                new DifficultyScale { Id = 46, Slug = "6c+-14-2", DifficultyScaleNameId = 2, DifficultyGroupId = 2, IRCRA = 14, Value = "6c+" },
                new DifficultyScale { Id = 47, Slug = "7a-15-2", DifficultyScaleNameId = 2, DifficultyGroupId = 2, IRCRA = 15, Value = "7a" },
                new DifficultyScale { Id = 48, Slug = "7a+-16-2", DifficultyScaleNameId = 2, DifficultyGroupId = 2, IRCRA = 16, Value = "7a+" },
                new DifficultyScale { Id = 49, Slug = "7b-17-2", DifficultyScaleNameId = 2, DifficultyGroupId = 2, IRCRA = 17, Value = "7b" },
                new DifficultyScale { Id = 50, Slug = "7b+-18-2", DifficultyScaleNameId = 2, DifficultyGroupId = 2, IRCRA = 18, Value = "7b+" },
                new DifficultyScale { Id = 51, Slug = "7c-19-2", DifficultyScaleNameId = 2, DifficultyGroupId = 3, IRCRA = 19, Value = "7c" },
                new DifficultyScale { Id = 52, Slug = "7c+-20-2", DifficultyScaleNameId = 2, DifficultyGroupId = 3, IRCRA = 20, Value = "7c+" },
                new DifficultyScale { Id = 53, Slug = "8a-21-2", DifficultyScaleNameId = 2, DifficultyGroupId = 3, IRCRA = 21, Value = "8a" },
                new DifficultyScale { Id = 54, Slug = "8a+-22-2", DifficultyScaleNameId = 2, DifficultyGroupId = 3, IRCRA = 22, Value = "8a+" },
                new DifficultyScale { Id = 55, Slug = "8b-23-2", DifficultyScaleNameId = 2, DifficultyGroupId = 4, IRCRA = 23, Value = "8b" },
                new DifficultyScale { Id = 56, Slug = "8b+-24-2", DifficultyScaleNameId = 2, DifficultyGroupId = 4, IRCRA = 24, Value = "8b+" },
                new DifficultyScale { Id = 57, Slug = "8c-25-2", DifficultyScaleNameId = 2, DifficultyGroupId = 4, IRCRA = 25, Value = "8c" },
                new DifficultyScale { Id = 58, Slug = "8c+-26-2", DifficultyScaleNameId = 2, DifficultyGroupId = 4, IRCRA = 26, Value = "8c+" },
                new DifficultyScale { Id = 59, Slug = "9a-27-2", DifficultyScaleNameId = 2, DifficultyGroupId = 4, IRCRA = 27, Value = "9a" },
                new DifficultyScale { Id = 60, Slug = "9a+-28-2", DifficultyScaleNameId = 2, DifficultyGroupId = 5, IRCRA = 28, Value = "9a+" },
                new DifficultyScale { Id = 61, Slug = "9b-29-2", DifficultyScaleNameId = 2, DifficultyGroupId = 5, IRCRA = 29, Value = "9b" },
                new DifficultyScale { Id = 62, Slug = "9b+-30-2", DifficultyScaleNameId = 2, DifficultyGroupId = 5, IRCRA = 30, Value = "9b+" },
                new DifficultyScale { Id = 63, Slug = "9c-31-2", DifficultyScaleNameId = 2, DifficultyGroupId = 5, IRCRA = 31, Value = "9c" },
                new DifficultyScale { Id = 64, Slug = "9c+-32-2", DifficultyScaleNameId = 2, DifficultyGroupId = 5, IRCRA = 32, Value = "9c+" },
            #endregion
            #region uiaa
                new DifficultyScale { Id = 65, Slug = "I-1-3", DifficultyScaleNameId = 3, DifficultyGroupId = 1, IRCRA = 1, Value = "I" },
                new DifficultyScale { Id = 66, Slug = "I-II-2-3", DifficultyScaleNameId = 3, DifficultyGroupId = 1, IRCRA = 2, Value = "I-II" },
                new DifficultyScale { Id = 67, Slug = "II-3-3", DifficultyScaleNameId = 3, DifficultyGroupId = 1, IRCRA = 3, Value = "II" },
                new DifficultyScale { Id = 68, Slug = "II-III-4-3", DifficultyScaleNameId = 3, DifficultyGroupId = 1, IRCRA = 4, Value = "II-III" },
                new DifficultyScale { Id = 69, Slug = "III-5-3", DifficultyScaleNameId = 3, DifficultyGroupId = 1, IRCRA = 5, Value = "III" },
                new DifficultyScale { Id = 70, Slug = "III+-6-3", DifficultyScaleNameId = 3, DifficultyGroupId = 1, IRCRA = 6, Value = "III+" },
                new DifficultyScale { Id = 71, Slug = "IV-7-3", DifficultyScaleNameId = 3, DifficultyGroupId = 1, IRCRA = 7, Value = "IV" },
                new DifficultyScale { Id = 72, Slug = "IV+-8-3", DifficultyScaleNameId = 3, DifficultyGroupId = 1, IRCRA = 8, Value = "IV+" },
                new DifficultyScale { Id = 73, Slug = "V--9-3", DifficultyScaleNameId = 3, DifficultyGroupId = 1, IRCRA = 9, Value = "V-" },
                new DifficultyScale { Id = 74, Slug = "V-10-3", DifficultyScaleNameId = 3, DifficultyGroupId = 2, IRCRA = 10, Value = "V" },
                new DifficultyScale { Id = 75, Slug = "V+-11-3", DifficultyScaleNameId = 3, DifficultyGroupId = 2, IRCRA = 11, Value = "V+" },
                new DifficultyScale { Id = 76, Slug = "VI--12-3", DifficultyScaleNameId = 3, DifficultyGroupId = 2, IRCRA = 12, Value = "VI-" },
                new DifficultyScale { Id = 77, Slug = "VI-13-3", DifficultyScaleNameId = 3, DifficultyGroupId = 2, IRCRA = 13, Value = "VI" },
                new DifficultyScale { Id = 78, Slug = "VI+-14-3", DifficultyScaleNameId = 3, DifficultyGroupId = 2, IRCRA = 14, Value = "VI+" },
                new DifficultyScale { Id = 79, Slug = "VII--15-3", DifficultyScaleNameId = 3, DifficultyGroupId = 2, IRCRA = 15, Value = "VII-" },
                new DifficultyScale { Id = 80, Slug = "VII-16-3", DifficultyScaleNameId = 3, DifficultyGroupId = 2, IRCRA = 16, Value = "VII" },
                new DifficultyScale { Id = 81, Slug = "VII+-17-3", DifficultyScaleNameId = 3, DifficultyGroupId = 2, IRCRA = 17, Value = "VII+" },
                new DifficultyScale { Id = 82, Slug = "VIII--18-3", DifficultyScaleNameId = 3, DifficultyGroupId = 2, IRCRA = 18, Value = "VIII-" },
                new DifficultyScale { Id = 83, Slug = "VIII-19-3", DifficultyScaleNameId = 3, DifficultyGroupId = 3, IRCRA = 19, Value = "VIII" },
                new DifficultyScale { Id = 84, Slug = "VIII+-20-3", DifficultyScaleNameId = 3, DifficultyGroupId = 3, IRCRA = 20, Value = "VIII+" },
                new DifficultyScale { Id = 85, Slug = "IX--21-3", DifficultyScaleNameId = 3, DifficultyGroupId = 3, IRCRA = 21, Value = "IX-" },
                new DifficultyScale { Id = 86, Slug = "IX-22-3", DifficultyScaleNameId = 3, DifficultyGroupId = 3, IRCRA = 22, Value = "IX" },
                new DifficultyScale { Id = 87, Slug = "IX+-23-3", DifficultyScaleNameId = 3, DifficultyGroupId = 4, IRCRA = 23, Value = "IX+" },
                new DifficultyScale { Id = 88, Slug = "X--24-3", DifficultyScaleNameId = 3, DifficultyGroupId = 4, IRCRA = 24, Value = "X-" },
                new DifficultyScale { Id = 89, Slug = "X-25-3", DifficultyScaleNameId = 3, DifficultyGroupId = 4, IRCRA = 25, Value = "X" },
                new DifficultyScale { Id = 90, Slug = "X+-26-3", DifficultyScaleNameId = 3, DifficultyGroupId = 4, IRCRA = 26, Value = "X+" },
                new DifficultyScale { Id = 91, Slug = "XI--27-3", DifficultyScaleNameId = 3, DifficultyGroupId = 4, IRCRA = 27, Value = "XI-" },
                new DifficultyScale { Id = 92, Slug = "XI-28-3", DifficultyScaleNameId = 3, DifficultyGroupId = 5, IRCRA = 28, Value = "XI" },
                new DifficultyScale { Id = 93, Slug = "XI+-29-3", DifficultyScaleNameId = 3, DifficultyGroupId = 5, IRCRA = 29, Value = "XI+" },
                new DifficultyScale { Id = 94, Slug = "XII--30-3", DifficultyScaleNameId = 3, DifficultyGroupId = 5, IRCRA = 30, Value = "XII-" },
                new DifficultyScale { Id = 95, Slug = "XII-31-3", DifficultyScaleNameId = 3, DifficultyGroupId = 5, IRCRA = 31, Value = "XII" },
                new DifficultyScale { Id = 96, Slug = "XII+-32-3", DifficultyScaleNameId = 3, DifficultyGroupId = 5, IRCRA = 32, Value = "XII+" },
            #endregion
            #region v scale
                new DifficultyScale { Id = 97, Slug = "VB-6-6", DifficultyScaleNameId = 6, DifficultyGroupId = 1, IRCRA = 6, Value = "VB" },
                new DifficultyScale { Id = 98, Slug = "V0--7-6", DifficultyScaleNameId = 6, DifficultyGroupId = 1, IRCRA = 7, Value = "V0-" },
                new DifficultyScale { Id = 99, Slug = "V0-8-6", DifficultyScaleNameId = 6, DifficultyGroupId = 1, IRCRA = 8, Value = "V0" },
                new DifficultyScale { Id = 100, Slug = "V0+-9-6", DifficultyScaleNameId = 6, DifficultyGroupId = 1, IRCRA = 9, Value = "V0+" },
                new DifficultyScale { Id = 101, Slug = "V1-10-6", DifficultyScaleNameId = 6, DifficultyGroupId = 1, IRCRA = 10, Value = "V1" },
                new DifficultyScale { Id = 102, Slug = "V2-11-6", DifficultyScaleNameId = 6, DifficultyGroupId = 1, IRCRA = 11, Value = "V2" },
                new DifficultyScale { Id = 103, Slug = "V3-12-6", DifficultyScaleNameId = 6, DifficultyGroupId = 1, IRCRA = 12, Value = "V3" },
                new DifficultyScale { Id = 104, Slug = "V4-13-6", DifficultyScaleNameId = 6, DifficultyGroupId = 2, IRCRA = 13, Value = "V4" },
                new DifficultyScale { Id = 105, Slug = "V5-14-6", DifficultyScaleNameId = 6, DifficultyGroupId = 2, IRCRA = 14, Value = "V5" },
                new DifficultyScale { Id = 106, Slug = "V6-15-6", DifficultyScaleNameId = 6, DifficultyGroupId = 2, IRCRA = 15, Value = "V6" },
                new DifficultyScale { Id = 107, Slug = "V7-16-6", DifficultyScaleNameId = 6, DifficultyGroupId = 2, IRCRA = 16, Value = "V7" },
                new DifficultyScale { Id = 108, Slug = "V8-17-6", DifficultyScaleNameId = 6, DifficultyGroupId = 2, IRCRA = 17, Value = "V8" },
                new DifficultyScale { Id = 109, Slug = "V9-18-6", DifficultyScaleNameId = 6, DifficultyGroupId = 2, IRCRA = 18, Value = "V9" },
                new DifficultyScale { Id = 110, Slug = "V10-19-6", DifficultyScaleNameId = 6, DifficultyGroupId = 3, IRCRA = 19, Value = "V10" },
                new DifficultyScale { Id = 111, Slug = "V11-20-6", DifficultyScaleNameId = 6, DifficultyGroupId = 3, IRCRA = 20, Value = "V11" },
                new DifficultyScale { Id = 112, Slug = "V12-21-6", DifficultyScaleNameId = 6, DifficultyGroupId = 3, IRCRA = 21, Value = "V12" },
                new DifficultyScale { Id = 113, Slug = "V13-22-6", DifficultyScaleNameId = 6, DifficultyGroupId = 3, IRCRA = 22, Value = "V13" },
                new DifficultyScale { Id = 114, Slug = "V14-23-6", DifficultyScaleNameId = 6, DifficultyGroupId = 4, IRCRA = 23, Value = "V14" },
                new DifficultyScale { Id = 115, Slug = "V15-24-6", DifficultyScaleNameId = 6, DifficultyGroupId = 4, IRCRA = 24, Value = "V15" },
                new DifficultyScale { Id = 116, Slug = "V16-25-6", DifficultyScaleNameId = 6, DifficultyGroupId = 4, IRCRA = 25, Value = "V16" },
                new DifficultyScale { Id = 117, Slug = "V17-26-6", DifficultyScaleNameId = 6, DifficultyGroupId = 5, IRCRA = 26, Value = "V17" },
            #endregion
            #region font scale
                new DifficultyScale { Id = 118, Slug = "3-6-7", DifficultyScaleNameId = 7, DifficultyGroupId = 1, IRCRA = 6, Value = "3" },
                new DifficultyScale { Id = 119, Slug = "3+-7-7", DifficultyScaleNameId = 7, DifficultyGroupId = 1, IRCRA = 7, Value = "3+" },
                new DifficultyScale { Id = 120, Slug = "4-8-7", DifficultyScaleNameId = 7, DifficultyGroupId = 1, IRCRA = 8, Value = "4" },
                new DifficultyScale { Id = 121, Slug = "4+-9-7", DifficultyScaleNameId = 7, DifficultyGroupId = 1, IRCRA = 9, Value = "4+" },
                new DifficultyScale { Id = 122, Slug = "5-10-7", DifficultyScaleNameId = 7, DifficultyGroupId = 1, IRCRA = 10, Value = "5" },
                new DifficultyScale { Id = 123, Slug = "5+-11-7", DifficultyScaleNameId = 7, DifficultyGroupId = 1, IRCRA = 11, Value = "5+" },
                new DifficultyScale { Id = 124, Slug = "6A-12-7", DifficultyScaleNameId = 7, DifficultyGroupId = 1, IRCRA = 12, Value = "6A" },
                new DifficultyScale { Id = 125, Slug = "6A+-13-7", DifficultyScaleNameId = 7, DifficultyGroupId = 2, IRCRA = 13, Value = "6A+" },
                new DifficultyScale { Id = 126, Slug = "6B-14-7", DifficultyScaleNameId = 7, DifficultyGroupId = 2, IRCRA = 14, Value = "6B" },
                new DifficultyScale { Id = 127, Slug = "6B+-15-7", DifficultyScaleNameId = 7, DifficultyGroupId = 2, IRCRA = 15, Value = "6B+" },
                new DifficultyScale { Id = 128, Slug = "6C-16-7", DifficultyScaleNameId = 7, DifficultyGroupId = 2, IRCRA = 16, Value = "6C" },
                new DifficultyScale { Id = 129, Slug = "6C+-17-7", DifficultyScaleNameId = 7, DifficultyGroupId = 2, IRCRA = 17, Value = "6C+" },
                new DifficultyScale { Id = 130, Slug = "7A-18-7", DifficultyScaleNameId = 7, DifficultyGroupId = 2, IRCRA = 18, Value = "7A" },
                new DifficultyScale { Id = 131, Slug = "7A+-19-7", DifficultyScaleNameId = 7, DifficultyGroupId = 3, IRCRA = 19, Value = "7A+" },
                new DifficultyScale { Id = 132, Slug = "7B-20-7", DifficultyScaleNameId = 7, DifficultyGroupId = 3, IRCRA = 20, Value = "7B" },
                new DifficultyScale { Id = 133, Slug = "7B+-21-7", DifficultyScaleNameId = 7, DifficultyGroupId = 3, IRCRA = 21, Value = "7B+" },
                new DifficultyScale { Id = 134, Slug = "7C-22-7", DifficultyScaleNameId = 7, DifficultyGroupId = 3, IRCRA = 22, Value = "7C" },
                new DifficultyScale { Id = 135, Slug = "7C+-23-7", DifficultyScaleNameId = 7, DifficultyGroupId = 4, IRCRA = 23, Value = "7C+" },
                new DifficultyScale { Id = 136, Slug = "8A-24-7", DifficultyScaleNameId = 7, DifficultyGroupId = 4, IRCRA = 24, Value = "8A" },
                new DifficultyScale { Id = 137, Slug = "8A+-25-7", DifficultyScaleNameId = 7, DifficultyGroupId = 4, IRCRA = 25, Value = "8A+" },
                new DifficultyScale { Id = 138, Slug = "8B-26-7", DifficultyScaleNameId = 7, DifficultyGroupId = 4, IRCRA = 26, Value = "8B" },
                new DifficultyScale { Id = 139, Slug = "8B+-27-7", DifficultyScaleNameId = 7, DifficultyGroupId = 5, IRCRA = 27, Value = "8B+" },
                new DifficultyScale { Id = 140, Slug = "8C-28-7", DifficultyScaleNameId = 7, DifficultyGroupId = 5, IRCRA = 28, Value = "8C" },
                new DifficultyScale { Id = 141, Slug = "8C+-29-7", DifficultyScaleNameId = 7, DifficultyGroupId = 5, IRCRA = 29, Value = "8C+" },
                new DifficultyScale { Id = 142, Slug = "9A-30-7", DifficultyScaleNameId = 7, DifficultyGroupId = 5, IRCRA = 30, Value = "9A" },
                new DifficultyScale { Id = 143, Slug = "9A+-31-7", DifficultyScaleNameId = 7, DifficultyGroupId = 5, IRCRA = 31, Value = "9A+" },
                new DifficultyScale { Id = 144, Slug = "9A+-32-7", DifficultyScaleNameId = 7, DifficultyGroupId = 5, IRCRA = 32, Value = "9A+" },
                #endregion
            #region a scale
                new DifficultyScale { Id = 145, Slug = "A0-1-4", DifficultyScaleNameId = 4, DifficultyGroupId = 1, IRCRA = 1, Value = "A0", Description = "Simple pull or clip; minimal aid, very secure." },
                new DifficultyScale { Id = 146, Slug = "A1-2-4", DifficultyScaleNameId = 4, DifficultyGroupId = 2, IRCRA = 2, Value = "A1", Description = "Solid gear placements; short safe falls." },
                new DifficultyScale { Id = 147, Slug = "A2-3-4", DifficultyScaleNameId = 4, DifficultyGroupId = 3, IRCRA = 3, Value = "A2", Description = "Mostly solid gear with some marginal pieces; long but safe falls." },
                new DifficultyScale { Id = 148, Slug = "A3-4-4", DifficultyScaleNameId = 4, DifficultyGroupId = 4, IRCRA = 4, Value = "A3", Description = "Multiple marginal placements; long falls possible." },
                new DifficultyScale { Id = 149, Slug = "A4-5-4", DifficultyScaleNameId = 4, DifficultyGroupId = 5, IRCRA = 5, Value = "A4", Description = "Series of very poor placements; extremely long, dangerous falls." },
                new DifficultyScale { Id = 150, Slug = "A5-6-4", DifficultyScaleNameId = 4, DifficultyGroupId = 5, IRCRA = 6, Value = "A5", Description = "All placements likely to fail in a fall; fall would be fatal." },
            #endregion
            #region c scale 
                new DifficultyScale { Id = 151, Slug = "C0-1-5", DifficultyScaleNameId = 5, DifficultyGroupId = 1, IRCRA = 1, Value = "C0", Description = "Pulling on gear or bolts without hammering; very secure." },
                new DifficultyScale { Id = 152, Slug = "C1-2-5", DifficultyScaleNameId = 5, DifficultyGroupId = 2, IRCRA = 2, Value = "C1", Description = "All placements solid and clean; safe falls." },
                new DifficultyScale { Id = 153, Slug = "C2-3-5", DifficultyScaleNameId = 5, DifficultyGroupId = 3, IRCRA = 3, Value = "C2", Description = "Some marginal pieces but generally safe; long falls possible." },
                new DifficultyScale { Id = 154, Slug = "C3-4-5", DifficultyScaleNameId = 5, DifficultyGroupId = 4, IRCRA = 4, Value = "C3", Description = "Multiple unreliable placements; long potentially dangerous falls." },
                new DifficultyScale { Id = 155, Slug = "C4-5-5", DifficultyScaleNameId = 5, DifficultyGroupId = 4, IRCRA = 5, Value = "C4", Description = "Sustained sequences of marginal gear; serious, very long falls." },
                new DifficultyScale { Id = 156, Slug = "C5-6-5", DifficultyScaleNameId = 5, DifficultyGroupId = 5, IRCRA = 6, Value = "C5", Description = "Fall likely to rip all clean gear; fall could be fatal." },
            #endregion
            #region wi
                new DifficultyScale { Id = 157, Slug = "WI1-1-8", DifficultyScaleNameId = 8, DifficultyGroupId = 1, IRCRA = 1, Value = "WI1", Description = "Low-angle ice, easy movement, secure tool placements." },
                new DifficultyScale { Id = 158, Slug = "WI2-2-8", DifficultyScaleNameId = 8, DifficultyGroupId = 2, IRCRA = 2, Value = "WI2", Description = "Consistent 60° ice with occasional steeper steps; good protection." },
                new DifficultyScale { Id = 159, Slug = "WI3-3-8", DifficultyScaleNameId = 8, DifficultyGroupId = 3, IRCRA = 3, Value = "WI3", Description = "Sustained 70° ice; short vertical steps; reliable protection." },
                new DifficultyScale { Id = 160, Slug = "WI4-4-8", DifficultyScaleNameId = 8, DifficultyGroupId = 3, IRCRA = 4, Value = "WI4", Description = "Continuous 80° ice with vertical sections; pumpy and technical." },
                new DifficultyScale { Id = 161, Slug = "WI5-5-8", DifficultyScaleNameId = 8, DifficultyGroupId = 4, IRCRA = 5, Value = "WI5", Description = "Long vertical pitches with fewer rests; demanding protection." },
                new DifficultyScale { Id = 162, Slug = "WI6-6-8", DifficultyScaleNameId = 8, DifficultyGroupId = 4, IRCRA = 6, Value = "WI6", Description = "Sustained vertical or overhanging ice; very technical and serious." },
                new DifficultyScale { Id = 163, Slug = "WI7-7-8", DifficultyScaleNameId = 8, DifficultyGroupId = 5, IRCRA = 7, Value = "WI7", Description = "Overhanging ice with poor protection; elite difficulty, dangerous." },
            #endregion
            #region ai
                new DifficultyScale { Id = 164, Slug = "AI1-1-9", DifficultyScaleNameId = 9, DifficultyGroupId = 1, IRCRA = 1, Value = "AI1", Description = "Low-angle alpine ice; simple movement; minimal exposure." },
                new DifficultyScale { Id = 165, Slug = "AI2-2-9", DifficultyScaleNameId = 9, DifficultyGroupId = 2, IRCRA = 2, Value = "AI2", Description = "Consistent 50–60° ice; easy protection; moderate commitment." },
                new DifficultyScale { Id = 166, Slug = "AI3-3-9", DifficultyScaleNameId = 9, DifficultyGroupId = 3, IRCRA = 3, Value = "AI3", Description = "Sustained steep ice with short vertical steps; increasing exposure." },
                new DifficultyScale { Id = 167, Slug = "AI4-4-9", DifficultyScaleNameId = 9, DifficultyGroupId = 4, IRCRA = 4, Value = "AI4", Description = "Long steep sections, complex protection, high-altitude seriousness." },
                new DifficultyScale { Id = 168, Slug = "AI5-5-9", DifficultyScaleNameId = 9, DifficultyGroupId = 4, IRCRA = 5, Value = "AI5", Description = "Near-vertical alpine ice; very sustained; protection challenging." },
                new DifficultyScale { Id = 169, Slug = "AI6-6-9", DifficultyScaleNameId = 9, DifficultyGroupId = 5, IRCRA = 6, Value = "AI6", Description = "Vertical or overhanging ice in high exposure terrain; extreme commitment." },
            #endregion
            #region french ice
                new DifficultyScale { Id = 170, Slug = "3-1-10", DifficultyScaleNameId = 10, DifficultyGroupId = 1, IRCRA = 1, Value = "3", Description = "Moderate-angle ice; simple placements; suitable for beginners." },
                new DifficultyScale { Id = 171, Slug = "4-2-10", DifficultyScaleNameId = 10, DifficultyGroupId = 2, IRCRA = 2, Value = "4", Description = "Steeper ice with short vertical moves; moderate technicality." },
                new DifficultyScale { Id = 172, Slug = "5-3-10", DifficultyScaleNameId = 10, DifficultyGroupId = 3, IRCRA = 3, Value = "5", Description = "Pumpy vertical climbing; sustained technical sequences." },
                new DifficultyScale { Id = 173, Slug = "5+-4-10", DifficultyScaleNameId = 10, DifficultyGroupId = 4, IRCRA = 4, Value = "5+", Description = "Long sustained sections with difficult protection; advanced skill required." },
                new DifficultyScale { Id = 174, Slug = "6-5-10", DifficultyScaleNameId = 10, DifficultyGroupId = 4, IRCRA = 5, Value = "6", Description = "Very steep or slightly overhanging ice; highly demanding climbing." },
                new DifficultyScale { Id = 175, Slug = "7-6-10", DifficultyScaleNameId = 10, DifficultyGroupId = 5, IRCRA = 6, Value = "7", Description = "Extreme difficulty; fragile or overhanging features; expert-only terrain." },
            #endregion
            #region m scale
                new DifficultyScale { Id = 176, Slug = "M1-1-11", DifficultyScaleNameId = 11, DifficultyGroupId = 1, IRCRA = 1, Value = "M1", Description = "Easy mixed terrain with low angle and secure holds." },
                new DifficultyScale { Id = 177, Slug = "M2-2-11", DifficultyScaleNameId = 11, DifficultyGroupId = 1, IRCRA = 2, Value = "M2", Description = "Moderate mixed climbing; some technical tool placements." },
                new DifficultyScale { Id = 178, Slug = "M3-3-11", DifficultyScaleNameId = 11, DifficultyGroupId = 2, IRCRA = 3, Value = "M3", Description = "Steeper sections; balance moves and secure tool hooks." },
                new DifficultyScale { Id = 179, Slug = "M4-4-11", DifficultyScaleNameId = 11, DifficultyGroupId = 2, IRCRA = 4, Value = "M4", Description = "Vertical or near-vertical mixed terrain; technical movement." },
                new DifficultyScale { Id = 180, Slug = "M5-5-11", DifficultyScaleNameId = 11, DifficultyGroupId = 2, IRCRA = 5, Value = "M5", Description = "Sustained vertical moves with delicate placements." },
                new DifficultyScale { Id = 181, Slug = "M6-6-11", DifficultyScaleNameId = 11, DifficultyGroupId = 3, IRCRA = 6, Value = "M6", Description = "Difficult mixed climbing; powerful and technical hooking." },
                new DifficultyScale { Id = 182, Slug = "M7-7-11", DifficultyScaleNameId = 11, DifficultyGroupId = 3, IRCRA = 7, Value = "M7", Description = "Steep climbing with overhanging sequences; pumpy." },
                new DifficultyScale { Id = 183, Slug = "M8-8-11", DifficultyScaleNameId = 11, DifficultyGroupId = 3, IRCRA = 8, Value = "M8", Description = "Long overhangs and challenging technical hooks." },
                new DifficultyScale { Id = 184, Slug = "M9-9-11", DifficultyScaleNameId = 11, DifficultyGroupId = 4, IRCRA = 9, Value = "M9", Description = "Significant overhangs, endurance-based sequences." },
                new DifficultyScale { Id = 185, Slug = "M10-10-11", DifficultyScaleNameId = 11, DifficultyGroupId = 4, IRCRA = 10, Value = "M10", Description = "Extreme overhangs with continuous powerful moves." },
                new DifficultyScale { Id = 186, Slug = "M11-11-11", DifficultyScaleNameId = 11, DifficultyGroupId = 4, IRCRA = 11, Value = "M11", Description = "Competition-level difficulty; massive roofs." },
                new DifficultyScale { Id = 187, Slug = "M12-12-11", DifficultyScaleNameId = 11, DifficultyGroupId = 5, IRCRA = 12, Value = "M12", Description = "Highly athletic movements on long overhangs." },
                new DifficultyScale { Id = 188, Slug = "M13-13-11", DifficultyScaleNameId = 11, DifficultyGroupId = 5, IRCRA = 13, Value = "M13", Description = "Elite mixed climbing with extreme overhanging terrain." },
            #endregion
            #region d scale
                new DifficultyScale { Id = 189, Slug = "D4-1-12", DifficultyScaleNameId = 12, DifficultyGroupId = 1, IRCRA = 1, Value = "D4", Description = "Moderate drytool terrain; secure hooks and holds." },
                new DifficultyScale { Id = 190, Slug = "D5-2-12", DifficultyScaleNameId = 12, DifficultyGroupId = 1, IRCRA = 2, Value = "D5", Description = "Steeper terrain with precise tool placements." },
                new DifficultyScale { Id = 191, Slug = "D6-4-12", DifficultyScaleNameId = 12, DifficultyGroupId = 2, IRCRA = 4, Value = "D6", Description = "Vertical drytooling requiring technical accuracy." },
                new DifficultyScale { Id = 192, Slug = "D7-5-12", DifficultyScaleNameId = 12, DifficultyGroupId = 2, IRCRA = 5, Value = "D7", Description = "Sustained steep sections; powerful hooking." },
                new DifficultyScale { Id = 193, Slug = "D8-7-12", DifficultyScaleNameId = 12, DifficultyGroupId = 3, IRCRA = 7, Value = "D8", Description = "Long overhangs requiring endurance and technique." },
                new DifficultyScale { Id = 194, Slug = "D9-8-12", DifficultyScaleNameId = 12, DifficultyGroupId = 3, IRCRA = 8, Value = "D9", Description = "Overhanging terrain with complex hook sequences." },
                new DifficultyScale { Id = 195, Slug = "D10-9-12", DifficultyScaleNameId = 12, DifficultyGroupId = 4, IRCRA = 9, Value = "D10", Description = "Massive overhangs; advanced drytooling skill required." },
                new DifficultyScale { Id = 196, Slug = "D11-11-12", DifficultyScaleNameId = 12, DifficultyGroupId = 4, IRCRA = 11, Value = "D11", Description = "Competition-level difficulty on long roofs." },
                new DifficultyScale { Id = 197, Slug = "D12-12-12", DifficultyScaleNameId = 12, DifficultyGroupId = 5, IRCRA = 12, Value = "D12", Description = "Very powerful sequences on extreme overhangs." },
                new DifficultyScale { Id = 198, Slug = "D13-13-12", DifficultyScaleNameId = 12, DifficultyGroupId = 5, IRCRA = 13, Value = "D13", Description = "Elite-level difficulty; long, pumpy roofs." },
                new DifficultyScale { Id = 199, Slug = "D14-13-12", DifficultyScaleNameId = 12, DifficultyGroupId = 5, IRCRA = 13, Value = "D14", Description = "World-class difficulty; sustained extreme movements." },
            #endregion
            #region FRENCH VIA FERRATA SCALE
                new DifficultyScale { Id = 200, Slug = "F-1-13", DifficultyScaleNameId = 13, DifficultyGroupId = 1, IRCRA = 1, Value = "F", Description = "Easy; simple steps and minimal exposure." },
                new DifficultyScale { Id = 201, Slug = "PD-2-13", DifficultyScaleNameId = 13, DifficultyGroupId = 2, IRCRA = 2, Value = "PD", Description = "Slightly difficult; moderate steepness and exposure." },
                new DifficultyScale { Id = 202, Slug = "AD-3-13", DifficultyScaleNameId = 13, DifficultyGroupId = 3, IRCRA = 3, Value = "AD", Description = "Fairly difficult; steeper sections requiring strength." },
                new DifficultyScale { Id = 203, Slug = "D-4-13", DifficultyScaleNameId = 13, DifficultyGroupId = 3, IRCRA = 4, Value = "D", Description = "Difficult; vertical sections and significant exposure." },
                new DifficultyScale { Id = 204, Slug = "TD-5-13", DifficultyScaleNameId = 13, DifficultyGroupId = 4, IRCRA = 5, Value = "TD", Description = "Very difficult; strenuous, with continuous demanding moves." },
                new DifficultyScale { Id = 205, Slug = "ED-6-13", DifficultyScaleNameId = 13, DifficultyGroupId = 5, IRCRA = 6, Value = "ED", Description = "Extremely difficult; overhangs and high exposure." },
            #endregion
            #region k scale
                new DifficultyScale { Id = 206, Slug = "K1-1-14", DifficultyScaleNameId = 14, DifficultyGroupId = 1, IRCRA = 1, Value = "K1", Description = "Very easy; minimal steepness and exposure." },
                new DifficultyScale { Id = 207, Slug = "K2-2-14", DifficultyScaleNameId = 14, DifficultyGroupId = 2, IRCRA = 2, Value = "K2", Description = "Easy; moderate ladders and metal holds." },
                new DifficultyScale { Id = 208, Slug = "K3-3-14", DifficultyScaleNameId = 14, DifficultyGroupId = 3, IRCRA = 3, Value = "K3", Description = "Moderate; steeper sections and continuous effort." },
                new DifficultyScale { Id = 209, Slug = "K4-4-14", DifficultyScaleNameId = 14, DifficultyGroupId = 3, IRCRA = 4, Value = "K4", Description = "Difficult; vertical terrain and strong exposure." },
                new DifficultyScale { Id = 210, Slug = "K5-5-14", DifficultyScaleNameId = 14, DifficultyGroupId = 4, IRCRA = 5, Value = "K5", Description = "Very difficult; overhanging sections requiring strength." },
                new DifficultyScale { Id = 211, Slug = "K6-6-14", DifficultyScaleNameId = 14, DifficultyGroupId = 5, IRCRA = 6, Value = "K6", Description = "Extremely difficult; technical and highly exposed climbing." },
            #endregion
            #region swiss scale
                new DifficultyScale { Id = 212, Slug = "A-1-15", DifficultyScaleNameId = 15, DifficultyGroupId = 1, IRCRA = 1, Value = "A", Description = "Easy; well-secured sections with minimal difficulty." },
                new DifficultyScale { Id = 213, Slug = "B-2-15", DifficultyScaleNameId = 15, DifficultyGroupId = 2, IRCRA = 2, Value = "B", Description = "Moderately difficult; steeper segments requiring effort." },
                new DifficultyScale { Id = 214, Slug = "C-3-15", DifficultyScaleNameId = 15, DifficultyGroupId = 3, IRCRA = 3, Value = "C", Description = "Difficult; steep and exposed climbing." },
                new DifficultyScale { Id = 215, Slug = "D-4-15", DifficultyScaleNameId = 15, DifficultyGroupId = 4, IRCRA = 4, Value = "D", Description = "Very difficult; overhangs and minimal artificial holds." },
                new DifficultyScale { Id = 216, Slug = "E-5-15", DifficultyScaleNameId = 15, DifficultyGroupId = 5, IRCRA = 5, Value = "E", Description = "Extremely difficult; serious exposure and sustained difficulty." },
            #endregion
            #region FRENCH ALPINE GRADE
                new DifficultyScale { Id = 217, Slug = "F-1-16", DifficultyScaleNameId = 16, DifficultyGroupId = 1, IRCRA = 1, Value = "F", Description = "Easy alpine route; minimal technical difficulty." },
                new DifficultyScale { Id = 218, Slug = "PD-2-16", DifficultyScaleNameId = 16, DifficultyGroupId = 2, IRCRA = 2, Value = "PD", Description = "Slightly difficult; some technical sections or exposure." },
                new DifficultyScale { Id = 219, Slug = "AD-3-16", DifficultyScaleNameId = 16, DifficultyGroupId = 2, IRCRA = 3, Value = "AD", Description = "Fairly difficult; mixed terrain and moderate exposure." },
                new DifficultyScale { Id = 220, Slug = "D-4-16", DifficultyScaleNameId = 16, DifficultyGroupId = 3, IRCRA = 4, Value = "D", Description = "Difficult; sustained technical sections with serious exposure." },
                new DifficultyScale { Id = 221, Slug = "TD/MD-5-16", DifficultyScaleNameId = 16, DifficultyGroupId = 4, IRCRA = 5, Value = "TD/MD", Description = "Very difficult; long and committing technical terrain." },
                new DifficultyScale { Id = 222, Slug = "ED-6-16", DifficultyScaleNameId = 16, DifficultyGroupId = 4, IRCRA = 6, Value = "ED", Description = "Extremely difficult; highly technical and exposed alpine climbing." },
                new DifficultyScale { Id = 223, Slug = "ABO-7-16", DifficultyScaleNameId = 16, DifficultyGroupId = 5, IRCRA = 7, Value = "ABO", Description = "Abominably difficult; extreme commitment and danger." },
            #endregion
            #region EXPOSURE RATING
                new DifficultyScale { Id = 224, Slug = "PG-1-17", DifficultyScaleNameId = 17, IRCRA = 1, Value = "PG", Description = "Low exposure; short falls with minimal consequence." },
                new DifficultyScale { Id = 225, Slug = "R-2-17", DifficultyScaleNameId = 17, IRCRA = 2, Value = "R", Description = "Serious exposure; long falls or poor protection." },
                new DifficultyScale { Id = 226, Slug = "X-3-17", DifficultyScaleNameId = 17, IRCRA = 3, Value = "X", Description = "Extreme exposure; falls likely fatal or unprotectable." }
            #endregion
            );
        }
    }
}
