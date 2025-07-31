using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.ValueObjects
{
    public record ClimbUserProfileData (
        string? ClimbingExperienceLevel,
        string? PreferredClimbingStyle,
        string? EmergencyContact,
        string? EmergencyContactName
    );
}
