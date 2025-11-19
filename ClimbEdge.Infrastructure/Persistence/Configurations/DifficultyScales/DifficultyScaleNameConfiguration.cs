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
    internal class DifficultyScaleNameConfiguration : IEntityTypeConfiguration<DifficultyScaleName>
    {
        public void Configure(EntityTypeBuilder<DifficultyScaleName> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasIndex(e => e.Name).IsUnique();

            builder.HasOne(e => e.DifficultyScaleType).WithMany(e => e.DifficultyScaleNames).HasForeignKey(e => e.DifficultyScaleTypeId).IsRequired().OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new DifficultyScaleName { Id = 1, Slug = "YDS", DifficultyScaleTypeId = 1, Name = "YDS", Description = "The Yosemite Decimal System (YDS) is a climbing grade scale used in North America to rate the difficulty of roped climbs, from Class 1 (walking) to Class 5 (technical rock climbing).\r\nWithin Class 5, it ranges from 5.0 to 5.15, describing technical difficulty, endurance, and exposure." },
                new DifficultyScaleName { Id = 2, Slug = "French Scale", DifficultyScaleTypeId = 1, Name = "French Scale", Description = "The French Scale is an internationally used grading system for sport climbing that rates the technical difficulty and sustained effort of a route." },
                new DifficultyScaleName { Id = 3, Slug = "UIAA", DifficultyScaleTypeId = 1, Name = "UIAA", Description = "The UIAA Scale is a traditional climbing grading system developed by the International Climbing and Mountaineering Federation to rate the technical difficulty of rock climbs." },
                new DifficultyScaleName { Id = 4, Slug = "A-Scale", DifficultyScaleTypeId = 2, Name = "A-Scale", Description = "Traditional aid (A-Scale) climbing uses pitons, hooks, heads, and hammered gear to ascend, with difficulty rated from A0 to A5 based on protection quality and fall risk.\r\nIt focuses on gear strength, placement reliability, and the seriousness of potential falls." },
                new DifficultyScaleName { Id = 5, Slug = "C-Scale", DifficultyScaleTypeId = 2, Name = "C-Scale", Description = "Clean aid (C-Scale) climbing avoids hammered gear and relies only on passive or camming protection, graded C0 to C5 according to placement difficulty and danger.\r\nIt emphasizes using removable gear to protect the rock while maintaining the same commitment as traditional aid." },
                new DifficultyScaleName { Id = 6, Slug = "V-Scale", DifficultyScaleTypeId = 3, Name = "V-Scale", Description = "The Vermin Scale (V-Scale) is a bouldering grading system created by John “Vermin” Sherman to rate the physical and technical difficulty of boulder problems." },
                new DifficultyScaleName { Id = 7, Slug = "Font Scale", DifficultyScaleTypeId = 3, Name = "Font Scale", Description = "The Fontainebleau Scale (Font Scale) is a bouldering grading system originating in the Fontainebleau forest in France, rating both the technical difficulty and complexity of movements." },
                new DifficultyScaleName { Id = 8, Slug = "WI", DifficultyScaleTypeId = 4, Name = "WI", Description = "The Water Ice (WI) scale grades the difficulty of frozen waterfall climbing, from WI1 to WI7+, based on steepness, continuity, and ice quality.\r\nIt focuses on sustained angle, protection quality, and technical tool/footwork demands." },
                new DifficultyScaleName { Id = 9, Slug = "AI", DifficultyScaleTypeId = 4, Name = "AI", Description = "The Alpine Ice (AI) scale rates ice climbing found on high-mountain faces and couloirs, from AI1 to AI6, emphasizing altitude, exposure, and commitment.\r\nIt reflects overall seriousness more than pure steepness, including weather and terrain hazards." },
                new DifficultyScaleName { Id = 10, Slug = "French Ice", DifficultyScaleTypeId = 4, Name = "French Ice", Description = "The French Ice scale grades technical difficulty in ice climbing using mixed-style notation like 3, 4, 5, 6, 7 with +/− refinements.\r\nIt evaluates technical moves, steepness, and sustained sections similar to rock grade style but adapted to ice." },
                new DifficultyScaleName { Id = 11, Slug = "M-Scale", DifficultyScaleTypeId = 5, Name = "M-Scale", Description = "The M Scale grades modern mixed climbing from M1 to M13+, evaluating difficulty on terrain that combines rock and ice using ice tools and crampons.\r\nIt focuses on steepness, technical tool placements, and athletic moves on rock features." },
                new DifficultyScaleName { Id = 12, Slug = "D-Scale", DifficultyScaleTypeId = 5, Name = "D-Scale", Description = "The D Scale rates pure drytooling climbs from D4 to D14+, where climbers use tools on rock without ice.\r\nIt emphasizes overhangs, precision hooking, and sustained strength-based movement." },
                new DifficultyScaleName { Id = 13, Slug = "French Via Ferrata Scale", DifficultyScaleTypeId = 6, Name = "French Via Ferrata Scale", Description = "The French via ferrata scale rates routes from F (easy) to ED (extremely difficult), based on physical effort, exposure, and technical movement.\r\nIt emphasizes overall seriousness, including sustained sections, overhangs, and psychological commitment." },
                new DifficultyScaleName { Id = 14, Slug = "K-Scale", DifficultyScaleTypeId = 6, Name = "K-Scale", Description = "The German K-Scale grades via ferratas from K1 to K6, focusing on steepness, required strength, and the difficulty of metal rungs, ladders, and cable sections.\r\nHigher grades indicate more overhangs, athletic moves, and increased exposure." },
                new DifficultyScaleName { Id = 15, Slug = "Swiss Scale", DifficultyScaleTypeId = 6, Name = "Swiss Scale", Description = "The Swiss Scale classifies individual sections of a via ferrata from A (easy) to E (extreme), evaluating technical moves and spacing of artificial holds.\r\nIt highlights precise difficulty in short segments, especially where protection or holds are minimal." },
                new DifficultyScaleName { Id = 16, Slug = "French Alpine Grade", DifficultyScaleTypeId = 7, Name = "French Alpine Grade", Description = "The French Alpine Grade rates the overall difficulty of alpine routes from F to ABO, combining technical challenges with exposure, altitude, commitment, and terrain complexity.\r\nIt provides a global assessment of long, multi-discipline ascents, integrating rock, snow, ice, and mixed sections into a single grade." },
                new DifficultyScaleName { Id = 17, Slug = "Exposure Rating", DifficultyScaleTypeId = 8, Name = "Exposure Rating", Description = "The Exposure Rating evaluates how serious a fall would be, from PG (low risk) to R (serious) and X (potentially fatal), based on terrain, fall consequences, and protection availability.\r\nIt reflects the overall danger level of a route section where a mistake may result in long or unprotectable falls." }
            );
        }
    }
}
